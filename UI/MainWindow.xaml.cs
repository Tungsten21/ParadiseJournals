﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Controls;
using UI.Resources.Animations;
using ViewModels;
using ViewModels.Interfaces;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ColumnDefinition MenuBarColumn => menuColumn;

        public MainWindow(MainWindowViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }

        private void CloseContextPopup(object sender, MouseButtonEventArgs e)
        {
            var dataContext = (MainWindowViewModel)DataContext;

            if (!Popup.IsMouseOver)
            {
                dataContext.CloseContextPopupOnLostFocusCommand.Execute(null);
            }


        }
    }
}
