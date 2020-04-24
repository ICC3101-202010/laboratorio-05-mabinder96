using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab5
{
    public class MailSender
    {
        public void OnRegistered(object source, RegisterEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}: \n Gracias por registrarte, {e.Username}!\n Por favor, para poder verificar tu correo, has click en: {e.VerificationLink}\n");
            OnEmailSent();
            Thread.Sleep(2000);
        }

        public void OnPasswordChanged(object source, ChangePasswordEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}:  \n {e.Username}, te notificamos que la contrasena de tu cuenta PlusCorp ha sido cambiada. \n");
            Thread.Sleep(2000);
        }

        //Creo el evento EmailSent
        public delegate void EmailSentHandler(object source, EmailSentArgs args);
        public event EmailSentHandler EmailSent;
        protected virtual void OnEmailSent()
        {
            // Verifica si hay alguien suscrito al evento
            if (EmailSent != null)
            {
                // Engatilla el evento
                EmailSent(this, new EmailSentArgs());
            }
        }
    }        
}