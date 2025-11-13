
using Cars_Auto.Data;
using Cars_Auto.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString(name: "DefualtConnection")
	?? throw new InvalidOperationException(message:"no connection string was found");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(ConnectionString));



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICatogryiesServices, CatogryiesServices>();
builder.Services.AddScoped<ICarServices, CarServices>();

builder.Services.AddSession();

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
