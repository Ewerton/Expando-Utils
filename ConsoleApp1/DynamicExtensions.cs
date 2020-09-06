using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class DynamicNull
    {
        public static bool ExistePropriedade(ExpandoObject dynamicObject, string nomePropriedade)
        {
            if (ObjectEhDynamic(dynamicObject))
            {
                IDictionary<string, object> propertyValues = dynamicObject;

                foreach (var property in propertyValues.Keys)
                {
                    if (property == nomePropriedade)
                        return true;
                    var values = propertyValues[property];
                    if (ObjectEhDynamic(values))
                    {
                        ExistePropriedade((ExpandoObject)values, nomePropriedade);
                    }
                    //Console.WriteLine(String.Format("{0} : {1}", property, propertyValues[property]));
                }
            }
            else
            {
                throw new Exception("O Objeto não é um Dynamic");
            }

            return false;
            //if (ObjectEhDynamic(dynamicObject))
            //{
            //    KeyValuePair<string, object> kvp = (KeyValuePair<string, object>)dynamicObject;
            //    if (kvp.Value != null)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    throw new Exception("O Objeto não é um Dynamic");
            //}

            //foreach (var key in kvp.Keys)
            //    yield return new KeyValuePair<string, object>(key, this.Properties[key]);

        }

        private static bool ObjectEhDynamic(object obj)
        {
            try
            {
                return (obj is ExpandoObject);
                // KeyValuePair<string, object> kvp = (KeyValuePair<string, object>)obj;
                //return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static bool ObjectEhDynamic(ExpandoObject obj)
        {
            try
            {
                return (obj is ExpandoObject);
                // KeyValuePair<string, object> kvp = (KeyValuePair<string, object>)obj;
                //return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static void Percorrer(ExpandoObject obj)
        {


            //if (destination is IEnumerable && source is IEnumerable)
            //{
            //    var dest_enumerator = (destination as IEnumerable).GetEnumerator();
            //    var src_enumerator = (source as IEnumerable).GetEnumerator();
            //    while (dest_enumerator.MoveNext() && src_enumerator.MoveNext())
            //        dest_enumerator.Current.Assign(src_enumerator.Current);
            //}
            //else
            //{
            //    var destProperties = destination.GetType().GetProperties();
            //    foreach (var sourceProperty in source.GetType().GetProperties())
            //    {
            //        foreach (var destProperty in destProperties)
            //        {
            //            if (destProperty.Name == sourceProperty.Name && destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
            //            {
            //                destProperty.SetValue(destination, sourceProperty.GetValue(source, new object[] { }), new object[] { });
            //                break;
            //            }
            //        }
            //    }
            //}
        }
    }
}
