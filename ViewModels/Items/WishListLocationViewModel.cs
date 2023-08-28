using Common.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using ViewModels.Validation;

namespace ViewModels.Items
{
    public partial class WishListLocationViewModel : ValidatableViewModel
    {
        private string _name;
        private byte[] _thumbnail;
        private string _websiteUrl;
        private LocationCategory _locationCategory;
        private string _location;
        private Currency _currency;
        private double _pricePerPerson;
        private string _notes;
        private ObservableCollection<byte[]> _additionalPhotos;
        private readonly WishListLocationModel _model = new();

        #region Information

        [Required(ErrorMessage = "Please enter the name of the location.")]
        [MinLength(5, ErrorMessage = "Location name must be at least 5 characters.")]
        public string Name
        {
            get => _name;
            set
            {
                _model.Name.Clear();
                if (SetProperty(ref _name, value, true) && GetErrors(nameof(Name)).Count() == 0)
                    _model.Name = value;
            }

        }


        public byte[] Thumbnail
        {
            get => _thumbnail;
            set
            {
                if (SetProperty(ref _thumbnail, value, true) && GetErrors(nameof(Thumbnail)).Count() == 0)
                    _model.Thumbnail = value;
            }
        }


        public string WebSiteURL
        {
            get => _websiteUrl;
            set
            {
                _model.WebsiteURL.Clear();
                if (SetProperty(ref _websiteUrl, value, true) && GetErrors(nameof(WebSiteURL)).Count() == 0)
                    _model.WebsiteURL = value;
            }
        }

        public LocationCategory LocationCategory
        {
            get => _locationCategory;
            set
            {
                if (SetProperty(ref _locationCategory, value, true) && GetErrors(nameof(LocationCategory)).Count() == 0)
                    _model.LocationCategory = value;
            }
        }


        public string Location
        {
            get => _location;
            set
            {
                _model.Location.Clear();
                if (SetProperty(ref _location, value, true) && GetErrors(nameof(Location)).Count() == 0)
                    _model.Location = value;
            }
        }

        public Currency Currency
        {
            get => _currency;
            set
            {
                if (SetProperty(ref _currency, value, true) && GetErrors(nameof(Currency)).Count() == 0)
                    _model.Currency = value;
            }
        }

        public double PricePerPerson
        {
            get => _pricePerPerson;
            set
            {
                if (SetProperty(ref _pricePerPerson, value, true) && GetErrors(nameof(PricePerPerson)).Count() == 0)
                    _model.PricePerPerson = value;
            }
        }


        public string Notes
        {
            get => _notes;
            set
            {
                _model.Notes.Clear();
                if (SetProperty(ref _notes, value, true) && GetErrors(nameof(Notes)).Count() == 0)
                    _model.Name = value;
            }
        }


        public ObservableCollection<byte[]> AdditionalPhotos
        {
            get => _additionalPhotos;
            set
            {
                if (SetProperty(ref _additionalPhotos, value, true) && GetErrors(nameof(AdditionalPhotos)).Count() == 0)
                    _model.AdditionalPhotos = value.ToList();
            }
        }
        #endregion
    }
}
