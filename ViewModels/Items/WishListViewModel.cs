using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Validation;

namespace ViewModels.Items
{
    public partial class WishListViewModel: ObservableValidator, IViewModel
    {
        //Properties
        public readonly WishListModel Model = new();

        [Required]
        [MinLength(5, ErrorMessage = "Wishlist title must be at least 5 characters.")]
        public string Title
        {
            get => Model.Title;
            set => SetProperty(Model.Title, value, Model, (m, t) => m.Title = t);
        }

        [Required(ErrorMessage = "Please select a country.")]
        public string Country
        {
            get => Model.Country;
            set => SetProperty(Model.Country, value, Model, (m, c) => m.Country = c);
        }

        [Required]
        [DateComparator(CompareMode.LessThan, "EndDate", ErrorMessage = "Start date must be before the end date.")]
        public string StartDate
        {
            get => Model.StartDate.ToString();

            set
            {
                if (value.Length != 0)
                    SetProperty(Model.StartDate, DateOnly.Parse(value), Model, (m, sd) => m.StartDate = DateOnly.Parse(value));
            }

        }

        [Required]
        [DateComparator(CompareMode.LessThan, "StartDate", ErrorMessage = "End date must be after the start date.")]
        public string EndDate
        {
            get => Model.EndDate.ToString();
            set
            {
                if (value.Length != 0)
                    SetProperty(Model.EndDate, DateOnly.Parse(value), Model, (m, ed) => m.EndDate = DateOnly.Parse(value));
            }
        }

        public string Description
        {
            get => Model.Description;
            set => SetProperty(Model.Description, value, Model, (m, d) => m.Description = d);
        }

        public string City
        {
            get => Model.City;
            set => SetProperty(Model.City, value, Model, (m, c) => m.City = c);
        }

        //Constructors
        public WishListViewModel()
        {
            
        }

        public WishListViewModel(WishListModel model) => Model = model;

        public WishListViewModel(WishListViewModel viewModel)
        {
            Title = viewModel.Title;
            Country = viewModel.Country;
            StartDate = viewModel.StartDate;
            EndDate = viewModel.EndDate;
            Description = viewModel.Description;
            City = viewModel.City;
        }

    }
}
