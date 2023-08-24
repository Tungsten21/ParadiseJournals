using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Messages
{
    public class PopupMessage : ValueChangedMessage<IViewModel>
    {
        public IViewModel ViewModel { get; }
        public bool Close { get; }

        public PopupMessage(IViewModel value) : base(value)
        {
            ViewModel = value;
        }

        public PopupMessage(bool closePopup)
        {
            Close = closePopup;
        }

    }
}
