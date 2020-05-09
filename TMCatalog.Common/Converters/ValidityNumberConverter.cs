using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TMCatalog.Common.Converters
{
    public class ValidityNumberConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values?.Length == 2 && values[0] is DateTime && values[1] is short)
            {
                double days = System.Convert.ToDouble(values[1]);
                return (short)values[1] > 0 ? ((DateTime)values[0]).AddDays(days).Date.ToString("yyyy/MM/dd") : "No validity limit";
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
