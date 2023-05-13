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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UI.Resources.Animations;
using ViewModels.Controls;

namespace UI.Controls
{
    /// <summary>
    /// Interaction logic for JournalsMenuItem.xaml
    /// </summary>
    public partial class JournalsMenuItem : UserControl
    {
        private DispatcherTimer _mouseOverRecorder;
        private MenuBar _menuBar;

        private MenuBarViewModel _menuBarViewModel => (MenuBarViewModel)DataContext;

        public JournalsMenuItem()
        {
            InitializeComponent();
        }

        //private void OnMenuMouseOver(object sender, MouseEventArgs e)
        //{
        //    var duraiton = (new Duration(TimeSpan.FromSeconds(0.5)));
        //    GridLengthAnimation openAnimation = new
        //        (duraiton, new GridLength(0.2, GridUnitType.Star));

        //    _mouseOverRecorder.Start();
        //    _mouseOverRecorder.Tick += (object? sender, EventArgs e) =>
        //    {
        //        _menuColumn.BeginAnimation(ColumnDefinition.WidthProperty, openAnimation);
        //        _menuBarViewModel.IsMenuExpanded = true;
        //        _mouseOverRecorder.Stop();
        //    };

        //}

        private void OnItemMouseEnter(object sender, MouseEventArgs e)
        {
            //var duration = new Duration(TimeSpan.FromSeconds(0.2));
            //GridLengthAnimation openAnimation = new
            //    (duration, contentContainer.Height, new GridLength(0.8, GridUnitType.Star));
            //contentContainer.BeginAnimation(RowDefinition.HeightProperty, openAnimation);
            //_menuBar.ItemRow2.Height = new GridLength(1, GridUnitType.Star);

            Grid item = (Grid)sender;
            ContextMenu contextMenu = (ContextMenu)Resources["CustomContextMenu"];
            contextMenu.PlacementTarget = item;
            contextMenu.IsOpen = true;
        }

        private void OnItemMouseLeave(object sender, MouseEventArgs e)
        {
            //var duration = new Duration(TimeSpan.FromSeconds(0.2));
            //GridLengthAnimation closeAnimation = new
            //    (duration, new GridLength(0.8, GridUnitType.Star), new GridLength(0));
            //contentContainer.BeginAnimation(RowDefinition.HeightProperty, closeAnimation);
            //_menuBar.ItemRow2.Height = GridLength.Auto;
            ContextMenu contextMenu = (ContextMenu)Resources["CustomContextMenu"];
            contextMenu.IsOpen = false;
        }

        private void JournalsItem_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(this);

            while (parent != null && !(parent is MenuBar))
                parent = VisualTreeHelper.GetParent(parent);

            if (parent != null && parent is MenuBar menu)
                _menuBar = menu;

        }

    }
}
