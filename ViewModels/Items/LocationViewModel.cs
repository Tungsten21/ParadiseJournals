using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Items
{
    public class LocationViewModel
    {
        private string _name;
        private string _thumbnail;
        private string _websiteUrl;
        private string _category;
        private string _location;
        private string _currency;
        private double _pricePerPerson;
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

        public string Category
        {
            get { return _category; }
            set { _category = value; }
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
            get { return _pricePerPerson; }
            set { _pricePerPerson = value; }
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
