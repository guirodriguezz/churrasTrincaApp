using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace churrasTrincaApp.Models.Enums
{
    public class StringValueAttribute : Attribute
    {
        private string _valor;
        private char v;

        public StringValueAttribute(string str)
        {
            _valor = str;
        }

        public StringValueAttribute(char v)
        {
            this.v = v;
        }

        public string Valor
        {
            get { return _valor; }
        }

    }

    public static class EnumHelper
    {
        public static string ToStringValue(this Enum value)
        {
            string result = string.Empty;

            var enumType = value.GetType();
            var field = enumType.GetRuntimeField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(StringValueAttribute), false).ToArray();

            if (attributes.Length > 0)
            {
                result = attributes.Length == 0
                ? value.ToString()
                : ((StringValueAttribute)attributes[0]).Valor;
            }
            else { }
            return attributes.Length == 0
                ? value.ToString()
                : ((StringValueAttribute)attributes[0]).Valor;
        }



        public static T toEnumValue<T>(this string StringValue) where T : struct
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("Tipo deve ser um Enum.");
            }

            if (string.IsNullOrEmpty(StringValue))
            {
                throw new ArgumentException("String deve conter algum valor");
            }

            Array array = Enum.GetValues(typeof(T));
            var list = new List<T>(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                list.Add((T)array.GetValue(i));
            }

            var dict = list.Select(
                v => new
                {
                    Value = v,
                    Description =
                        v.GetType().GetRuntimeField(v.ToString()).GetCustomAttributes(typeof(StringValueAttribute), false).Count() > 0
                        ? ((StringValueAttribute)v.GetType().GetRuntimeField(v.ToString()).GetCustomAttributes(typeof(StringValueAttribute), false).FirstOrDefault()).Valor
                        : v.ToString()
                }
            ).ToDictionary(x => x.Description, x => x.Value);

            if (dict.Where(x => x.Key.Equals(StringValue.Trim())).Count() == 0)
            {
                throw new ArgumentException(string.Format("Não existe valor no Enum com essa descrição.{0}No Enum({1}) verifique os atributos {2}"
                    , Environment.NewLine, typeof(T).Name, "[StringValue()]"));
            }
            return (T)dict[StringValue.Trim()];
        }
    }
}
