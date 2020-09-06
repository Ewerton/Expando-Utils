using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ewerton.Utilities
{
    public class CustomDynamic : DynamicObject
    {
        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = binder.Name.ToLower();
            result = _dictionary.ContainsKey(name) ? _dictionary[name] : null;
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name.ToLower()] = value;
            return true;
        }

        public bool ContainsProperty(string propName, bool lookInChilds = false)
        {
            var name = propName.ToLower();

            // Procura não não dynamic
            if (this.GetType().GetProperties().Where(it => it.Name.ToLower() == name).Count() > 0)
                return true;

            if (_dictionary.ContainsKey(name))
            {
                return true;
            }

            if (lookInChilds)
            {
                foreach (var item in _dictionary)
                {
                    return ContainsProperty((CustomDynamic)item.Value, name, lookInChilds);
                }
            }

            return false;
        }


        public static bool ContainsProperty(dynamic obj, string propName, bool lookInChilds = false)
        {
            // Just a shortcut to the "real" method
            return obj.ContainsProperty(propName, lookInChilds);
        }

        private IEnumerable<string> GetPropertiesNames(object target, bool dynamicOnly = false)
        {
            var tList = new List<string>();
            if (!dynamicOnly)
            {
                tList.AddRange(target.GetType().GetProperties().Select(it => it.Name));
            }


            var tTarget = target as IDynamicMetaObjectProvider;
            if (tTarget != null)
            {
                tList.AddRange(_dictionary.Keys);
                // tList.AddRange(tTarget.GetMetaObject(Expression.Constant(tTarget)).GetDynamicMemberNames());
            }
            //else
            //{

            //    if (ComObjectType != null && ComObjectType.IsInstanceOfType(target) && ComBinder.IsAvailable)
            //    {
            //        tList.AddRange(ComBinder.GetDynamicDataMemberNames(target));
            //    }
            //}
            return tList;
        }
    }
}
