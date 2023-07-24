using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ViewModels.Interfaces;
using Common.Extensions;
using ViewModels.Validation;

namespace ViewModels.Items
{
    public class JournalViewModel : ObservableValidator, IViewModel
    {
        //Properties
        //private IReadOnlyCollection<ValidationResult> _errors = new List<ValidationResult>();
        private string _title;
        private string _country;
        private string _startDate;
        private string _endDate;

        public readonly JournalModel Model = new();


        [MinLength(5, ErrorMessage = "Journal title must be at least 5 characters.")]
        public string Title
        {
            get => _title;
            set
            {
                Model.Title.Clear();
                if (SetProperty(ref _title, value, true) && GetErrors(nameof(Title)).Count() == 0)
                    Model.Title = value;
            }

        }

        [Required(ErrorMessage = "Please select a country.")]
        public string Country
        {
            get => _country;
            set
            {
                Model.Country.Clear();
                if (SetProperty(ref _country, value, true) && GetErrors(nameof(Country)).Count() == 0)
                    Model.Title = value;
            }
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
                    Model.StartDate = DateOnly.Parse(value);
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
                    Model.EndDate = DateOnly.Parse(value);
                }
            }
        }

        [OpitionalMinimumLength(5)]
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
            {
                dayViewModels.Add(new JournalDayViewModel(dayViewModel));
            }
                
            return dayViewModels;
        }
    }
}
