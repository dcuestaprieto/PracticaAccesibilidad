using PracticaInterfacesPrimerTrimestre.Modelo;
using PracticaInterfacesPrimerTrimestre.Repositorios;
using System.Collections.ObjectModel;

namespace PracticaInterfacesPrimerTrimestre.Templates;

public partial class TemplateFavorito : ContentView
{
	public ObservableCollection<Dog> FavouritesDogs { get; set; }
	public TemplateFavorito()
	{
		InitializeComponent();
		FavouritesDogs = FavoritosRepositorio.FetchFavouritesDog("");
	}
}