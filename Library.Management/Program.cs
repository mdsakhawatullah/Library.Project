using Library.Management.Repositary.DbConfigure;
using Library.Management.Repositary.InterfaceRepositary;
using Library.Management.Repositary.Repositary;
using Library.Management.Service.InterfaceService;
using Library.Management.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibraryMDbContext>(x => x.UseSqlServer
(builder.Configuration.GetConnectionString("LibraryMDbContextCS")));

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
