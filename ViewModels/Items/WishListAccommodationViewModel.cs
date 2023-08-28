using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Models;
using ViewModels.Validation;

namespace ViewModels.Items
{
    public partial class WishListAccommodationViewModel : ValidatableViewModel
    {
        private string _name;
        private byte[] _thumbnail;
        private string _websiteUrl;
        private int _rating;
        private string _location;
        private Currency _currency;
        private double _pricePerNight;
        private string _notes;
        private ObservableCollection<byte[]> _additionalPhotos;
        private readonly WishListAccommodationModel _model = new();

        #region Information

        [Required(ErrorMessage = "Please enter the name of the accommodation.")]
        [MinLength(5, ErrorMessage = "Accommodation name must be at least 5 characters.")]
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
        #endregion


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

        public int Rating
        {
            get => _rating;
            set
            {
                if (SetProperty(ref _rating, value, true) && GetErrors(nameof(Rating)).Count() == 0)
                    _model.Rating = value;
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

        public double PricePerNight
        {
            get => _pricePerNight;
            set
            {
                if (SetProperty(ref _pricePerNight, value, true) && GetErrors(nameof(PricePerNight)).Count() == 0)
                    _model.PricePerNight = value;
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
    }
}
