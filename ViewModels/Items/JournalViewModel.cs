using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ViewModels.Interfaces;
using Common.Extensions;
using ViewModels.Validation;
using Models.Interfaces;
using CommunityToolkit.Mvvm.Input;

namespace ViewModels.Items
{
    public partial class JournalViewModel : ValidatableViewModel, IViewModel, IClonableModel
    {
        //Properties
        //private IReadOnlyCollection<ValidationResult> _errors = new List<ValidationResult>();
        private string _title;
        private string _country;
        private string _startDate;
        private string _endDate;
        private string _descripition;
        private string _city;
        private readonly JournalModel _model = new();

        private bool _isPreviousDateInvalid;
        private bool _isEndDateInvalid;

        public event EventHandler JournalItemClickedEvent;

        public bool IsPreviousDateInvalid
        {
            get
            {
                return GetErrors(nameof(StartDate)).Any() || GetErrors(nameof(EndDate)).Any();
            }
            set
            {
                _isPreviousDateInvalid = value;
                SetProperty(ref _isPreviousDateInvalid, value, true);
            }
        }



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

        public ObservableCollection<JournalDayViewModel>? Days
        {
            get => MapDayModels();
            set
            {
                var dayModels = MapDayViewModels(value);
                SetProperty(_model.Days, dayModels, _model, (m, d) => m.Days = dayModels);
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
                    ClearErrors(nameof(StartDate));
                    _model.StartDate = DateOnly.Parse(value);

                    IsPreviousDateInvalid = GetErrors(nameof(EndDate)).Any() ? true : false;
                    ClearErrors(nameof(EndDate));

                    return;
                }

                IsPreviousDateInvalid = true;
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
                    ClearErrors(nameof(EndDate));
                    _model.EndDate = DateOnly.Parse(value);


                    IsPreviousDateInvalid = GetErrors(nameof(StartDate)).Any() ? true : false;
                    ClearErrors(nameof(StartDate));
                    return;
                }

                IsPreviousDateInvalid = true;
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
        public JournalViewModel()
        {

        }

        public JournalViewModel(JournalModel model)
        {
            _model = model;
            SetProperty(ref _title, model.Title, nameof(Title));
            SetProperty(ref _country, model.Country, nameof(Country));
            SetProperty(ref _startDate, model.StartDate.ToString(), nameof(StartDate));
            SetProperty(ref _endDate, model.EndDate.ToString(), nameof(EndDate));
            SetProperty(ref _city, model.City, nameof(City));
            SetProperty(ref _descripition, model.Description, nameof(Description));
        }


        //Methods
        public void ItemClicked()
        {
            JournalItemClickedEvent?.Invoke(this, EventArgs.Empty);
        }

        public IModel CloneModel()
        {
            return new JournalModel()
            {
                Id = _model.Id,
                Title = _model.Title,
                Country = _model.Country,
                StartDate = _model.StartDate,
                EndDate = _model.EndDate,
                Description = _model.Description,
                City = _model.City,
                Days = _model.Days
            };
        }

        private IEnumerable<JournalDayModel> MapDayViewModels(ObservableCollection<JournalDayViewModel> colleciton)
        {
            return from viewModels in colleciton select viewModels.Model;
        }

        private ObservableCollection<JournalDayViewModel> MapDayModels()
        {
            var dayModels = _model.Days;
            var dayViewModels = new ObservableCollection<JournalDayViewModel>();

            foreach (var dayViewModel in dayModels)
            {
                dayViewModels.Add(new JournalDayViewModel(dayViewModel));
            }

            return dayViewModels;
        }
    }
}
