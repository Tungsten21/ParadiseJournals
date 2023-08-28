using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Interfaces
{
    public interface IContextPopupService
    {

        void ShowPopup<TViewModel>(Action? action = null) where TViewModel : IViewModel;

        void ClosePopup();
    }
}
