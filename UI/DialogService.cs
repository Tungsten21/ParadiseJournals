using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using UI;
using UI.Dialogs;
using ViewModels.Dialogs;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class DialogService : IDialogService
    {
        public void ShowDialog<TViewModel>(string title) where TViewModel : IViewModel
        {
            TViewModel viewModel;
            var serviceProvider = ((App)Application.Current).serviceProvider;

            try
            {
                viewModel = serviceProvider.GetService<TViewModel>();
            }
            catch (Exception ex) //catch exception if view model hasnt been registered with service provider...
            {
                throw(ex);
            }

            BaseDialog baseDialogWindow = new BaseDialog(); //Change to new base dialog type...

            BaseDialogViewModel dataContext = baseDialogWindow.DataContext as BaseDialogViewModel;
            dataContext.ViewModel = viewModel;
            
            baseDialogWindow.Title = title;
            baseDialogWindow.Show();
        }
    }
}
