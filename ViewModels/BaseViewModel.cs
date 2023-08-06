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
        private readonly IUserContext _user;

        public BaseViewModel(IUserContext userContext)
        {
            _user = userContext;
        }
    }
}
