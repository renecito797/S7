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
    public partial class Elemento : ContentPage
    {
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> Delete1;
        IEnumerable<Estudiante> Update1;
        public int idSeleccionado;
        public Elemento(int id, string nombre)
        {
            InitializeComponent();
            txtNombre.Text = nombre;
            con = DependencyService.Get<Database>().GetConnection();//
            idSeleccionado = id;//           
        }                    

        public static IEnumerable<Estudiante> delete(SQLiteConnection db, int ID)
        {
            return db.Query<Estudiante>("Delete from Estudiante where Id = ?", ID);
        }

        public static IEnumerable<Estudiante> update(SQLiteConnection db, string nombre, string usuario, string contrasena, int ID)
        {
            return db.Query<Estudiante>("Update Estudiante set Nombre=?, Usuario = ?, Contrasena = ? where Id = ?", nombre, usuario, contrasena, ID);
        }

    private void btnActuaizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasepath);
                Update1 = update(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, idSeleccionado);
                Navigation.PushAsync(new consultaRegistro());
            }

            catch (Exception ex)
            {

            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasepath);
                Delete1 = delete(db, idSeleccionado);
                //DisplayAlert("Alerta", "Se elimino correctamente", "OK");
                Navigation.PushAsync(new consultaRegistro());
            }

            catch (Exception ex)
            {
                    throw;
                    //DisplayAlert("Alerta", "ERROR", +ex.Message, "OK");
            }

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new consultaRegistro());
        }
    }
}