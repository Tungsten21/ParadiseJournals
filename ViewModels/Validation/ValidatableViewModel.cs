using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Validation
{
    public class ValidatableViewModel : BaseViewModel
    {
        public ValidatableViewModel(IUserContext userContext) : base(userContext) { }

        public bool IsValid()
        {
            ValidateAllProperties();
            return !GetErrors().Any();
        }
    }
}
