using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using S7.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
[assembly: Xamarin.Forms.Dependency(typeof(SqliteCliente))]

namespace S7.Droid
{
    class SqliteCliente : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //se crea la base de datos
            var path = Path.Combine(documentPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}