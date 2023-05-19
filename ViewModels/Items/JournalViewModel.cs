using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using ViewModels.Interfaces;

namespace ViewModels.Items
{
    public class JournalViewModel : ObservableObject, IViewModel
    {
        //Properties
        public readonly JournalModel Model = new();

        public string Title
        {
            get => Model.Title;
            set => SetProperty(Model.Title, value, Model, (m, t) => m.Title = t);
        }

        public string Country
        {
            get => Model.Country;
            set => SetProperty(Model.Country, value, Model, (m, c) => m.Country = c);
        }

        public string StartDate
        {
            get => Model.StartDate.ToString();
            set
            {
                if (value.Length != 0)
                    SetProperty(Model.StartDate, DateOnly.Parse(value), Model, (m, sd) => m.StartDate = DateOnly.Parse(value));
            }

        }

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
        public JournalViewModel()
        {

        }

        public JournalViewModel(JournalModel model) => Model = model;

        public JournalViewModel(JournalViewModel viewModel)
        {
            Title = viewModel.Title;
            Country = viewModel.Country;
            StartDate = viewModel.StartDate;
            EndDate = viewModel.EndDate;
            Description = viewModel.Description;
            City = viewModel.City;
        }

        //Methods
    }
}
