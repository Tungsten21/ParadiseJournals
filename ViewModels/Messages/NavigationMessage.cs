using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ViewModels.Messages
{
    public class NavigationMessage : ValueChangedMessage<IViewModel>
    {
        public NavigationMessage(IViewModel viewModel) : base(viewModel){}


    }
}
