using PracticaInterfacesPrimerTrimestre.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
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

        public void AddFavourite(string RazaPerro)
        {
            connection.Insert(new Favorito { DogId = RazaPerro, UserId = VariablesCompartidas.CurrentUser});
        }
        public Boolean FavouriteExists(string RazaPerro)
        {
            var favorito = connection.Table<Favorito>().Where(favorito => 
                favorito.DogId.Equals(RazaPerro) && favorito.UserId.Equals(VariablesCompartidas.CurrentUser)
            ).FirstOrDefault();


            return favorito != null;
        }

        public void RemoveFavourite(Favorito favorito)
        {
            connection.Delete(favorito);
        }

        public Favorito FindFavourite(string DogId)
        {
            return connection.Table<Favorito>().Where(favorito => favorito.DogId.Equals(DogId) && favorito.UserId.Equals(VariablesCompartidas.CurrentUser)).FirstOrDefault();
        }

        public ObservableCollection<Favorito> GetFavouritesByUser()
        {
            List<Favorito> favourites = connection.Table<Favorito>().Where(favorito => favorito.UserId.Equals(VariablesCompartidas.CurrentUser)).ToList();
            return new ObservableCollection<Favorito>(favourites);
        }
    }
}
