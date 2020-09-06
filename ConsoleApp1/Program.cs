using Ewerton.Utilities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClsLevel1 levelRoot = new ClsLevel1();
            if (levelRoot?.ClsLevel2?.ClsLevel3 != null)
            {
                // will enter here you you do not comment the content of the ClsLevel1 constructor
            }

          


            dynamic dinRoot = new CustomDynamic();
            dynamic DinLevel1 = new CustomDynamic();
            dynamic DinLevel2 = new CustomDynamic();
            dynamic DinLevel3 = new CustomDynamic();

            dinRoot.DinLevel1 = DinLevel1;
            dinRoot.DinLevel1.DinLevel2 = DinLevel2;
           // dinRoot.DinLevel1.DinLevel2.DinLevel3 = DinLevel3; // You can comment this line to test

            dynamic foo = new CustomDynamic();
            if (foo.Boo?.Lol ?? true)
            {
                Console.WriteLine("It works!");
            }

            if (dinRoot?.DinLevel1?.DinLevel2?.DinLevel3 == null)
            {
                Console.WriteLine("There is something null!");
            }
            else
            {
                Console.WriteLine("Nothing null in the chain!");
            }

            //Console.ReadLine();


            //if (!dinRoot.IsNull(p => p.DinLevel1.DinLevel2))
            //{
            //    //Nothing is null
            //}

            if (dinRoot?.DinLevel1?.DinLevel2?.DinLevel3 != null)
            {
                // Obviously it will raise an exception because the DinLevel3 does not exists
            }

           

        }





    }

    public class ClsLevel1
    {
        public ClsLevel2 ClsLevel2 { get; set; }
        public ClsLevel1()
        {
            //this.ClsLevel2 = new ClsLevel2(); // You can comment this line to test
        }        
    }

    public class ClsLevel2
    {
        public ClsLevel3 ClsLevel3 { get; set; }
        public ClsLevel2()
        {
            this.ClsLevel3 = new ClsLevel3();
        }       
    }

    public class ClsLevel3
    {
        // No child
        public ClsLevel3()
        {
        }
    }

}
