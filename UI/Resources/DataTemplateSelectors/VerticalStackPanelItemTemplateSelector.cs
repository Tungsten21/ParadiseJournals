using ViewModels.Items;
using System.Windows;
using System.Windows.Controls;
using Common.Exceptions;
using UI.Controls.ItemsControls.ItemTemplates;

namespace UI.Resources.DataTemplateSelectors
{
    public class VerticalStackPanelItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElementFactory frameworkElementFactory = new();
            DataTemplate dataTemplate = new();

            switch (item)
            {
                case JournalViewModel _:
                    frameworkElementFactory.Type = typeof(JournalItemTemplate);
                    break;
                case WishListViewModel _:
                    frameworkElementFactory.Type = typeof(WishListItemTemplate);
                    break;
                case WishListAccommodationViewModel _:
                    frameworkElementFactory.Type = typeof(WishListViewModel);
                    break;
                case WishListLocationViewModel _:
                    frameworkElementFactory.Type = typeof(WishListViewModel);
                    break;
                case WishListNoteViewModel _:
                    frameworkElementFactory.Type = typeof(WishListViewModel);
                    break;
            }

            dataTemplate.VisualTree = frameworkElementFactory;

            if (dataTemplate.VisualTree != null)
                return dataTemplate;

            throw new ResourceNotFoundException("Date Template for item view model " + item.ToString() + "not found");
        }
    }
}
