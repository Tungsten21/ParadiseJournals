using CommunityToolkit.Mvvm.Messaging;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using UI.Dialogs;
using ViewModels;
using ViewModels.Controls;
using ViewModels.Dialogs;
using ViewModels.Interfaces;
using ViewModels.Navigation;

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
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString));

            services.AddSingleton<MainWindow>();
            services.AddTransient<BaseDialog>();
            services.AddSingleton<EntryView>();
            services.AddSingleton<CreateNewUserDialog>();
            services.AddSingleton<CreateNewJournalDialog>();
            services.AddSingleton<CreateNewWishListDialog>();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MenuBarViewModel>();
            services.AddSingleton<EntryViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<BaseDialogViewModel>();
            services.AddSingleton<CreateNewUserViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<ViewJournalViewModel>();
            services.AddSingleton<ViewWishListViewModel>();

            services.AddTransient<CreateNewJournalViewModel>();
            services.AddTransient<CreateNewWishListViewModel>();


            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IMessenger, WeakReferenceMessenger>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IServiceProvider, ServiceProvider>();
            services.AddDbContext<ApplicationDbContext>();
        }

        private void OnStart(object sender, StartupEventArgs e)
        {
            Window startUpWindow = serviceProvider.GetService<MainWindow>();
            startUpWindow.Show();
        }
    }


}
