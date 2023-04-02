using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    public class MailService
    {
        public static void Send(string receiver,string password= "Finalodevi2022", string body="Test Mesajı",string subject="Email Testi",string sender= "Efinalodevi2022@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port=587,
                EnableSsl=false,
                DeliveryMethod=SmtpDeliveryMethod.Network,
                UseDefaultCredentials=false,
                Credentials=new NetworkCredential(senderEmail.Address,password)
            };

            using (MailMessage message = new MailMessage(senderEmail, receiverEmail) { // Garbage Collection'ını kullandık 

            Subject=subject,
            Body=body,

            
            })
            {
                smtp.Send(message);
            }
            /*
              
             
             */


        }
    }
}
