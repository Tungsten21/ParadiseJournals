using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Shapes;
using ViewModels.Dialogs;
using ViewModels.Interfaces;

namespace UI.Dialogs
{
    /// <summary>
    /// Interaction logic for BaseDialog.xaml
    /// </summary>
    public partial class BaseDialog : Window
    {
        public BaseDialog()
        {
            InitializeComponent();
            DataContext = ((App)Application.Current).serviceProvider.GetService<BaseDialogViewModel>();
        }
    }
}
