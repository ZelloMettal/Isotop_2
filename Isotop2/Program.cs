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
            //Создаём хост приложения
            IHost host = Host.CreateDefaultBuilder()
            //Внедряем сервисы
            .ConfigureServices(service =>
            {
                //Сервисы основной формы
                service.AddSingleton<App>();
                service.AddSingleton<MainForm>();
                //Сервисы моделей
                IServiceCollection services = new ServiceCollection();
                Services(services);
                ServiceProvider serviceProvider = services.BuildServiceProvider();
                ServiceProviderHolder.ServiceProvider = serviceProvider;
            }).Build();

            //Проверяем существование базы данных
            if(CheckDateBase())
                MessageBox.Show("Не удалось загрузить базу данных. Была создана новаыя база данных!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            //Создаём необходимые ресурсы
            CreateResouses();

            //Получем объект приложение
            App application = host.Services.GetService<App>();
            //Запускаем приложение
            application?.Run();
        }
        //Настройка сервисов создание
        private static void Services(IServiceCollection services)
        {
            services.AddSingleton<MainModel>();
            services.AddScoped<IDataStorage<Technetium>, DataStorage<Technetium>>();
            services.AddScoped<IDataStorage<Iodine>, DataStorage<Iodine>>();
            services.AddScoped<IDataStorage<Radium>, DataStorage<Radium>>();
            services.AddScoped<IDataStorage<RI>, DataStorage<RI>>();
            services.AddScoped<TechnetiumModel>();
            services.AddScoped<IodineModel>();
            services.AddScoped<RadiumModel>();
            services.AddScoped<RIModel>();
            services.AddScoped<AuthorizationModel>();
            services.AddScoped<FormDataModel>();
        }
        //Проверка наличия базы
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
        //Создание необходимых ресурсов
        private static void CreateResouses()
        {
            string currentPath = Directory.GetCurrentDirectory();
            try 
            {
                if (!Directory.Exists($"{currentPath}\\Temp"))
                {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Temp");
                }
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
