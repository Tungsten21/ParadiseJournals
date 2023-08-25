using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using ViewModels.Controls;
using ViewModels.Dialogs.Context;
using ViewModels.Interfaces;
using ViewModels.Messages;

namespace ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        //Properties
        private IServiceProvider _serviceProvider;
        private IMessenger _messenger;

        [ObservableProperty]
        private bool _isOverlayActive;

        [ObservableProperty]
        private IViewModel _currentPopupViewModel;

        [ObservableProperty]
        private IViewModel _currentViewModel;

        [ObservableProperty]
        private MenuBarViewModel _menuBarViewModel;

        //Commands 

        //Constructors
        public MainWindowViewModel(IServiceProvider serviceProvider, IUserContext userContext, IMessenger messenger,
            MenuBarViewModel menuBarViewModel)
        {
            _serviceProvider = serviceProvider;
            _messenger = messenger;
            _currentViewModel = _serviceProvider.GetService<EntryViewModel>();
            _menuBarViewModel = menuBarViewModel;

            //Message from NavigatationService
            _messenger.Register<NavigationMessage>(this, (r, m) =>
            {
                CurrentViewModel = m.Value;
            });

            //Message from ContextPopupService
            _messenger.Register<CreateContextPopupMessage>(this, (r, m) =>
            {
                CurrentViewModel = m.Value;
            });
        }

        //Methods
    }
}
