﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Navigation
{
    public interface INavigationService
    {
        void NavigateToViewModel<TViewModel>() where TViewModel : IViewModel;
    }
}
