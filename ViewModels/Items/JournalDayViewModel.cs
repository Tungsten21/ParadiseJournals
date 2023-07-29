using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Items
{
    public class JournalDayViewModel : ObservableObject
    {
        //Properties
        public readonly JournalDayModel Model = new();

        public string ShortDateFormat
        {
            get => Model.ShortDateFormat;
            set => SetProperty(Model.ShortDateFormat, value, Model, (m, sdf) => m.ShortDateFormat = value);

        }

        //Construtors
        public JournalDayViewModel(JournalDayModel model) => Model = model;

        public JournalDayViewModel()
        {
            
        }


        //Methods
    }
}
