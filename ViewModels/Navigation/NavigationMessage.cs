using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ViewModels.Navigation
{
    public class NavigationMessage<TViewModel> : ValueChangedMessage<TViewModel> where TViewModel : IViewModel
    {
        public IViewModel ViewModel { get; }

        public NavigationMessage(TViewModel viewModel) : base(viewModel)
        {
            ViewModel = viewModel;
        }


    }
}
