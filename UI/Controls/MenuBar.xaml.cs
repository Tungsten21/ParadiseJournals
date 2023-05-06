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
using UI.Resources.Animations;

namespace UI.Controls
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        private ColumnDefinition _menuColumn => ColumnToAnimate();

        public MenuBar()
        {
            InitializeComponent();
        }

        private void OnMenuMouseOver(object sender, MouseEventArgs e)
        {
            var duraiton = (new Duration(TimeSpan.FromSeconds(0.5)));
            GridLengthAnimation openAnimation = new
                (duraiton, _menuColumn.Width, new GridLength(0.2, GridUnitType.Star));
            _menuColumn.BeginAnimation(ColumnDefinition.WidthProperty, openAnimation);

        }

        private void OnMenuMouseLeave(object sender, MouseEventArgs e)
        {
            var duraiton = (new Duration(TimeSpan.FromSeconds(0.25)));
            GridLengthAnimation closeAnimation = new
                (duraiton, _menuColumn.Width, new GridLength(0.1, GridUnitType.Star));
            _menuColumn.BeginAnimation(ColumnDefinition.WidthProperty, closeAnimation);
        }

        private ColumnDefinition ColumnToAnimate()
        {
            var parent = VisualTreeHelper.GetParent(this);

            while (parent != null && !(parent is MainWindow))
                parent = VisualTreeHelper.GetParent(parent);

            var mainWindow = parent as MainWindow;
            return mainWindow.MenuBarColumn;
        }
    }
}
