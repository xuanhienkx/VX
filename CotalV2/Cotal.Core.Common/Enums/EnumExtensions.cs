using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Cotal.Core.Common.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            MemberInfo member = enumType.GetMember(enumValue)[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false).ToArray();
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        // this returns a simple generic list of display names
        public static List<string> GetDisplayList<T>() where T : struct, IConvertible
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            return Enum.GetValues(typeof(T)).Cast<Enum>().Select<Enum, string>(v => v.GetDisplayName()).ToList();
        }

        // for Angular, a key-value pairing is necessary, but this will return a hash that cannot be ordered:
        public static Dictionary<int, string> GetDisplayDictionary<T>() where T : struct, IConvertible
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            var dict = (from e in Enum.GetValues(typeof(T)).Cast<Enum>()
                        let i = Convert.ToInt32(e)
                        orderby i
                        select new
                        {
                            key = i,
                            value = e.GetDisplayName()
                        });
            return dict.ToDictionary(d => d.key, d => d.value);
        }
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            var type = enumValue.GetType();
            var typeInfo = type.GetTypeInfo();
            var memberInfo = typeInfo.GetMember(enumValue.ToString());
            var attributes = memberInfo[0].GetCustomAttributes<TAttribute>();
            var attribute = attributes.FirstOrDefault();
            return attribute;
        }

        // this returns a simple object that is easily [de]serialized and ordered
        public static Dictionary<int, string> GetObjectList<T>() where T : struct, IConvertible
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            var dict = (from e in Enum.GetValues(typeof(T)).Cast<Enum>()
                        let i = Convert.ToInt32(e)
                        orderby i
                        select new
                        {
                            key = i,
                            value = e.ToString()
                        });
            return dict.ToDictionary(d => d.key, d => d.value);
        }

        // this returns a simple object that is easily [de]serialized and ordered
        public static Dictionary<int, string> GetObjectListByType(Type type)
        {
            if (!type.GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            var dict = (from e in Enum.GetValues(type).Cast<Enum>()
                        let i = Convert.ToInt32(e)
                        orderby i
                        select new
                        {
                            key = i,
                            value = e.ToString()
                        });
            return dict.ToDictionary(d => d.key, d => d.value);
        }
        public static List<SimpleJsObj> GetObjectListByType(string name)
        {
            var type = ResoleType(name);
            if (!type.GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            var dict = (from e in Enum.GetValues(type).Cast<Enum>()
                        let i = Convert.ToInt32(e)
                        orderby i
                        select new SimpleJsObj
                        {
                            Key = i,
                            Value = e.ToString()
                        });
            return dict.ToList();
        }

        public static Type ResoleType(string name)
        {
            var intstansType = typeof(ActionEnum);
            var type = intstansType.GetTypeInfo().Assembly.GetTypes().First(t => t.Name == name);
            return type;
        }

        public class SimpleJsObj
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }

    }
}