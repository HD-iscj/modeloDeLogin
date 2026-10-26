using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeTPFinal
{
    internal class Usuario
    {
        public string Nombre { get; }

        public string PassWord { get; }
    
        public Usuario(string nombre, string contraseña)
        {
            Nombre = nombre;
            PassWord = contraseña;
        }

        public Usuario()
        {
            Nombre = "";
            PassWord = "";
        }

        public override string ToString()
        {
            return $"Persona: {Nombre}, Edad: {PassWord}";
        }

    }

}
