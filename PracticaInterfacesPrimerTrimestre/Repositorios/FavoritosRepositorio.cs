using PracticaInterfacesPrimerTrimestre.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaInterfacesPrimerTrimestre.Repositorios
{
    public class FavoritosRepositorio
    {
        private readonly string route;
        private readonly SQLiteConnection connection;
        private const string tableName = "favoritos";

        public FavoritosRepositorio(string route)
        {
            this.route = route;
            this.connection = new SQLiteConnection(this.route);
            System.Diagnostics.Debug.WriteLine($"\nRuta de Base de datos: {this.route}\n");
            if (!connection.TableMappings.Any(e => e.MappedType.Name == tableName))
            {
                connection.CreateTable<Favorito>();
            }
        }

        internal static ObservableCollection<Dog> FetchFavouritesDog(string v)
        {
            return null;
        }
    }
}
