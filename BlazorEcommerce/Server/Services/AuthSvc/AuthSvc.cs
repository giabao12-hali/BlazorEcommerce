using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.Design.Serialization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BlazorEcommerce.Server.Services.AuthSvc
{
	public class AuthSvc : IAuthSvc
	{
		private readonly DataContext _context;
		private readonly IConfiguration _configuration;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AuthSvc(DataContext context, IConfiguration configuration,
				IHttpContextAccessor httpContextAccessor)
        {
			_context = context;
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;
		}

		public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

		public string GetUserEmail() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);


		public async Task<ServiceResponse<string>> Login(string email, string password)
		{
			var response = new ServiceResponse<string>();
			var user = await _context.Users
				.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
			if(user == null)
			{
				response.Success = false;
				response.Message = "User not found.";
			}
			else if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
			{
				response.Success = false;
				response.Message = "Wrong password.";
			}
			else
			{
				response.Data = CreateToken(user);
			}

			return response;
		}

		// giải thích function ĐĂNG KÝ TÀI KHOẢN
		//đầu tiên sẽ check xem đã có Email nào được đăng ký trong Database chưa
		//nếu không có thì sẽ tạo một tài khoản có mật khẩu được mã hóa thông qua CreatePasswordHash function
		//sau đó set password dựa vào PasswordHash và PasswordSalt
		//sau đó add người dùng vào Database
		//rồi SaveChanges
		public async Task<ServiceResponse<int>> Register(User user, string password)
		{
			if(await UserExist(user.Email))
			{
				return new ServiceResponse<int> 
				{ 
					Success = false, 
					Message = "User already exist." 
				};
			}

			CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return new ServiceResponse<int>
			{
				Data = user.Id,
				Message = "Registration successful!"
			};
		}

		public async Task<bool> UserExist(string email)
		{
			if(await _context.Users.AnyAsync(user => user.Email.ToLower()
				.Equals(email.ToLower())))
			{
				return true;
			}
			return false;
		}

		// giải thích function
		//sử dụng mã bảo mật HMACSHA512
		//sau đó truyền chuỗi string password vào
		//sau đó sẽ tạo một cái Key, key này được tạo dành cho passwordSalt
		//sau đó ComputeHash method sẽ dùng passwordSalt (key) và truyền chuỗi string password vào passwordHash
		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computedHash = hmac
					.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computedHash.SequenceEqual(passwordHash);
			}
		}

		private string CreateToken(User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.Email),
				new Claim(ClaimTypes.Role, user.Role)
			};

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
				.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: creds);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}

		public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
		{
			var user = await _context.Users.FindAsync(userId);
			if (user == null)
			{
				return new ServiceResponse<bool>
				{ 
					Success = false,
					Message = "User not found."
				};
			}

			CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			await _context.SaveChangesAsync();

			return new ServiceResponse<bool> 
			{
				Data = true,
				Message = "Password has been changed."
			};
		}

		public async Task<User> GetUserByEmail(string email)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
		}
	}
}
