using PracticaInterfacesPrimerTrimestre.Plantillas;

namespace PracticaInterfacesPrimerTrimestre.Vista;

public partial class VistaPerros : PlantillaGeneral
{
	public VistaPerros()
	{
		InitializeComponent();
		ListaPerros.ItemsSource = VistaInicio.Dogs;
	}
}