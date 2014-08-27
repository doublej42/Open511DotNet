using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Open511DotNet
{
    class JsonSerializeChildren: JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            foreach (var propertyInfo in value.GetType()
                                .GetProperties(
                                        BindingFlags.Public
                                        | BindingFlags.Instance))
            {
                serializer.Serialize(writer, propertyInfo.GetValue(value));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var ret = Activator.CreateInstance(objectType);
            foreach (var propertyInfo in objectType.GetProperties(
                                        BindingFlags.Public
                                        | BindingFlags.Instance))
            {
                var tmp = serializer.Deserialize(reader, propertyInfo.PropertyType);
                propertyInfo.SetValue(ret,tmp);
            }
            return ret;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
