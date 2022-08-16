using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Services.Notification;

namespace WebApp
{
    class Program 
    {
        static void Main(string[] args)
        {
            string options;
            Services.WorkOrderDao woa = new Services.WorkOrderDao();
            Services.TechnicianDao dao = new Services.TechnicianDao();
            DataTable dt;
            Boolean flag = true;
            Console.WriteLine("Select type of notification");
            string nt = Console.ReadLine();
            INotification notification = null;
            if (nt.Equals("email"))
            {
                notification = new Email();
            }
            else if (nt.Equals("SMS"))
            {
                notification = new SMS();
            }
            else
            {
                notification = new Email();
            }

            while (flag)
            {
                Console.WriteLine("Select from below options");
                options = Console.ReadLine();


                switch (options)
                {
                    case "1":
                        Console.WriteLine("Get All Work Orders based on date");
                        dt = woa.getWorkOrderDao_Date("2012-01-09 00:00:00.000");
                        notification.sendNotification();
                        Console.WriteLine(dt);
                        break;
                    case "2":
                        Console.WriteLine("Get All Work Orders based on Registration Number");
                        dt = woa.getWorkOrderDao_Regd_ID("1210315");
                        notification.sendNotification();
                        Console.WriteLine(dt);
                        break;
                    case "3":
                        Console.WriteLine("Creating Technicians");
                        System.Guid guid = System.Guid.NewGuid();
                        String id = guid.ToString();
                        dao.Technician("Tejesh","Vuddagiri","Y", id.Substring(0,8));
                        notification.sendNotification();
                        break;
                    case "4":
                        Console.WriteLine("Assigning a technician to a Work");
                       // dao.AssignWorkToTechnician(Reference_ID, Registration_ID);
                        notification.sendNotification();
                        break;
                    case "5":
                        Console.WriteLine("Creating a work Order");
                       // woa.CreateWorkOrder(Reference_Id, Place, DOI, Registration_No);
                        break;
                    case "6":
                        Console.WriteLine("ihateyou");
                        break;
                    case "7":
                        Console.WriteLine("jkl");
                        break;
                    case "8":
                        Console.WriteLine("mno");
                        break;
                    case "9":
                        flag = false;
                        Console.WriteLine("mno");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
    }
}
