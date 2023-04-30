using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Items
{
    public partial class WishListViewModel: ObservableObject, IViewModel, ICreatableItem
    {
        //Properties
        public readonly WishListModel _model = new();

        public string Title
        {
            get => _model.Title;
            set => SetProperty(_model.Title, value, _model, (m, t) => m.Title = t);
        }

        public string Country
        {
            get => _model.Title;
            set => SetProperty(_model.Country, value, _model, (m, c) => m.Country = c);
        }

        public string StartDate
        {
            get => _model.StartDate.ToString();

            set
            {
                if (value.Length != 0)
                    SetProperty(_model.StartDate, DateOnly.Parse(value), _model, (m, sd) => m.StartDate = DateOnly.Parse(value));
            }

        }

        public string EndDate
        {
            get => _model.EndDate.ToString();
            set
            {
                if (value.Length != 0)
                    SetProperty(_model.EndDate, DateOnly.Parse(value), _model, (m, ed) => m.EndDate = DateOnly.Parse(value));
            }
        }

        public string Description
        {
            get => _model.Description;
            set => SetProperty(_model.Description, value, _model, (m, d) => m.Description = d);
        }

        public string City
        {
            get => _model.City;
            set => SetProperty(_model.City, value, _model, (m, c) => m.City = c);
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

    }
}
