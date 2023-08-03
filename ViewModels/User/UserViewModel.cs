using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
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
        private IModel _model;

        public string Email
        {
            get { return _email; }
            set 
            { 
                SetProperty(ref _email, value);
            }
        }

        public string Username
        {
            get { return _userName; }
            set
            {
                SetProperty(ref _userName, value);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                SetProperty(ref _confirmPassword, value);
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
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
