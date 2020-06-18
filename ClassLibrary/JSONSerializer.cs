using System;
using System.Linq;
using System.Globalization;
using System.Xml.Serialization;
using System.Text;
using System.Reflection;



namespace ClassLibrary
{
    internal sealed class JSONSerializer
    {
        StringBuilder result = new StringBuilder();

        internal string Serializer(object obj)
        {
            // result.AppendLine();
            result.Append("{");
            // get the type of object that will be serialized, name can be extractd from the type itself.
            var objType = obj.GetType();

            Console.WriteLine("OBJECT TYPE NAME: " + objType.Name);
            //iteration over the object properites and adding them to a list
            IList<PropertyInfo> props = new List<PropertyInfo>(objType.GetProperties());
            foreach (var prop in props)
            {
                var propValue = prop.GetValue(obj, null);
                if (prop.PropertyType.Name.Equals("Int32"))
                {

                    // result.AppendLine();
                    result.Append('"' + prop.Name + '"' + ":" + propValue);
                    result.Append(",");
                }
                else if (prop.PropertyType.Name.Equals("String"))
                {

                    result.Append('"' + prop.Name + '"' + ":" + '"' + propValue + '"');
                    result.Append(",");
                }
                else if (prop.PropertyType.Name.Equals("String[]"))
                {
                    String[] array = (String[])prop.GetValue(obj);
                    string str = ConvertString(array);
                    result.Append('"' + prop.Name + '"' + ":" + str);
                    //result.Append(",");
                }
            }
            //result.AppendLine();
            result.Append("}");
            return result.ToString();
        }

        internal string ConvertString(string[] str)
        {
            var output = new StringBuilder();
            if (str.Length.Equals(0))
                return "";
            else if (str.Length.Equals(1))
                return "[" + '"' + str[0] + '"' + "]";
            else
                for (int index = 0; index < str.Length; index++)
                    if (index == 0)
                        output.Append("[" + '"' + str[index] + '"' + ",");
                    else if (index == str.Length - 1)
                        output.Append('"' + str[str.Length - 1] + '"' + "]");
                    else
                        output.Append('"' + str[index] + '"' + ",");
            return output.ToString();
        }


        //not used
        internal void ConvertToJSON(object obj)
        {

            if (obj == null || obj is DBNull)
                result.Append("null");

            else if (obj is string || obj is char)
                ConvertString(obj.ToString());

            else if (
                obj is int || obj is long ||
                obj is decimal ||
                obj is byte || obj is short ||
                obj is sbyte || obj is ushort ||
                obj is uint || obj is ulong
            )
                result.Append(((IConvertible)obj).ToString(NumberFormatInfo.InvariantInfo));

        }
    }
}
