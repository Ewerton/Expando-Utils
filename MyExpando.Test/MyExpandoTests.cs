using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ewerton.Utilities;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace MyExpando.Test
{
    [TestClass]
    public class MyExpandoTests
    {
        private CustomDynamic GetTestDynamic()
        {
            dynamic dinRoot = new CustomDynamic();// ExpandoObject();
            dynamic DinLevel1 = new CustomDynamic();
            dynamic DinLevel2 = new CustomDynamic();
            dynamic DinLevel3 = new CustomDynamic();

            dinRoot.ContainsProperty("prop");

            dinRoot.DinLevel1 = DinLevel1;
            dinRoot.DinLevel1.DinLevel2 = DinLevel2;
            //dinRoot.DinLevel1.DinLevel2.DinLevel3 = DinLevel3; // You can comment this line to test

            return dinRoot;
        }

        [TestMethod]
        public void MyExpando_NotNullExpando()
        {
            dynamic dinRoot = null;
            if (dinRoot == null)
            {
                Console.WriteLine("Its Nulll!");
            }

            dinRoot = new CustomDynamic();// ExpandoObject();
            if (dinRoot != null)
            {
                Console.WriteLine("Its Not Null!");
            }

            dynamic DinLevel1 = new CustomDynamic();
            if (dinRoot.DinLevel1 == null)
            {
                Console.WriteLine("Its Null!");
            }

            dinRoot.DinLevel1 = DinLevel1;
            if (dinRoot.DinLevel1 != null)
            {
                Console.WriteLine("Its Not Null!");
            }

            if (dinRoot.DinLevel1.SomeNull == null)
            {
                Console.WriteLine("Its Null works!");
            }

            if (dinRoot.DinLevel1?.SomeNull == null)
            {
                Console.WriteLine("Its Null works!");
            }

            dynamic DinLevel2 = new CustomDynamic();
            dynamic DinLevel3 = new CustomDynamic();
            dinRoot.DinLevel1.DinLevel2 = DinLevel2;


            if (dinRoot.DinLevel1.DinLevel2.DinLevel3 == null)
            {
                Console.WriteLine("Its Null works!");
            }

            //Should raise and exception because DinLevel3 is null right now
            //if (dinRoot.DinLevel1.DinLevel2.DinLevel3.SomeNull == null)
            //{
            //    Console.WriteLine("Its Null works!");
            //}

            if (dinRoot.DinLevel1?.SomeNull == null)
            {
                Console.WriteLine("Its Null works!");
            }

            if (dinRoot.DinLevel1?.DinLevel2?.DinLevel3 == null)
            {
                Console.WriteLine("Its Null works!");
            }

            dinRoot.DinLevel1.DinLevel2.DinLevel3 = DinLevel3; // You can comment this line to test
            if (dinRoot.DinLevel1?.DinLevel2?.DinLevel3 != null)
            {
                Console.WriteLine("Its Not works!");
            }

            if (dinRoot.DinLevel1?.DinLevel2?.DinLevel3.SomeNull == null)
            {
                Console.WriteLine("Its Null works!");
            }

            DinLevel3.SomeList = new List<string>() { "Item1", "Item2" };

            if (dinRoot.DinLevel1?.DinLevel2?.DinLevel3?.SomeList != null)
            {
                Console.WriteLine("Its Null works!");
            }

            if (dinRoot.DinLevel1?.DinLevel2?.DinLevel3?.SomeList[0] != null)
            {
                Console.WriteLine("Its Null works!");
            }


            dinRoot.NovaProp = "sdsd";
            dinRoot.ContainsProperty("NovaProp", true);
            dinRoot.ContainsProperty("DinLevel3", true);
            dinRoot.ContainsProperty("SomeList", true);

            CustomDynamic.ContainsProperty(dinRoot, "DinLevel3", false);
            CustomDynamic.ContainsProperty(dinRoot, "DinLevel3", true);

            dinRoot.RandomProp = "Some random prop";

            CustomDynamic.ContainsProperty(dinRoot, "RandomProp", false);
            CustomDynamic.ContainsProperty(dinRoot, "RandomProp", true);
        }



        //private IEnumerable<string> GetPropertiesNames(object target, bool dynamicOnly = false)
        //{
        //    var tList = new List<string>();
        //    if (!dynamicOnly)
        //    {
        //        tList.AddRange(target.GetType().GetProperties().Select(it => it.Name));
        //    }

        //    var tTarget = target as IDynamicMetaObjectProvider;
        //    if (tTarget != null)
        //    {
        //        tList.AddRange(tTarget.GetMetaObject(Expression.Constant(tTarget)).GetDynamicMemberNames());
        //    }
        //    //else
        //    //{

        //    //    if (ComObjectType != null && ComObjectType.IsInstanceOfType(target) && ComBinder.IsAvailable)
        //    //    {
        //    //        tList.AddRange(ComBinder.GetDynamicDataMemberNames(target));
        //    //    }
        //    //}
        //    return tList;
        //}


        [TestMethod]
        public void MyExpando_NotNullExpandoMultipleObjects()
        {
        }



        [TestMethod]
        public void MyExpando_NullPropertyInTheStart()
        {
        }

        [TestMethod]
        public void MyExpando_NullPropertyInTheMiddle()
        {
        }

        [TestMethod]
        public void MyExpando_NullPropertyInTheEnd()
        {
        }


        [TestMethod]
        public void MyExpando_NullExpandoInTheStart()
        {
        }

        [TestMethod]
        public void MyExpando_NullExpandoInTheMiddle()
        {
        }

        [TestMethod]
        public void MyExpando_NullExpandoInTheEnd()
        {
        }







    }
}
