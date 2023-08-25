﻿using CommunityToolkit.Mvvm.Messaging.Messages;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Messages
{
    public class ItemClickedMessage : ValueChangedMessage<IModel>
    {
        public ItemClickedMessage(IModel item) : base(item){}
    }
}
