﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.Items;

namespace UI.Controls.ItemsControls.ItemTemplates
{
    /// <summary>
    /// Interaction logic for JournalItemTemplate.xaml
    /// </summary>
    public partial class JournalItemTemplate : UserControl
    {
        public JournalItemTemplate()
        {
            InitializeComponent();
        }

        private void OnItemClick(object sender, MouseButtonEventArgs e)
        {
            var dataContext = DataContext as JournalViewModel;
            dataContext?.ItemClicked();
        }
    }
}
