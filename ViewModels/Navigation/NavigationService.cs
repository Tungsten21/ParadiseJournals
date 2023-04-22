using Common.Exceptions;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Navigation
{
    public class NavigationService : INavigationService
    {

        private readonly IMessenger _messenger;
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider, IMessenger messenger)
        {
            _messenger = messenger;
            _serviceProvider = serviceProvider;
        }

        public void NavigateToViewModel<TViewModel>() where TViewModel : IViewModel
        {
            IViewModel destViewModel = (IViewModel)_serviceProvider.GetService(typeof(TViewModel)) 
                ?? throw new ArgumentInvalidException("Passed in viewmodel is not registered with DI.");
            
            _messenger.Send(new NavigationMessage<IViewModel>(destViewModel));
        }

    }
}
