using System.ComponentModel;

namespace GestionExpropaciones.Common.Helpers;

public static class EnumHelper
{
    public static string GetEnumDescription<TEnum>(TEnum value)
    {
        var field = value.GetType().GetField(value.ToString());

        var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

        return attribute?.Description ?? value.ToString();
    }

    public static TEnum GetValueFromDescription<TEnum>(string description) where TEnum : Enum
    {
        foreach (var field in typeof(TEnum).GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute && attribute.Description == description)
                return (TEnum)field.GetValue(null);
        }
        throw new ArgumentException($"No se encontró un valor de {typeof(TEnum).Name} con la descripción '{description}'.");
    }
}
