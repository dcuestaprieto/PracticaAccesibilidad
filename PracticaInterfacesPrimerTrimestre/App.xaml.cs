using PracticaInterfacesPrimerTrimestre.Modelo;
using PracticaInterfacesPrimerTrimestre.Repositorios;
namespace PracticaInterfacesPrimerTrimestre;

public partial class App : Application
{
	public static UsuarioRepositorio UsuarioRepositorio { get; set; }
    public static FavoritosRepositorio FavoritosRepositorio { get; set; }

    public App(UsuarioRepositorio usuarioRepositorio, FavoritosRepositorio favoritos)
	{
        InitializeComponent();
        UsuarioRepositorio = usuarioRepositorio;
        FavoritosRepositorio = favoritos;
        MainPage = new AppShell();
	}

    private async void CerrarSesion(object sender, EventArgs e)
    {
        //Y borrar el usuario actual del fichero VariablesCompartidas
        VariablesCompartidas.CurrentUser = null;
        await AppShell.Current.GoToAsync(nameof(Vista.VistaInicio));
    }
}
