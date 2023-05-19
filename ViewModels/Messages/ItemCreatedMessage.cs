using CommunityToolkit.Mvvm.Messaging.Messages;
using Models.Interfaces;

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
