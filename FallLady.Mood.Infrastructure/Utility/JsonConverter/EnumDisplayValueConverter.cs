namespace FallLady.Mood.Infrastructure.Utility.JsonConverter
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Newtonsoft.Json;

    public class EnumDisplayValueConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer,
                                        object value,
                                        JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                var @enum = (Enum)value;
                writer.WriteValue(GetEnumDisplayValue(@enum));
            }
        }

        public override object ReadJson(JsonReader reader,
                                         Type objectType,
                                         object existingValue,
                                         JsonSerializer serializer)
        {
            return Enum.Parse(objectType,
                               GetDisplayValueToEnumValue(objectType, reader.Value?.ToString()),
                               true);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public static string GetEnumDisplayValue(Enum enumName)
        {
            if (enumName == null)
                return "-";
            var type = (Type)enumName.GetType();
            var field = type.GetField(enumName.ToString());
            var display = ((DisplayAttribute[])field?.GetCustomAttributes(typeof(DisplayAttribute), false))?.FirstOrDefault();
            return display != null
                ? display.Name
                : enumName.ToString();
        }

        public static string GetDisplayValueToEnumValue(Type type, string displayName)
        {
            var fields = type.GetFields().ToList();
            foreach (var fieldInfo in fields)
            {
                var display = ((DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                if (display == null ||
                     displayName != display.GetName())
                    continue;
                return fieldInfo.Name;
            }

            return displayName;
        }
    }
}
