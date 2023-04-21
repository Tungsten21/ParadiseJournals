using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Navigation;

namespace ViewModels.Dialogs
{
    public partial class CreateNewUserViewModel : ObservableObject, IViewModel, IClosable
    {
        private readonly INavigationService _navigationService;

        //Properties

        //Constructors
        public CreateNewUserViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Action CloseWindow { get; set; }
        //Commands

        //Methods
    }
}
