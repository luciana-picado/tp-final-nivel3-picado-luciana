using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
            server.Credentials = new NetworkCredential("prog.prueba.pokedex@gmail.com", "jhwngourlqxpddow");
            server.Port = 587;
            server.EnableSsl = true;
            server.Host = "smtp.gmail.com";
        }
        public void armarCorreo(string emailDestino, string asunto, string mensaje)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@pokedexweb.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.Body = mensaje;
        }
        public void enviarMail()
        {
            try
            {
                server.Send(email);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
