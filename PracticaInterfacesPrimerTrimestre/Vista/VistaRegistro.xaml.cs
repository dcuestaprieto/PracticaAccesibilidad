namespace PracticaInterfacesPrimerTrimestre.Vista;

public partial class VistaRegistro : ContentPage
{
	public VistaRegistro()
	{
		InitializeComponent();
	}

    private void CopyPasteMenu(object sender, EventArgs e)
    {
        if (sender is Label ClickedLabel)
        {
            switch (ClickedLabel.Text)
            {
                case "Nombre Completo:":
                    MostrarMenu(EntryFullName);
                    break;
                case "Username:":
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