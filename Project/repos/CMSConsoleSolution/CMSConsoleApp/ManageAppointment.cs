using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSModelsLibrary;

namespace CMSConsoleApp
{
    public class ManageAppointment
    {
        List<Appointment> apps;

        public ManageAppointment()
        {
            apps = new List<Appointment>();
            apps.Add(new Appointment
            {
                App_Id = 001,
                Pat_Id = 101,
                Doc_Id = 102,
                App_Date = "5/1/2022",
                App_Outstanding = 10.01,
                App_PayStatus = 1
            });

            apps.Add(new Appointment
            {
                App_Id = 002,
                Pat_Id = 101,
                Doc_Id = 102,
                App_Date = "10/1/2022",
                App_Outstanding = 124.61,
                App_PayStatus = 2
            });
        }

        public Appointment GetAppByAppId(int id)
        {
            Appointment app = apps.Find(p => p.App_Id == id);
            return app;
        }

        int GetAppIdFromUser()
        {
            Console.WriteLine("Please enter the Appointment Id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry ID. Please try again...");
            }
            return id;
        }
        public Appointment GetAppByUserIdNAppId(User user, int appId)
        {
            if (user.User_Type == 1) //Patient
            {
                Appointment app = apps.Find(p => p.App_Id == appId && p.Pat_Id == user.User_Id);
                return app;
            }
            else //Doctor
            {
                Appointment app = apps.Find(p => p.App_Id == appId && p.Doc_Id == user.User_Id);
                return app;
            } 
        }

        #region Patient Appointment
        public Appointment GetAppByPatId(int patId)
        {
            Appointment app = apps.Find(p => p.Pat_Id == patId);
            return app;
        }
        public void PrintAppDetailsByPatId(int patId)
        {
            var PatAppointments = apps
                .Where(e => e.Pat_Id == patId);
            foreach (var item in PatAppointments)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Appointment ID : " + item.App_Id);
                Console.WriteLine("Patient ID : " + item.Doc_Id);
                Console.WriteLine("Appointment Date : " + item.App_Date);
                Console.WriteLine("Outstanding Payment : " + item.App_Outstanding);
                Console.WriteLine("Pay Status : " + (item.App_PayStatus == 1 ? "Not Raised" : (item.App_PayStatus == 2 ? "Payment Raised" : "Payment Settled")));
                Console.WriteLine("-------------------------");
            }
        }

        private int GenerateAppId()
        {
            if (apps.Count == 0)
                return 001;
            else
                return (apps.Count+1);
        }

        public void BookAppointmentByPatId(User user)
        {
            Appointment app = new Appointment();
            app.GetAppointmentDetails();
            app.App_Id = GenerateAppId();
            app.Pat_Id = user.User_Id;
            app.App_Outstanding = 0;
            app.App_PayStatus = 1;
            apps.Add(app);
        }

        public void MakePayment(User user)
        {
            int appId = GetAppIdFromUser();
            Appointment app = GetAppByUserIdNAppId(user, appId);
            if (app == null)
            {
                Console.WriteLine("Invalid Id. Cannot edit");
                return;
            }
            Console.WriteLine("The selected Appointment to raise payment request: ");
            PrintAppDetail(app);
            double payment;
            Console.WriteLine("Please enter amount for the patient to pay");
            while (!double.TryParse(Console.ReadLine(), out payment))
            {
                Console.WriteLine("Invalid entry for amount. Please try again...");
            }
            app.App_Outstanding = app.App_Outstanding - payment;
            if (app.App_Outstanding == 0)
                app.App_PayStatus = 3;

            Console.WriteLine("Updated. New Details");
            PrintAppDetail(app);
        }

        #endregion

        #region Doctor Appointment
        public Appointment GetAppByDocId(int docId)
        {
            Appointment app = apps.Find(p => p.Doc_Id == docId);
            return app;
        }

        public void PrintAppDetailsByDocId(int docId)
        {
            var DocAppointments = apps
                .Where(e => e.Doc_Id == docId);
            foreach (var item in DocAppointments)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Appointment ID : " + item.App_Id);
                Console.WriteLine("Patient ID : " + item.Pat_Id);
                Console.WriteLine("Appointment Date : " + item.App_Date);
                Console.WriteLine("-------------------------");
            }
        }

        public void RaisePayment(User user)
        {
            int appId = GetAppIdFromUser();
            Appointment app = GetAppByUserIdNAppId(user, appId);
            if (app == null)
            {
                Console.WriteLine("Invalid Id. Cannot edit");
                return;
            }
            Console.WriteLine("The selected Appointment to raise payment request: ");
            PrintAppDetail(app);
            double payment;
            Console.WriteLine("Please enter amount to pay");
            while (!double.TryParse(Console.ReadLine(), out payment))
            {
                Console.WriteLine("Invalid entry for amount. Please try again...");
            }
            app.App_Outstanding = payment;
            app.App_PayStatus = 2;

            Console.WriteLine("Updated. New Details");
            PrintAppDetail(app);
        }
        #endregion


        private void PrintAppDetail(Appointment item)
        {
            Console.WriteLine("**************************");
            Console.WriteLine(item);
            Console.WriteLine("**************************");
        }
    }
}
