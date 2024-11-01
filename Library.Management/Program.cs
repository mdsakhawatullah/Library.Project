using Library.Management.Models;
using Library.Management.Repositary.DbConfigure;
using Library.Management.Repositary.InterfaceRepositary;
using Library.Management.Repositary.Repositary;
using Library.Management.Service.InterfaceService;
using Library.Management.Service.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LibraryMDbContextCS");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibraryMDbContext>(x => x.UseSqlServer(connectionString));

//register identity with LibraryMDbContext
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<LibraryMDbContext>()
				.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;
	options.User.RequireUniqueEmail = true;

});

//Services
builder.Services.AddScoped<ILibraryBookService, LibraryBookService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IBorrowBookService, BorrowBookService>();


//repositaries
builder.Services.AddScoped<ILibraryBookRepositary, LibraryBookRepositary>();
builder.Services.AddScoped<IMemberRepositary, MemberRepositary>();
builder.Services.AddScoped<IStaffRepositary, StaffRepositary>();
builder.Services.AddScoped<IStudentRepositary, StudentRepositary>();
builder.Services.AddScoped<IBorrowBookRepositary, BorrowBookRepositary>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
