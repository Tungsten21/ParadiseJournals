using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Messages
{
    public class ToggleContextPopupVisibilityMessage : ValueChangedMessage<bool>
    {
        public ToggleContextPopupVisibilityMessage(bool value) : base(value) { }
    }
}
