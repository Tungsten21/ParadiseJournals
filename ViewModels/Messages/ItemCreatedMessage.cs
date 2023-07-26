using CommunityToolkit.Mvvm.Messaging.Messages;
using Models.Interfaces;

namespace ViewModels.Messages
{
    public class ItemCreatedMessage : ValueChangedMessage<IModel>
    {
        public IModel Item { get; }

        public ItemCreatedMessage(IModel item) : base(item)
        {
            Item = item;
        }
    }
}
