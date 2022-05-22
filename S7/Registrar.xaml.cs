using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Models;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registrar()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();

        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text};
            con.InsertAsync(datosRegistro);
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            DisplayAlert("Alerta", "Agregado Correctamente", "OK");
        }
    }
}