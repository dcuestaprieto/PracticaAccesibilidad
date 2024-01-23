using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaInterfacesPrimerTrimestre.Modelo
{
    public static class VariablesCompartidas
    {
        public static string CurrentUser { get; set; } = "";
        public static ObservableCollection<Favorito> FavouritesList { get; set; }
        public static ObservableCollection<Dog> FavouritesDogList { get; set; }
    }
}
