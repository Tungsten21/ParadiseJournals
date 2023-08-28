using CommunityToolkit.Mvvm.Messaging.Messages;
using Models.Interfaces;

namespace ViewModels.Messages
{
    public class ItemCreatedMessage : ValueChangedMessage<IModel>
    {
        public ItemCreatedMessage(IModel item) : base(item){}
    }
}
