using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Models;
using ViewModels.Validation;

namespace ViewModels.Items
{
    public partial class WishListNoteViewModel : ValidatableViewModel
    {

        private string _title;
        private string _text;
        private ObservableCollection<byte[]> _photos;
        private readonly WishListNoteModel _model;

        [Required(ErrorMessage = "Please enter the name of the location.")]
        [MinLength(5, ErrorMessage = "Location name must be at least 5 characters.")]
        public string Title
        {
            get => _title;
            set
            {
                _model.Title.Clear();
                if (SetProperty(ref _title, value, true) && GetErrors(nameof(Title)).Count() == 0)
                    _model.Title = value;
            }

        }


        public string Text
        {
            get => _text;
            set
            {
                _model.Text.Clear();
                if (SetProperty(ref _text, value, true) && GetErrors(nameof(Text)).Count() == 0)
                    _model.Text = value;
            }

        }


        public ObservableCollection<byte[]> Photos
        {
            get => _photos;
            set
            {
                if (SetProperty(ref _photos, value, true) && GetErrors(nameof(Photos)).Count() == 0)
                    _model.Photos = value.ToList();
            }
        }
    }
}
