using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOPSApplication
{
    class Customer
    {
        //public int num1; //variable

        //public int Num1 //properties
        //{
        //    get { return num1; }
        //    set { num1 = value; }
        //}

        public int Id { get; set; }
        public string Name { get; set; }

        string phone;

        public string Phone {
            get
            {
                string masked = "XXXXXXX" + phone.Substring(6, 4);
                return masked;
            }
            //set => phone = value;
            set
            {
                phone = value;
            }
        } 
    }
}
