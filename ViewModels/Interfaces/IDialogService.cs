namespace ViewModels.Interfaces
{
    public interface IDialogService
    {
        IViewModel CurrentViewModel { get; set; }

        void ShowDialog<TViewModel>(string title, string? windowSize = "Medium") where TViewModel : IViewModel;

        Tuple<int, int> mapWindowSize(string windowSize);
    }
}
