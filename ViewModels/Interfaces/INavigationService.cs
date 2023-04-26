﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Interfaces
{
    public interface INavigationService
    {
        void NavigateToViewModel<TViewModel>(Action? action = null) where TViewModel : IViewModel;

    }
}
