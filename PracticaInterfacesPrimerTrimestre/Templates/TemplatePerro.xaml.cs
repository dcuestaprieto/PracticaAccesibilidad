using PracticaInterfacesPrimerTrimestre.Modelo;
using PracticaInterfacesPrimerTrimestre.Repositorios;
using System.Diagnostics;

namespace PracticaInterfacesPrimerTrimestre.Templates;

public partial class TemplatePerro : ContentPage
{
	public TemplatePerro()
	{
		InitializeComponent();
        
        Dispatcher.Dispatch(() =>
        {
            //Debug.WriteLine($"Valor de NombrePerro.Text: {NombrePerro.Text}");

            ButtonFavourite.Text = App.FavoritosRepositorio.FavouriteExists(NombrePerro.Text)
            ? "Quitar de favoritos"
            : "A�adir a favoritos";
        });
    }

    private void AddToFavourites(object sender, EventArgs e)
    {
        //var PerroFavorito = (Dog) 
        //var resultado = await DisplayActionSheet("Ayuda", "cancelar", null, "Si", "No");
        if (sender is Button clickedButton)
        {
            // Obtener el contexto del bot�n (puede ser un elemento del template)
            var context = clickedButton.BindingContext;

            // Realizar casting al tipo adecuado
            if (context is Dog Perro)
            {
                // Ahora puedes acceder a las propiedades del objeto tipoDeDatos
                string NombrePerroContexto = Perro.Name;
                if(App.FavoritosRepositorio.FavouriteExists(NombrePerroContexto))
                {
                    //Debug.WriteLine($"existe {NombrePerroContexto}");
                    //DisplayAlert("Error a�adiendo favorito", "Se ha producido un error, ya est� a�adido como favorito","Ok");
                    Favorito FavouriteToDelete = App.FavoritosRepositorio.FindFavourite(NombrePerroContexto);
                    App.FavoritosRepositorio.RemoveFavourite(FavouriteToDelete);
                    clickedButton.Text = "A�adir a favoritos";
                }
                else
                {
                    //Debug.WriteLine($"no existe {NombrePerroContexto}");
                    App.FavoritosRepositorio.AddFavourite(NombrePerroContexto);
                    clickedButton.Text = "Quitar de favoritos";
                }
            }
        }
    }
}