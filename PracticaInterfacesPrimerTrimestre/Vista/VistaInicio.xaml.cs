using PracticaInterfacesPrimerTrimestre.Modelo;
using Newtonsoft.Json;
using PracticaInterfacesPrimerTrimestre.Plantillas;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System;

namespace PracticaInterfacesPrimerTrimestre.Vista;

public partial class VistaInicio : ContentPage
{
    public static ObservableCollection<Dog> Dogs { get; set; }

    public VistaInicio()
	{
		InitializeComponent();
        consulta2();
        VariablesCompartidas.CurrentUser = "";
        VariablesCompartidas.FavouritesDogList = new ObservableCollection<Dog>();
        VariablesCompartidas.FavouritesList = new ObservableCollection<Favorito>();
        ValidarUsuario();
    }

    private void ValidarUsuario()
    {
        Debug.WriteLine("usuario actual: "+VariablesCompartidas.CurrentUser);
        if (string.IsNullOrEmpty(VariablesCompartidas.CurrentUser))
        {
            DisplayAlert("titulo", "mensaje", "Cancelar");
        }
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

    private void CopyPasteMenu(object sender, EventArgs e)
    {
        if (sender is Label ClickedLabel)
        {
            switch (ClickedLabel.Text)
            {
                case "Nombre Usuario:":
                    MostrarMenu(EntryUsername);
                    break;
                case "Contraseña:":
                    MostrarMenu(EntryPassword);
                    break;
            }
        }
    }

    private async void MostrarMenu(Entry EntryVar)
    {
        var resultado = await DisplayActionSheet("Acciones", "Cancelar", null, "Copiar", "Pegar", "Cortar");
        switch (resultado)
        {
            case "Copiar":
                await Clipboard.SetTextAsync(EntryVar.Text);
                break;
            case "Pegar":
                EntryVar.Text = await Clipboard.GetTextAsync();
                break;
            case "Cortar":
                await Clipboard.SetTextAsync(EntryVar.Text);
                EntryVar.Text = string.Empty;
                break;
        }
    }
}

