using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSModelsLibrary;

namespace CMSFEConsoleApp
{
    class ManageMenu
    {
        Appointment[] appointments;
        public Appointment this[int index]
        {
            get { return appointments[index]; }
            set { appointments[index] = value; }
        }
        public ManageMenu()
        {
            appointments = new Appointment[3];
        }
        public ManageMenu(int size)
        {
            appointments = new Appointment[size];
        }
        public void AddAppointment()
        {
            for (int i = 0; i < appointments.Length; i++)
            {
                int id = GenerateId();
                appointments[i] = new Appointment();
                appointments[i].App_Id = id;
                appointments[i].GetAppointmentDetails();
            }
        }

        private int GenerateId()
        {
            if (appointments[0] == null)
                return 101;
            else
            {
                for (int i = 0; i < appointments.Length; i++)
                {
                    if (appointments[i] == null)
                        return 101 + i;
                }
            }
            return 0;
        }

        public Appointment GetAppointmentById(int id)
        {
            Appointment appointment = null;
            for (int i = 0; i < appointments.Length; i++)
            {
                if (appointments[i].App_Id == id)
                    appointment = appointments[i];
            }
            return appointment;
        }

        public void EditAppointmentPrice()
        {
            int id = GetIdFromUser();
            Appointment appointment = GetAppointmentById(id);
            if (appointment == null)
            {
                Console.WriteLine("Invalid Id. Cannot edit");
                return;
            }
            Console.WriteLine("The appointment for you have chosen to edit price");
            PrintAppointment(appointment);
            double price;
            Console.WriteLine("Please enter the new price");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid entry for price. Please try again...");
            }
            appointment.App_Price = price;
            Console.WriteLine("Updated. New Details");
            PrintAppointment(appointment);
        }

        //public void RemovePizza()
        //{
        //    int id = GetIdFromUser();
        //    int idx = -1;
        //    for (int i = 0; i < pizzas.Length; i++)
        //    {
        //        if (pizzas[i].Id == id)
        //            idx = i;
        //    }
        //    Pizza pizza = GetPizzaById(id);
        //    if (idx != -1)
        //    {
        //        Console.WriteLine("Do you want to delete the following Pizza???");
        //        PrintPizza(pizza);
        //        string check = Console.ReadLine();
        //        if (check == "yes")
        //            pizzas[idx] = null;
        //    }
        //}

        int GetIdFromUser()
        {
            Console.WriteLine("Please enter the appointment id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry ID. Please try again...");
            }
            return id;
        }

        public void PrintAppointments()
        {
            Array.Sort(appointments);
            foreach (var item in appointments)
            {
                if (item != null)
                    PrintAppointment(item);
            }
        }

        public void PrintSingleAppointmentByID()
        {
            int id = GetIdFromUser();
            Appointment appointment = GetAppointmentById(id);
            if (appointment != null)
            {
                PrintAppointment(appointment);
            }
            else
                Console.WriteLine("No such appointment");
        }

        private void PrintAppointment(Appointment item)
        {
            Console.WriteLine("**************************");
            Console.WriteLine(item);
            Console.WriteLine("**************************");
        }
    }
}
