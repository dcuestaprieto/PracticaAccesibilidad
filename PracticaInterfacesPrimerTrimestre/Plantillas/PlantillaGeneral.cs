namespace PracticaInterfacesPrimerTrimestre.Plantillas;

public class PlantillaGeneral : ContentPage
{
	public PlantillaGeneral()
	{
		var plantilla = Application.Current.Resources["MenuNavegacion"] as ControlTemplate;
		ControlTemplate = plantilla;
	}

    protected override bool OnBackButtonPressed()
    {
        /*
         * para todos los elementos que hereden de mi PlantillaGeneral, no voy a permitir que echen para atras con el boton
         * y que deban usar el menu de navegación proporcionado
         */
        return true;
    }
}