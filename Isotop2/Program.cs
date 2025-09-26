using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Isotop2.Data.Entities;
using Isotop2.Data;
using Isotop2.Services;
using System.Windows;
using System.IO;
using Isotop2.Data.Models;
using Isotop2.Data.Interfaces;

namespace Isotop2
{
    internal static class Program
    {
        [STAThreadAttribute]
        public static void Main()
        {   
            IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(service =>
            {
                service.AddSingleton<App>();
                service.AddSingleton<MainForm>();
                IServiceCollection services = new ServiceCollection();
                Services(services);
                ServiceProvider serviceProvider = services.BuildServiceProvider();
                ServiceProviderHolder.ServiceProvider = serviceProvider;
            }).Build();

            if(CheckDateBase())
                MessageBox.Show("Не удалось загрузить базу данных. Была создана новаыя база данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            CreateResouses();

            App application = host.Services.GetService<App>();
            application?.Run();
        }

        private static void Services(IServiceCollection services)
        {            
            services.AddSingleton<IMainModel, MainModel>();
            services.AddScoped<IDataStorage<Technetium>, DataStorage<Technetium>>();
            services.AddScoped<IDataStorage<Iodine>, DataStorage<Iodine>>();
            services.AddScoped<IDataStorage<Radium>, DataStorage<Radium>>();
            services.AddScoped<IDataStorage<RI>, DataStorage<RI>>();
            services.AddScoped<ITechnetiumModel, TechnetiumModel>();
            services.AddScoped<IIodineModel, IodineModel>();
            services.AddScoped<IRadiumModel, RadiumModel>();
            services.AddScoped<IAuthorizationModel, AuthorizationModel>();
            services.AddScoped<IRIModel, RIModel>();
            services.AddScoped<IFormDataModel, FormDataModel>();
        }

        private static bool CheckDateBase()
        {
            bool isСreate = false;
            using (DataDBContext db = new DataDBContext())
            {
                isСreate = db.Database.EnsureCreated();
            }
            new Logger($"\nБаза данных существует: {(!isСreate).ToString()}; {DateTime.Now.ToString()}");
            return isСreate;
        }

        private static void CreateResouses()
        {
            string currentPath = Directory.GetCurrentDirectory();
            try 
            {
                if (!Directory.Exists($"{currentPath}\\Temp"))                
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Temp");                
                if(!Directory.Exists($"{currentPath}\\Temp\\PDF"))
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Temp\\PDF");
                if (!Directory.Exists($"{currentPath}\\Temp\\CSV"))
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Temp\\CSV");
                if (!Directory.Exists($"{currentPath}\\Fonts"))
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Fonts");
                if (!File.Exists($"{currentPath}\\Fonts\\arial.ttf"))
                { 
                    File.Create($"{Directory.GetCurrentDirectory()}\\Fonts\\arial.ttf").Close();
                    File.WriteAllBytes($"{Directory.GetCurrentDirectory()}\\Fonts\\arial.ttf", Properties.Resources.arial);
                }
            }
            catch(Exception ex)
            {
                new Logger($"LD:Не удалось создать необходимые каталоги {ex.Message} {DateTime.Now.ToString()}");
                MessageBox.Show("Не удалось создать необходимые каталоги для работы", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
