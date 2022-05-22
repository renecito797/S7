using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class consultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;
        //private ObservableCollection<Estudiante> listaUsuarios_ItemsSource;

        public consultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            get();
        }

        public async void get()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(resultado);
            listaUsuarios.ItemsSource = tablaEstudiante;
        }

        private void listaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            int id = Convert.ToInt32(item);
            var nombre = obj.Nombre.ToString();
            string nombre1= nombre.ToString();
            Navigation.PushAsync(new Elemento(id, nombre1));
        }
    }
}