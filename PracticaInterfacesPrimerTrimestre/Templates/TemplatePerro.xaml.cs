using PracticaInterfacesPrimerTrimestre.Modelo;

namespace PracticaInterfacesPrimerTrimestre.Templates;

public partial class TemplatePerro : ContentPage
{
	public TemplatePerro()
	{
		InitializeComponent();
	}

    private async void AddToFavourites(object sender, EventArgs e)
    {
        //var PerroFavorito = (Dog) 
        var resultado = await DisplayActionSheet("Ayuda", "cancelar", null, "Si", "No");
    }
}