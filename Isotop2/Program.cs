using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Isotop2.Data.Entities;
using Isotop2.Data;
using Isotop2.Services;
using System.Windows;
using Isotop2.Data.Models;
using Isotop2.Data.Interfaces;

namespace Isotop2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
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
            //Получем объект приложение
            App application = host.Services.GetService<App>();
            //Запускаем приложение
            application?.Run();
        }
        //Настройка сервисов создание типа синглтон
        private static void Services(IServiceCollection services)
        {
            services.AddScoped<IDataStorage<Technetium>, DataStorage<Technetium>>();
            services.AddScoped<IDataStorage<Iodine>, DataStorage<Iodine>>();
            services.AddScoped<IDataStorage<Radium>, DataStorage<Radium>>();
            services.AddScoped<IDataStorage<RI>, DataStorage<RI>>();
            services.AddScoped<TechnetiumModel>();
            services.AddScoped<IodineModel>();
            services.AddScoped<RadiumModel>();
            services.AddScoped<RIModel>();
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
    }
}
