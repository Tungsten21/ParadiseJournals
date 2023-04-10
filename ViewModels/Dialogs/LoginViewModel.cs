using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Dialogs
{
    public partial class LoginViewModel : ObservableObject, IViewModel, IClosable
    {

        public LoginViewModel()
        {
            
        }

        public Action CloseWindow { get; set; }
    }
}
