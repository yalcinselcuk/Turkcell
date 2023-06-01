using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public class Reporter
    {
        private readonly ISender sender;
        public Reporter(ISender sender) { this.sender = sender; }
        public void SendReport()
        {
            //MailSender sender = new MailSender();
            sender.Send();
        }
    }
    public interface ISender
    {
        void Send();
    }
    public class MailSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("Mail ile gonderildi");
        }
    }
    public class WhatsappSender : ISender 
    {
        public void Send()
        {
            Console.WriteLine("Wp ile gonderildi");
        }
    }
    public class TelegramSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("TelegramSender ile gonderildi");
        }
    }
}
