using MyCampusUI.Enums;
using System.ComponentModel;
using System.Reflection;

namespace MyCampusUI.Extensions;

public static class FileTransferEnumExtension
{
    public static string ToMimeString(this FileTransferEnum mime)
    {
        Type type = mime.GetType();
        string? name = Enum.GetName(type, mime);
        if (name != null)
        {
            FieldInfo? field = type.GetField(name);
            if (field != null)
            {
                DescriptionAttribute? attr =
                       Attribute.GetCustomAttribute(field,
                         typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }
        }
        return mime.ToString();
    }
}
