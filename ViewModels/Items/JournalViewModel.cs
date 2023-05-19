using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using System.Collections.ObjectModel;
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

        public ObservableCollection<JournalDayViewModel>? Days
        {
            get => MapDayModels();
            set
            {
                var dayModels = MapDayViewModels(value);
                SetProperty(Model.Days, dayModels, Model, (m, d) => m.Days = dayModels);
            }
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


        //Methods
        private IEnumerable<JournalDayModel> MapDayViewModels(ObservableCollection<JournalDayViewModel> colleciton)
        {
            return from viewModels in colleciton select viewModels.Model;
        }

        private ObservableCollection<JournalDayViewModel> MapDayModels()
        {
            var dayModels = Model.Days;
            var dayViewModels = new ObservableCollection<JournalDayViewModel>();

            foreach (var dayViewModel in dayModels)
                dayViewModels.Add(new JournalDayViewModel(dayViewModel));

            return dayViewModels;
        }


    }
}
