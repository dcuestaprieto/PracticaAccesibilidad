using API.Modelo;
using Newtonsoft.Json;
using PracticaInterfacesPrimerTrimestre.Modelo;
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
        //GetDogs();
	}

    public ObservableCollection<Dog> GetDogs()
    {
        string url = "https://gist.githubusercontent.com/arturschaefer/abf8f94bcff14ace1b88c7977d651a74/raw/4c329530a24fe2e4b21029ed7a687a767aa9622a/breed_list.json";
        HttpClient client = new HttpClient();
        string respuesta = client.GetStringAsync(url).Result.ToString();
        ObservableCollection<Dog> misPerros = JsonConvert.DeserializeObject<ObservableCollection<Dog>>(respuesta);
        //ListaPerros.ItemsSource = misPerros;
        foreach (Dog item in misPerros)
        {
            Debug.WriteLine($"aaaaaaaaaaaaaaaaaaaId: {item.Name}, titulo: {item.Image.Url}");
        }

        return misPerros;

    }
}