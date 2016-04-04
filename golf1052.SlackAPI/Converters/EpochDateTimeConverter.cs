using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace golf1052.SlackAPI.Converters
{
    public class EpochDateTimeConverter : DateTimeConverterBase
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
         
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }
            else
            {
                decimal value = decimal.Parse(reader.Value.ToString(), CultureInfo.InvariantCulture);
                DateTime time = new DateTime(621355968000000000 + (long)(value * 10000000m)).ToLocalTime();
                return time;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - epoch).TotalSeconds.ToString());
        }
    }
}
