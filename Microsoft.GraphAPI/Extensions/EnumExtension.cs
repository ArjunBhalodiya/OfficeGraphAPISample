using System.ComponentModel;
using System.Reflection;

namespace Microsoft.GraphAPI.Messages.Extensions
{
    internal static class EnumExtension
    {
        public static string GetEnumDescription<T>(this T value)
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidEnumArgumentException("T must be an enum type");
            }

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            DescriptionAttribute[]
            attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}

