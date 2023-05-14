using Common.Exceptions;
using CommunityToolkit.Mvvm.Messaging;
using ViewModels.Interfaces;
using ViewModels.Messages;

namespace ViewModels.Navigation
{
    public class NavigationService : INavigationService
    {
        //Properties
        private readonly IMessenger _messenger;
        private readonly IServiceProvider _serviceProvider;
        private IViewModel _destViewModel;

        //Constructors
        public NavigationService(IServiceProvider serviceProvider, IMessenger messenger)
        {
            _messenger = messenger;
            _serviceProvider = serviceProvider;
        }

        //Methods
        public void NavigateToViewModel<TViewModel>(Action? action = null) where TViewModel : IViewModel
        {
            _destViewModel = (IViewModel)_serviceProvider.GetService(typeof(TViewModel))
                ?? throw new ArgumentInvalidException("Passed in viewmodel " + typeof(TViewModel).FullName +  " is not registered with DI.");
            action?.Invoke();
            _messenger.Send(new NavigationMessage(_destViewModel));
        }
    }
}
