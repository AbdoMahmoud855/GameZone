using Demo.BL;
using Demo.DAL._Data.Context;
using GameZone.Helper.Services;
using GameZone.Helper.Services.Interface;
using GameZone.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameZone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<StoreContext>((option) => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging()  // Shows conflicting IDs
           .EnableDetailedErrors());

            builder.Services.AddBussniesLogic();
           builder.Services.AddAutoMapper(p => p.AddProfile(new GamesProfile()));
            builder.Services.AddScoped(typeof(ICreateServices), typeof(CreateServices));
            var app = builder.Build();

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
                pattern: "{controller=Games}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
