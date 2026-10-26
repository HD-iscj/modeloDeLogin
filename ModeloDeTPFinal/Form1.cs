using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloDeTPFinal
{
    public partial class Login : Form
    {
        public string ruta = "C:\\Users\\C3\\Desktop\\unArchivo.txt"; 
        List<Usuario> listaDeUsuarios = new List<Usuario>();

        public Login()
        {
            InitializeComponent();
            //leer archivos de usuarios
            try
            {
                listaDeUsuarios = leerBDUsuariosTxt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextWriter archivo = new StreamWriter(ruta);
                archivo.Close();
            }
            //instanciar otras ventanas



        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonIniciar_Click(object sender, EventArgs e)
        {
            if (usuarioLogueado(textBoxUsuario.Text.Trim(), textBoxContraseña.Text.Trim()) != null)
            {
                MessageBox.Show("inicio de sesion correcto");
            }
            else
            {
                MessageBox.Show("Credenciales invalidas");
            }
        }

        private List<Usuario> leerBDUsuariosTxt()
        {
            var lista = new List<Usuario>();
            using (TextReader lector = new StreamReader(ruta))
            {
                string linea;

                while ((linea = lector.ReadLine()) != null)
                {
                    // Divide la línea por el delimitador (caracter de la coma ',')
                    string[] partes = linea.Split(',');

                    if (partes.Length == 2) // Aseguramos que hay suficientes partes
                    {
                        var usuario = new Usuario
                        (
                            partes[0].Trim(),
                            partes[1].Trim()
                        );
                        lista.Add(usuario);
                    }
                }
                return lista;
            }
        }

        private Usuario usuarioLogueado (string n, string c)
        {
            Usuario usuarioValido = null;

            foreach (Usuario u in listaDeUsuarios)
            {
                if (u.Nombre == n && u.PassWord == c)
                {
                    
                    usuarioValido = u;
                    break; 
                }
            }

            return usuarioValido;
        }
    }
}
