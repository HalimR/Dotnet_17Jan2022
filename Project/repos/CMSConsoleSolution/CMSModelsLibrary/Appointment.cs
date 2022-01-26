using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSModelsLibrary
{
    public class Appointment 
    {
        public int App_Id { get; set; }
        public int Pat_Id { get; set; }
        public int Doc_Id { get; set; }
        public string App_Date { get; set; }
        public double App_Outstanding { get; set; }
        public int App_PayStatus { get; set; }
        //1- Not Raised, 2- Raised 3- Payed

        public Appointment()
        {

        }

        public void GetAppointmentDetails()
        {
            Console.WriteLine("Please enter the Doc Id");
            Doc_Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter Appointment Date");
            App_Date = Console.ReadLine();
        }

        public override string ToString()
        {
            return "Appointment ID: " + App_Id
                + "\nPatient ID: " + Pat_Id
                + "\nDoctor ID: " + Doc_Id

                + "\nAppointment Date: " + App_Date
                + "\nAppointment Payment: " + App_Outstanding
                + "\nPay Status: " + (App_PayStatus == 1 ? "Not Raised" : (App_PayStatus == 2 ? "Payment Raised" : "Payment Settled"));
        }
    }
}
