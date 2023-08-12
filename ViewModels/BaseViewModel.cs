using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Validation;

namespace ViewModels
{
    public partial class BaseViewModel : ValidatableViewModel
    {
        protected IUserContext _userContext;

        public BaseViewModel(IUserContext userContext)
        {
            _userContext = userContext;
        }
    }
}
