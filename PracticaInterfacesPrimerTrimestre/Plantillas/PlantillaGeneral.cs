namespace PracticaInterfacesPrimerTrimestre.Plantillas;

public class PlantillaGeneral : ContentPage
{
	public PlantillaGeneral()
	{
		var plantilla = Application.Current.Resources["plantilla"] as ControlTemplate;
		ControlTemplate = plantilla;
	}
}