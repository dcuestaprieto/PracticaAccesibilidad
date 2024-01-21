using PracticaInterfacesPrimerTrimestre.Modelo;
using Newtonsoft.Json;
using PracticaInterfacesPrimerTrimestre.Plantillas;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PracticaInterfacesPrimerTrimestre.Vista;

public partial class VistaPerros : PlantillaGeneral
{
	public VistaPerros()
	{
		InitializeComponent();
        ListaPerros.ItemsSource = VistaInicio.Dogs;
	}
}