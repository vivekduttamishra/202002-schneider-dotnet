using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04
{
    class Program
    {
        static void Main(string[] args)
        {
            DatePublisher pub = new DatePublisher();
            pub.SendUpdate();

            pub.Subscribers += DatePrinter; //date printer subscribes
            pub.Subscribers += TimePrinter; //time pritner subscribes

            pub.SendUpdate();

            pub.Subscribers -= DatePrinter; //unsubscribe
            pub.Subscribers += EventCountdown; //subscribe

            pub.SendUpdate();

            //problem#1 --> what if I dont' use += just =
           // pub.Subscribers = EventCountdown;  //not allowed

            pub.SendUpdate();

            //problem#2 ---> Fake update: not sent by publisher but by 3rd pary
            //pub.Subscribers(new DateTime(2020, 8, 1));



        }

        static void DatePrinter(DateTime date)
        {
            Console.WriteLine("Date Printer: "+date.ToLongDateString());
        }

        static void TimePrinter(DateTime date)
        {
            Console.WriteLine("Time Printer: " + date.ToLongTimeString());
        }

        static void EventCountdown(DateTime date)
        {
            var independenceDay = new DateTime(2020, 8, 15);
            var diff = independenceDay - date;
            Console.WriteLine("{0} days to next independence day",diff.Days);
        }
    }
}
