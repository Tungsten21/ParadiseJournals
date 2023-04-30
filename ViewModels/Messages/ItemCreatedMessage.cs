using CommunityToolkit.Mvvm.Messaging.Messages;
using ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Messages
{
    public class ItemCreatedMessage : ValueChangedMessage<ICreatableItem>
    {
        public ICreatableItem Item { get; }

        public ItemCreatedMessage(ICreatableItem item) : base(item)
        {
            Item = item;
        }
    }
}
