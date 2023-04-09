using System.Windows;

namespace ViewModels.Interfaces
{
    public interface IDialogService
    {
        void ShowDialog<TViewModel>(string title) where TViewModel : IViewModel { }
    }
}
