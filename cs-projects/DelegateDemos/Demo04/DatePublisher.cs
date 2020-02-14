using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04
{
    public delegate void DateSubscriber(DateTime date);

    public class DatePublisher
    {
        public event DateSubscriber Subscribers;
        int i = 0;
        public void SendUpdate()
        {
            var date = DateTime.Now;
            i++;
            Console.WriteLine("sending update#{0}",i);
            if(Subscribers!=null)
                Subscribers(date);

            Console.WriteLine();
        }
    }
}
