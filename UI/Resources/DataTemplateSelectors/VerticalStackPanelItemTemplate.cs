using ViewModels.Items;
using System.Windows;
using System.Windows.Controls;
using Common.Exceptions;
using UI.Controls.ItemsControls.ItemTemplates;

namespace UI.Resources.DataTemplateSelectors
{
    public class VerticalStackPanelItemTemplate : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElementFactory frameworkElementFactory = new();
            DataTemplate dataTemplate = new();

            if (item.GetType() == typeof(JournalViewModel))
               frameworkElementFactory.Type = typeof(JournalItemTemplate);

            if (item.GetType() == typeof(WishListViewModel))
                frameworkElementFactory.Type = typeof(WishListItemTemplate);

            dataTemplate.VisualTree = frameworkElementFactory;

            if (dataTemplate.VisualTree != null)
                return dataTemplate;

            throw new ResourceNotFoundException("Date Template for item view model " + item.ToString() + "not found");
        }
    }
}
