using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TpQuestionnaireManager.Converters;

public class CollectionEmptyOrNullConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var collection = value as ICollection;
        if (collection == null || collection.Count == 0)
            return Visibility.Visible;
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
