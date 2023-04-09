using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using UI;
using UI.Dialogs;
using ViewModels.Dialogs;
using ViewModels.Interfaces;
using Common.Enums;

namespace ViewModels
{
    public class DialogService : IDialogService
    {
        public void ShowDialog<TViewModel>(string title, string? windowSize = "Medium") where TViewModel : IViewModel
        {
            TViewModel viewModel;
            var serviceProvider = ((App)Application.Current).serviceProvider;

            try
            {
                viewModel = serviceProvider.GetService<TViewModel>();
            }
            catch (Exception ex) //catch exception if view model hasnt been registered with service provider...
            {
                throw (ex);
            }

            BaseDialog baseDialogWindow = serviceProvider.GetService<BaseDialog>();

            BaseDialogViewModel dataContext = baseDialogWindow.DataContext as BaseDialogViewModel;
            dataContext.ViewModel = viewModel;

            baseDialogWindow.Title = title;

            var windowSizes = mapWindowSize(windowSize);

            baseDialogWindow.Width = windowSizes.Item1;
            baseDialogWindow.Height = windowSizes.Item2;

            baseDialogWindow.Show();
        }

        private Tuple<int, int> mapWindowSize(string windowSize)
        {
            if (windowSize == "Small")
                return Tuple.Create(((int)DialogSize.SmallWidth), ((int)DialogSize.SmallHeight));

            if (windowSize == "Medium")
                return Tuple.Create(((int)DialogSize.MediumWidth), ((int)DialogSize.MediumHeight));

            if (windowSize == "Large")
                return Tuple.Create(((int)DialogSize.SmallWidth), ((int)DialogSize.LargeHeight));

            throw new Exception("Invaid size type provided...");

        }
    }
}
