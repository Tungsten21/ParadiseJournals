using CommunityToolkit.Mvvm.Messaging;
using Data;
using Data.Interfaces;
using Data.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Configuration;
using System.Windows;
using UI.Dialogs;
using ViewModels;
using ViewModels.Controls;
using ViewModels.Dialogs;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Mappers;
using ViewModels.Navigation;
using ViewModels.User;

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
            services.AddDbContext<ApplicationDbContext>();

            services.AddAutoMapper(typeof(ServiceProfiles).Assembly, 
                                   typeof(ViewModelProfiles).Assembly,
                                   typeof(RepositoryProfiles).Assembly);

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

            services.AddSingleton<IUserContext, UserContext>();
            services.AddSingleton<ItemCache>();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IMessenger, WeakReferenceMessenger>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IServiceProvider, ServiceProvider>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IJournalService, JournalService>();
            services.AddSingleton<IWishlistService, WishlistService>();

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IJournalRepository, JournalRepository>();
            services.AddSingleton<IWishlistRepository, WishlistRepository>();


        }

        private void OnStart(object sender, StartupEventArgs e)
        {
            Window startUpWindow = serviceProvider.GetService<MainWindow>();
            startUpWindow.Show();
        }
    }


}
