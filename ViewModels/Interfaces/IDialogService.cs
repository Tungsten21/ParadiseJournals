namespace ViewModels.Interfaces
{
    public interface IDialogService
    {
        IViewModel ViewModel { get; set; }

        void ShowDialog<TViewModel>(string title, string? windowSize = "Medium") where TViewModel : IViewModel;

        Tuple<int, int> mapWindowSize(string windowSize);
    }
}
