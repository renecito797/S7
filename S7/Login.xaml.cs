using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using S7.Models;
using System.IO;

namespace S7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario = ? and Contrasena= ?", usuario, contrasena);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documentpath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count() > 0)
                {
                    //DisplayAlert("Alerta", "usuario incorrecto", "OK");//revisar
                    Navigation.PushAsync(new consultaRegistro());
                }
                
                else
                {
                    DisplayAlert("Alerta", "Verifique su usuario/contraseña", "OK");
                }
            }

            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }

        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());
        }
    }
}