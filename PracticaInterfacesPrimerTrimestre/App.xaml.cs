using PracticaInterfacesPrimerTrimestre.Modelo;
using PracticaInterfacesPrimerTrimestre.Repositorios;
using System.Diagnostics;

namespace PracticaInterfacesPrimerTrimestre;

public partial class App : Application
{
	public static UsuarioRepositorio UsuarioRepositorio { get; set; }
    public static FavoritosRepositorio FavoritosRepositorio { get; set; }

    public App(UsuarioRepositorio usuarioRepositorio, FavoritosRepositorio favoritosRepositorio)
	{
        InitializeComponent();
        UsuarioRepositorio = usuarioRepositorio;
        FavoritosRepositorio = favoritosRepositorio;
        MainPage = new AppShell();
	}

    private async void CerrarSesion(object sender, EventArgs e)
    {
        //Y borrar el usuario actual del fichero VariablesCompartidas
        VariablesCompartidas.CurrentUser = "";
        await AppShell.Current.GoToAsync(nameof(Vista.VistaInicio));
    }
    private async void CambiarVistaFavoritos(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(Vista.VistaFavoritos));
    }

    private async void CambiarVista(object sender, EventArgs e)
    {
        if (sender is Button clickedButton)
        {
            switch (clickedButton.Text)
            {
                case "Ver Todos":
                    Debug.WriteLine("has clickado en ver todos");
                    await AppShell.Current.GoToAsync(nameof(Vista.VistaPerros));
                    break;
                case "Ver Favoritos":
                    Debug.WriteLine("has clickado en favoritos");
                    break;
                default: break;
                 
            }

            
        }
    }
}
