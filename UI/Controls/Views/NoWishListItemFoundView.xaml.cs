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
using UI.Controls.ItemsControls;

namespace UI.Controls.Views
{
    /// <summary>
    /// Interaction logic for NoWishListItemFoundView.xaml
    /// </summary>
    public partial class NoWishListItemFoundView : UserControl
    {

        public static DependencyProperty ItemProperty =
                    DependencyProperty.Register("Item", typeof(string), typeof(NoWishListItemFoundView), new PropertyMetadata(null));

        public string Item
        {
            get { return (string)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        public NoWishListItemFoundView()
        {
            InitializeComponent();
        }
    }
}
