using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ClinicApp.Converters
{
    public  class DateToAgeConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                var currentDate = DateTime.Today;
                var age = currentDate.Year - date.Year;
                if (date.Date > currentDate.AddYears(-age)) age--;

                return age;
            }

            return Binding.DoNothing;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
