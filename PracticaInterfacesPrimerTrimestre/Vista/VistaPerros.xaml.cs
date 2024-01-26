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
        MiPicker.SelectedIndex = 0;
	}

    private void ItemPickerChanged(object sender, EventArgs e)
    {
        ListaPerros.ItemsSource = VistaInicio.Dogs;
    }

    private void BuscarPerros(object sender, EventArgs e)
    {
        string FiltroBusqueda = MiPicker.SelectedItem as string;
        if (!string.IsNullOrEmpty(Search.Text) && !string.IsNullOrEmpty(FiltroBusqueda))
        {
            //Debug.WriteLine(Search.Text);
            CambiarPerros(Search.Text, FiltroBusqueda);
        }
        else
        {
            ListaPerros.ItemsSource = VistaInicio.Dogs;
        }

    }

    private void CambiarPerros(string DogData, string filtroBusqueda)
    {
        ObservableCollection<Dog> nuevosPerros = new ObservableCollection<Dog>();
        foreach (Dog dog in VistaInicio.Dogs)
        {
            if (filtroBusqueda.Equals("Raza"))
            {
                if (dog.Name.ToLower().Contains(DogData.ToLower()))
                {
                    Debug.WriteLine(dog.Name);
                    nuevosPerros.Add(dog);
                }
            }else if (filtroBusqueda.Equals("Origen"))
            {
                if (dog.Origin.ToLower().Contains(DogData.ToLower()))
                {
                    Debug.WriteLine(dog.Name);
                    nuevosPerros.Add(dog);
                }
            }
        }
        ListaPerros.ItemsSource = nuevosPerros;
    }
}