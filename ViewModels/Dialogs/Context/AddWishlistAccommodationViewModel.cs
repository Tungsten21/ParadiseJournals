using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Dialogs.Context
{
    public partial class AddWishlistAccommodationViewModel : ObservableObject, IViewModel
    {
        [ObservableProperty] private string _test;

        public AddWishlistAccommodationViewModel()
        {
            
        }
    }
}
