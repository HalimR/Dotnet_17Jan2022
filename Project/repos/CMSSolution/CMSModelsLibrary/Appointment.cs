using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSModelsLibrary
{
    public class Appointment : IComparable
    {
        public int App_Id { get; set; }
        public int Patient_Id { get; set; }
        public string Patient_Name { get; set; }
        public int Doctor_Id { get; set; }
        public string Doctor_Name { get; set; }
        public double App_Price { get; set; }
        public bool App_Status { get; set; }

        public int CompareTo(object obj)
        {
            Appointment app1, app2;
            app1 = this;
            app2 = (Appointment)obj;
            return app1.App_Price.CompareTo(app2.App_Price);
        }
        public void GetAppointmentDetails()
        {
            Console.WriteLine("Please enter patient Id");
            Patient_Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter Doctor Id");
            Doctor_Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the appointment's price");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid entry for price. Please try again...");
            }
            App_Price = price;
            Console.WriteLine("Please enter the appointment's status (true/false)");
            bool status;
            while (!bool.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("Invalid entry for price. Please try again...");
            }
            App_Status = status;
        }
        public override string ToString()
        {
            return "Appointment ID " + App_Id
                + "\nPatient ID " + Patient_Id
                //+ "\nPatient Name " + Patient_Name
                + "\nDoctor ID " + Doctor_Id
                //+ "\nDoctor Name " + Doctor_Name
                + "\nAppointment Price " + App_Price
                + "\nAppointment Status " + App_Status;
        }
    }
}
