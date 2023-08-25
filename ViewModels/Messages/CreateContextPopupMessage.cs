using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Messages
{
    public class CreateContextPopupMessage : ValueChangedMessage<IViewModel>
    {
        public CreateContextPopupMessage(IViewModel value) : base(value) { }
    }
}
