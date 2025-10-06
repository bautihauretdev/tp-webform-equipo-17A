using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("equipo17aprogramacion3@gmail.com", "iirz whnq palr pyxs"); // App passwords
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino)
        {
            email = new MailMessage();
            email.From = new MailAddress("equipo17aprogramacion3@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = "Promo Ganá! Confirmación de cambio de voucher";
            email.IsBodyHtml = true;
            email.Body = "<h2>Hola! Tu inscripción a Promo Ganá! fue exitosa gracias por participar!</h2>";
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                email.Dispose();
            }
        }

    }
}
