using Microsoft.Extensions.Configuration;
using WebPlupload.Sevices;

namespace WebPlupload
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<Edoc>();

            builder.Services.AddScoped<Renew>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


            builder.Services.AddEGovPlatform(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
