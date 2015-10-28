using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Projects
{
    public class MailMessageHelper
    {
        
        public static void CreateMessage(string destEmail,string subject,string body,string server = "smtp.exmail.qq.com")
        {

            MailMessage message = new MailMessage("barry@qhfinance.org", destEmail, subject, body);

            SmtpClient client = new SmtpClient(server);
            client.Credentials = new NetworkCredential("barry@qhfinance.org", "abcde1234");
            try
            {
                client.Send(message);
            }
            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                message.Dispose();
            }
        }
    }
}
