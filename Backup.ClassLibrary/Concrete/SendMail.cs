using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Backup.ClassLibrary.Concrete
{
    public static class SendMail
    {
        private static string Smtp = "mail.runbox.com";     //"smtp.gmail.com";//"mail.privateemail.com";
        private static string usermailAddress = "support@9t.com";   //"manopchayangkoor@gmail.com";//"smtpout@addlink.com";
        private static string passmailAddress = "Ninet890!";    //"Joeraka281036";//"Addlink123!";


        public static bool Mail(string ToMail, string Subject, string Body, string backup_support = "BackUpBackOffice Support")
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = Smtp,
                    Port = 587,//587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(usermailAddress, passmailAddress)
                };

                using (var message = new MailMessage(new MailAddress(usermailAddress, backup_support), new MailAddress(ToMail))
                {
                    Subject = Subject,
                    Body = Body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                return true;

            }
            catch { return false; }
        }

        public static bool MailAttachments(string ToMail, string Subject, string Body, string HTMLAttachments, string backup_support = "BackUpBackOffice Support")
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = Smtp,
                    Port = 587,//587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(usermailAddress, passmailAddress)
                };

                HtmlToPdf converter = new HtmlToPdf();
                PdfDocument doc = converter.ConvertHtmlString(HTMLAttachments);

                // save pdf document 
                byte[] pdf = doc.Save();

                // close pdf document 
                doc.Close();

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] bytes = pdf.ToArray();
                    memoryStream.Close();

                    MailMessage mm = new MailMessage(new MailAddress(usermailAddress, backup_support), new MailAddress(ToMail));
                    mm.Subject = Subject;
                    mm.Body = Body;
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Invoice.pdf"));
                    mm.IsBodyHtml = true;
                    smtp.Send(mm);
                }

                return true;
            }
            catch { return false; }
        }
    }
}
