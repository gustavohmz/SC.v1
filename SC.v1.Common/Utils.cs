using System.ComponentModel;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SC.v1.Common.Utils
{
    public static class Utils
    {

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)Enum.Parse(typeof(T), field.Name);
                }
                else
                {
                    if (field.Name == description)
                        return (T)Enum.Parse(typeof(T), field.Name);
                }
            }

            throw new ArgumentException("Description not found for the given enum value.");
        }



    }
}
