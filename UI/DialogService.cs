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
        private IServiceProvider _serviceProvider;

        public IViewModel CurrentViewModel { get; set; }

        public DialogService(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public void ShowDialog<TViewModel>(string title, string? windowSize = "Medium") where TViewModel : IViewModel
        {
            try
            {
                CurrentViewModel = _serviceProvider.GetService<TViewModel>();
            }
            catch (Exception ex) //catch exception if view model hasnt been registered with service provider...
            {
                throw (ex);
            }

            BaseDialog baseDialogWindow = _serviceProvider.GetService<BaseDialog>();

            BaseDialogViewModel dataContext = baseDialogWindow.DataContext as BaseDialogViewModel;
            dataContext.ViewModel = CurrentViewModel;

            baseDialogWindow.Title = title;
            var windowSizes = mapWindowSize(windowSize);
            baseDialogWindow.Width = windowSizes.Item1;
            baseDialogWindow.Height = windowSizes.Item2;

            if(CurrentViewModel is IClosable vm) 
                vm.CloseWindow = () => baseDialogWindow.Close();
               
            baseDialogWindow.Show();
        }

        private Tuple<int, int> mapWindowSize(string windowSize)
        {
            if (windowSize == "Small")
                return Tuple.Create((int)DialogSize.SmallWidth, (int)DialogSize.SmallHeight);

            if (windowSize == "Medium")
                return Tuple.Create((int)DialogSize.MediumWidth, (int)DialogSize.MediumHeight);

            if (windowSize == "Large")
                return Tuple.Create((int)DialogSize.LargeWidth, (int)DialogSize.LargeHeight);

            throw new Exception("Invaid size type provided...");

        }

        Tuple<int, int> IDialogService.mapWindowSize(string windowSize)
        {
            throw new NotImplementedException();
        }
    }
}
