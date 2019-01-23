using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    [System.ComponentModel.TypeConverter(typeof(SeverityEnumConverter))]
    public enum TypeEvents
    {
        InRepare,
        OutRepare,
        StartCreate,
        FinishCreate,
        InBuild,
        OutBuild,
        InCheck,
        OutCheck,
        ErrorCheck
    }

    public class SeverityEnumConverter : System.ComponentModel.TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                System.Resources.ResourceManager manager = new System.Resources.ResourceManager("SeverityEnumConverter", this.GetType().Assembly);
                string strValue = manager.GetString(value.ToString(), culture);
                return (strValue != null) ? strValue : value.ToString();
            }
                return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
