using System;
using System.Collections;
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

namespace UI.Controls.ItemsControls
{
    /// <summary>
    /// Interaction logic for VerticalItemsStackPanelTemplate.xaml
    /// </summary>
    public partial class VerticalItemsStackPanelTemplate : UserControl
    {
        public static DependencyProperty ItemsSourceProperty =
                    DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(VerticalItemsStackPanelTemplate), new PropertyMetadata(null));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static DependencyProperty TitleProperty =
                    DependencyProperty.Register("Title", typeof(string), typeof(VerticalItemsStackPanelTemplate), new PropertyMetadata(null));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }



        public VerticalItemsStackPanelTemplate()
        {
            InitializeComponent();
        }
    }
}
