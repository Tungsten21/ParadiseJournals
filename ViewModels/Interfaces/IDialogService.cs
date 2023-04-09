using System.Windows;

namespace ViewModels.Interfaces
{
    public interface IDialogService
    {
        void ShowDialog<TViewModel>(string title, string? windowSize = "Medium") where TViewModel : IViewModel { }
    }
}
