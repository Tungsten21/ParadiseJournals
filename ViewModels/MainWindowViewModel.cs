﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Navigation;

namespace ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {

        //Properties
        private IServiceProvider _serviceProvider;
        private IMessenger _messenger;

        [ObservableProperty]
        private IViewModel _currentViewModel;

        //Constructors
        public MainWindowViewModel(IServiceProvider serviceProvider, IMessenger messenger)
        {
            _serviceProvider = serviceProvider;
            _messenger = messenger;
            _currentViewModel = _serviceProvider.GetService<EntryViewModel>();

            _messenger.Register<NavigationMessage<IViewModel>>(this, (r, m) =>
            {
                CurrentViewModel = (IViewModel) _serviceProvider.GetService(m.ViewModel.GetType());
            });
        }
        //Commands 

        //Methods
    }
}
