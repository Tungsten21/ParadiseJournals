using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Models.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Messages;
using ViewModels.Interfaces;

namespace ViewModels.Items
{
    public partial class ItemCache : ObservableObject
    {
        private readonly IMessenger _messenger;

        [NotifyPropertyChangedFor(nameof(NoItemsFound))]
        [NotifyPropertyChangedFor(nameof(NoWishListsButJournalFound))]
        [ObservableProperty]
        private bool _atLeastOneJournal;

        [NotifyPropertyChangedFor(nameof(NoItemsFound))]
        [NotifyPropertyChangedFor(nameof(NoJournalsButWishListFound))]
        [ObservableProperty]
        private bool _atLeastOneWishList;

        public event EventHandler ItemClickedEvent;

        public bool NoJournalsButWishListFound => AtLeastOneWishList && !AtLeastOneJournal;

        public bool NoWishListsButJournalFound => !AtLeastOneWishList && AtLeastOneJournal;

        public bool NoItemsFound => !AtLeastOneJournal && !AtLeastOneWishList;

        [ObservableProperty]
        private ObservableCollection<JournalViewModel> _journals = new();

        [ObservableProperty]
        private ObservableCollection<WishListViewModel> _wishlists = new();



        public ItemCache(IMessenger messenger)
        {
            _messenger = messenger;

            _messenger.Register<ItemCreatedMessage>(this, (r, m) => AddItemOnReceived(m.Value));
        }

        public void AddItemOnReceived(IModel item)
        {
            switch (item)
            {
                case JournalModel journal:

                    var journalVM = new JournalViewModel(journal);
                    journalVM.JournalItemClickedEvent += ItemClicked;
                    Journals.Add(journalVM);
                    if (!AtLeastOneJournal)
                        AtLeastOneJournal = true;

                    break;
                case WishListModel wishList:

                    var wishListVM = new WishListViewModel(wishList);
                    //wishListVM.WishListItemClickedEvent = ...
                    Wishlists.Add(wishListVM);
                    if (!AtLeastOneWishList)
                        AtLeastOneWishList = true;
                    break;

            }

        }

        private void ItemClicked(object? sender, EventArgs e)
        {
            ItemClickedEvent?.Invoke(sender, e);
        }
    }
}
