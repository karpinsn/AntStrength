using AntStrength.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace AntStrength.Common
{
  public class LiftingSet2StringConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      string liftingSetString = "";
      var set = value as LiftingSet;
      if (null != set)
      {
        liftingSetString = set.Reps.ToString() + " - " + set.Weight.ToString();
      }

      return liftingSetString;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      throw new NotImplementedException();
    }
  }
}
