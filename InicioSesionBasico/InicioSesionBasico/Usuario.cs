using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InicioSesionBasico
{
    internal class Usuario
    {
        public String Login { get; set; }
        public String Password { get; set; }

        public Usuario(string login, string passwd) {
            this.Login = login;
            this.Password = passwd;
        }

        public override String ToString()
        {
            return "Login: " + this.Login + " Password: " + this.Password;
        }
    }
}
