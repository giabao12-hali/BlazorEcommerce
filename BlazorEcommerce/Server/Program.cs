global using BlazorEcommerce.Shared;
global using BlazorEcommerce.Server.Data;
global using Microsoft.EntityFrameworkCore;
global using BlazorEcommerce.Server.Services.ProductSvc;
global using BlazorEcommerce.Server.Services.CategorySvc;
global using BlazorEcommerce.Server.Services.CartSvc;
global using BlazorEcommerce.Server.Services.AuthSvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("myDB")));

// swagger api
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//

// services
builder.Services.AddScoped<IProductSvc, ProductSvc>();
builder.Services.AddScoped<ICategorySvc, CategorySvc>();
builder.Services.AddScoped<ICartSvc, CartSvc>();
builder.Services.AddScoped<IAuthSvc, AuthSvc>();
//

// authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding
				.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});
//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
