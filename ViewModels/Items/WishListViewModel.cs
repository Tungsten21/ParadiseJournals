using Common.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Validation;

namespace ViewModels.Items
{
    public partial class WishListViewModel: ValidatableViewModel, IViewModel, IClonableModel
    {
        //Properties
        private string _title;
        private string _country;
        private string _startDate;
        private string _endDate;
        private string _descripition;
        private string _city;

        private readonly WishListModel _model = new();


        [Required(ErrorMessage = "Please enter a title.")]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters.")]
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

        [Required(ErrorMessage = "Please select a country.")]
        public string Country
        {
            get => _country;
            set
            {
                _model.Country.Clear();
                if (SetProperty(ref _country, value, true) && GetErrors(nameof(Country)).Count() == 0)
                    _model.Country = value;
            }
        }

        [Required]
        [DateComparator(CompareMode.LessThan, "EndDate", ErrorMessage = "Start date must be before the end date.")]
        public string StartDate
        {
            get => _startDate;
            set
            {
                if (value.Length == 0)
                    return;

                if (SetProperty(ref _startDate, value, true) && GetErrors(nameof(StartDate)).Count() == 0)
                {
                    ClearErrors(nameof(EndDate));
                    _model.StartDate = DateOnly.Parse(value);
                }

            }

        }

        [Required]
        [DateComparator(CompareMode.GreaterThan, "StartDate", ErrorMessage = "End date must be after the start date.")]
        public string EndDate
        {
            get => _endDate;
            set
            {
                if (value.Length == 0)
                    return;

                if (SetProperty(ref _endDate, value, true) && GetErrors(nameof(EndDate)).Count() == 0)
                {
                    ClearErrors(nameof(StartDate));
                    _model.EndDate = DateOnly.Parse(value);
                }
            }
        }

        [MinLength(5, ErrorMessage = "Description must be greater than 5 characters")]
        public string Description
        {
            get => _descripition;
            set
            {
                _model.Description.Clear();
                if (SetProperty(ref _descripition, value, true) && GetErrors(nameof(Description)).Count() == 0)
                    _model.Description = value;
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _model.City.Clear();
                if (SetProperty(ref _city, value, true) && GetErrors(nameof(City)).Count() == 0)
                    _model.City = value;
            }
        }

        //Constructors
        public WishListViewModel()
        {
            
        }

        public WishListViewModel(WishListModel model) => _model = model;

        public WishListViewModel(WishListViewModel viewModel)
        {
            Title = viewModel.Title;
            Country = viewModel.Country;
            StartDate = viewModel.StartDate;
            EndDate = viewModel.EndDate;
            Description = viewModel.Description;
            City = viewModel.City;
        }

        public IModel CloneModel()
        {
            return new WishListModel()
            {
                Id = _model.Id,
                Title = _model.Title,
                Country = _model.Country,
                StartDate = _model.StartDate,
                EndDate = _model.EndDate,
                Description = _model.Description,
                City = _model.City
            };
        }
    }
}
