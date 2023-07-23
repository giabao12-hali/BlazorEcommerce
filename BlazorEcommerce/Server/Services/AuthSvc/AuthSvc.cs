using System.Security.Cryptography;

namespace BlazorEcommerce.Server.Services.AuthSvc
{
	public class AuthSvc : IAuthSvc
	{
		private readonly DataContext _context;

		public AuthSvc(DataContext context)
        {
			_context = context;
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
	}
}
