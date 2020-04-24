using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class User //Creo la clase User para verificar el Mail
    {

        //Creo el evento EmailVerified
        public delegate void EmailVerifiedHandler(object source, EmailSentArgs args);
        public event EmailVerifiedHandler EmailVerified;
        protected virtual void OnEmailVerified()
        {
            // Verifica si hay alguien suscrito al evento
            if (EmailVerified != null)
            {
                // Engatilla el evento
                EmailVerified(this, new EmailSentArgs());
            }
        }

        //Creo el método OnEmailSent que le da la opción al usuario de verificar altiro el Mail
        //Si el usuario selecciona sí, se dispara el evento OnEmailVerified 
        public void OnEmailSent(object source, EmailSentArgs e)
        {
            Console.WriteLine("¿Desea verificar su cuenta?\nOpción 1: Sí\nOpción 2: No\n");
            string answer = Console.ReadLine();
            if (answer == "1" || answer == "Sí") OnEmailVerified();
        }
    }
}
