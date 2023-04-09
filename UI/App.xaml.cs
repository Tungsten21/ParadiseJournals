using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI.Dialogs;
using ViewModels;
using ViewModels.Dialogs;
using ViewModels.Interfaces;

namespace UI
{

    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

        }

        private void ConfigureServices(ServiceCollection services)
        {
            //services.AddDbContext<EmployeeDbContext>(options =>
            //{
            //    options.UseSqlite("Data Source = Employee.db");
            //});

            services.AddSingleton<MainWindow>();
            services.AddTransient<BaseDialog>();
            services.AddSingleton<EntryView>();


            services.AddSingleton<EntryViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<BaseDialogViewModel>();


            services.AddSingleton<IDialogService, DialogService>();
            
        }

        private void OnStart(object sender, StartupEventArgs e)
        {
            Window startUpWindow = serviceProvider.GetService<MainWindow>();
            startUpWindow.Show();
        }
    }


}
