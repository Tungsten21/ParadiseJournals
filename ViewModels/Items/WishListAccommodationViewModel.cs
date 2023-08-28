using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Items
{
    public partial class WishListAccommodationViewModel : ObservableObject
    {
        private string _name;
        private string _thumbnail;
        private string _websiteUrl;
        private int _rating;
        private string _location;
        private string _currency;
        private double _pricePerNight;
        private string _notes;
        private ObservableCollection<string> _additionalPhotos;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public string Thumbnail
        {
            get { return _thumbnail; }
            set { _thumbnail = value; }
        }


        public string WebSiteURL
        {
            get { return _websiteUrl; }
            set { _websiteUrl = value; }
        }

        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }


        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        public double PricePerNight
        {
            get { return _pricePerNight; }
            set { _pricePerNight = value; }
        }


        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }


        public ObservableCollection<string> AdditionalPhotos
        {
            get { return _additionalPhotos; }
            set { _additionalPhotos = value; }
        }
    }
}
