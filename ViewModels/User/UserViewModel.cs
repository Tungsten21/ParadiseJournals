using Common.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Validation;

namespace ViewModels.User
{
    public partial class UserViewModel : ValidatableViewModel, IClonableModel
    {
        private string _email;
        private string _userName;
        private string _password;
        private string _confirmPassword;
        private string _firstName;
        private readonly UserModel _model = new();

        [Required]
        [EmailAddress]
        [MinLength(6)]
        public string Email
        {
            get { return _email; }
            set
            {
                _model.EmailAddress.Clear();
                if (SetProperty(ref _email, value, true) && GetErrors(nameof(Email)).Count() == 0)
                {
                    _model.EmailAddress = value;
                }
            }
        }

        [Required]
        [MinLength(6)]
        public string Username
        {
            get { return _userName; }
            set
            {
                _model.Username.Clear();
                if (SetProperty(ref _userName, value, true) && GetErrors(nameof(Username)).Count() == 0)
                {
                    _model.Username = value;
                }
            }
        }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string Password
        {
            get { return _password; }
            set
            {
                _model.Password.Clear();
                if (SetProperty(ref _password, value, true) && GetErrors(nameof(Password)).Count() == 0)
                {
                    _model.Password = value;
                }
            }
        }


        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        [Compare(nameof(Password))]
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                SetProperty(ref _confirmPassword, value);
            }
        }

        [MinLength(2)]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _model.FirstName.Clear();
                if (SetProperty(ref _firstName, value, true) && GetErrors(nameof(FirstName)).Count() == 0)
                {
                    _model.FirstName = value;
                }
            }
        }

        public UserViewModel() 
        {

        }

        public IModel CloneModel()
        {
            return new UserModel()
            {
                Username = _userName,
                Password = _password,
                EmailAddress = _email,
                FirstName = _firstName,
            };
        }
    }
}
