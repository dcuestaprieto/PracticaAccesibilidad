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

    private void BuscarPerros(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Search.Text))
        {
            //Debug.WriteLine(Search.Text);
            CambiarPerros(Search.Text);
        }
        else
        {
            ListaPerros.ItemsSource = VistaInicio.Dogs;
        }

    }

    private void CambiarPerros(string NombrePerro)
    {
        ObservableCollection<Dog> nuevosPerros = new ObservableCollection<Dog>();
        foreach (Dog dog in VistaInicio.Dogs)
        {
            if (dog.Name.ToLower().Contains(NombrePerro.ToLower()))
            {
                Debug.WriteLine(dog.Name);
                nuevosPerros.Add(dog);
            }
        }
        ListaPerros.ItemsSource = nuevosPerros;
    }
}