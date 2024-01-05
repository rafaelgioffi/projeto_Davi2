using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System.Globalization;

namespace ProjetoFinal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var mssqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Contexto>(options =>
            {
                options.UseSqlServer(mssqlConnection);
            });
            //(options => options.UseSqlServer("Data Source=localhost,1433; Initial Catalog=projetoFinal; User ID=sa; password=1q2w3e4r@#$;language=Portuguese"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //correção do idioma...
            var cultureInfo = new CultureInfo("pt-BR");

            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ",";
            cultureInfo.NumberFormat.NumberDecimalDigits = 2;
            cultureInfo.NumberFormat.CurrencyDecimalDigits = 2;

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            //fim da correção do idioma...

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Clientes}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "FechamentoCaixa",
                pattern: "{controller=Compra}/{action=FechamentoCaixa}/{date?}");

            app.Run();
        }
    }
}