using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Dialogs
{
    public partial class BaseDialogViewModel : ObservableObject, IViewModel
    {
        //Properties
        [ObservableProperty]
        private IViewModel _viewModel;

        //Constructors
        public BaseDialogViewModel()
        {
            
        }

        //Commands

        //Methods
    }
}
