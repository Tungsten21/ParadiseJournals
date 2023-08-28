using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        [RelayCommand]
        private void CloseContextPopupOnLostFocus()
        {
            if (IsOverlayActive && CurrentPopupViewModel is not null)
            {
                ToggleContextPopup(false);
            }
        }

        //Constructors
        public MainWindowViewModel(IServiceProvider serviceProvider, IMessenger messenger,
            MenuBarViewModel menuBarViewModel)
        {
            _serviceProvider = serviceProvider;
            _messenger = messenger;

            _currentViewModel = _serviceProvider.GetService<EntryViewModel>();
            _menuBarViewModel = menuBarViewModel;

            //Message from NavigationService
            _messenger.Register<NavigationMessage>(this, (r, m) =>
            {
                CurrentViewModel = m.Value;
            });

            //Message from ContextPopupService
            _messenger.Register<CreateContextPopupMessage>(this, (r, m) =>
            {
                CurrentPopupViewModel = m.Value;
            });

            //Message from ContextPopupService
            _messenger.Register<ToggleContextPopupVisibilityMessage>(this, (r, m) =>
            {
                ToggleContextPopup(m.Value);
            });
        }

        private void ToggleContextPopup(bool visible)
        {
            if (visible)
            {
                IsOverlayActive = true;
                return;
            }

            /*
             * Need to check whether value is show or close (true or false for now).
             * On show view model should have already been set.
             * On close view model dispose of any resources on popup, then set to null.
             * Ideally dont want view models with views you cant see in memory when they dont need to be.
             */
            IsOverlayActive = false;
            //{dispose of viewmodel}
            CurrentPopupViewModel = null;
        }

        //Methods
    }
}
