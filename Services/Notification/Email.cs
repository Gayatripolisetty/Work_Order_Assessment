using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services.Notification
{
    class Email : INotification
    {
        public void sendNotification()
        {
            Console.WriteLine("email has been sent");
        }
    }
}
