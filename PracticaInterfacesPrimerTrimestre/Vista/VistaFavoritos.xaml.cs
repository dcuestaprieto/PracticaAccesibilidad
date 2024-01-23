using PracticaInterfacesPrimerTrimestre.Modelo;
using PracticaInterfacesPrimerTrimestre.Plantillas;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PracticaInterfacesPrimerTrimestre.Vista;

public partial class VistaFavoritos : PlantillaGeneral
{
	public VistaFavoritos()
	{
		InitializeComponent();
		GetFavouritesDog();
        ListaPerros.ItemsSource = VariablesCompartidas.FavouritesDogList;
	}

    private void GetFavouritesDog()
    {
        //borro todos los favoritos ya creados
        VariablesCompartidas.FavouritesList.Clear();
        VariablesCompartidas.FavouritesDogList.Clear();
        //actualizo la lista de favoritos
        VariablesCompartidas.FavouritesList = App.FavoritosRepositorio.GetFavouritesByUser();
        foreach (Dog dog in VistaInicio.Dogs)
        {
            //Debug.WriteLine(VariablesCompartidas.FavouritesList.Count);
            Favorito fav = App.FavoritosRepositorio.FindFavourite(dog.Name);
            if (fav != null)
            {
                Debug.WriteLine(fav.DogId);
                VariablesCompartidas.FavouritesDogList.Add(dog);
            }
        }
        Debug.WriteLine(VariablesCompartidas.FavouritesDogList.Count);
    }
}