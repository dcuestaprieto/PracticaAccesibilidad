using PracticaInterfacesPrimerTrimestre.Modelo;
using Newtonsoft.Json;
using PracticaInterfacesPrimerTrimestre.Plantillas;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PracticaInterfacesPrimerTrimestre.Vista;

public partial class VistaInicio : ContentPage
{
    public static ObservableCollection<Dog> Dogs { get; set; }

    public VistaInicio()
	{
		InitializeComponent();
        consulta2();
	}
    public static async void consulta2()
    {
        string url = "https://gist.githubusercontent.com/arturschaefer/abf8f94bcff14ace1b88c7977d651a74/raw/4c329530a24fe2e4b21029ed7a687a767aa9622a/breed_list.json";
        HttpClient client = new HttpClient();
        string respuesta = await client.GetStringAsync(url);
        Dogs = JsonConvert.DeserializeObject<ObservableCollection<Dog>>(respuesta);
        foreach (Dog album in Dogs)
        {
            Debug.WriteLine($"Id: {album.Name}, titulo: {album.Image.Url}");
        }



    }
}

