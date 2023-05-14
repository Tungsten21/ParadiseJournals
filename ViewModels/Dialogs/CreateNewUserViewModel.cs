using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Dialogs
{
    public partial class CreateNewUserViewModel : ObservableObject, IViewModel, IClosable
    {
        //Properties
        private readonly INavigationService _navigationService;


        public Action CloseWindow { get; set; }

        //Commands

        //Constructors
        public CreateNewUserViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //Methods
    }
}
