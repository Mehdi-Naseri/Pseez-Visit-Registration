using System.Net;
using System.Net.Mail;
namespace Pseez.VisitRegistration.CommonLibrary
{
    /// <summary>
    /// کلاس کار با ایمیل
    /// </summary>
    public class Email
    {

        /// <summary>
        /// آدرس هاست ایمیل
        /// </summary>
        private const string Host = "webmail.pseez.ir";

        /// <summary>
        /// نام کاربر ایمیل
        /// </summary>
        private const string EmailServerUserName = "itdevelopment@pseez.ir";

        /// <summary>
        /// رمزعبور ایمیل
        /// </summary>
        private const string EmailServerUserPass = "itd95@pseez.ir";

        /// <summary>
        /// ارسال ایمیل
        /// </summary>
        /// <param name="fromMail">از ایمیل</param>
        /// <param name="fromName">نام ارسال کننده</param>
        /// <param name="toMail">به ایمیل</param>
        /// <param name="toName">نام دریافت کننده</param>
        /// <param name="subject">عنوان</param>
        /// <param name="body">توضیحات</param>
        public void SendMail(string fromMail, string fromName, string toMail, string toName, string subject, string body)
        {
            var mail = new MailMessage();
            var smtp = new SmtpClient();
            mail.From = new MailAddress(fromMail, fromName);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true; // This is to enable HTML in your email body
            smtp.Host = Host;
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential(EmailServerUserName, EmailServerUserPass);
            mail.To.Add(new MailAddress(toMail, toName));
            smtp.Send(mail);
        }

        public void SendMailWithYahoo()
        {
            string smtpAddress = "smtp.mail.yahoo.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "mehdi_55555@yahoo.com";
            string password = "mgzidM#952   ";
            string emailTo = "someone@domain.com";
            string subject = "mehdi_55555@yahoo.com";
            string body = "Hello, I'm just writing this to say Hi!";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}
