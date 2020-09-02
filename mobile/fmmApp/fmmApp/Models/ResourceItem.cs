using Newtonsoft.Json;
using System;
using System.Reflection;

namespace fmmApp.Models
{
    public abstract class ResourceItem<T>
    {
        public string Id { get; set; }

        [JsonIgnore]
        public static string ResourcePath
        {
            get
            {
                return typeof(T).GetCustomAttribute<ResourcePathAttribute>().Value;
            }
        }

        [JsonIgnore]
        public string ResourcePathWithId
        {
            get
            {
                return CreatePathWithId(Id);
            }
        }

        public static string CreatePathWithId(string id)
        {
            return $"{ResourcePath}/{id}";
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    sealed class ResourcePathAttribute : Attribute
    {
        public ResourcePathAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}
