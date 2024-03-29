﻿using PracticaInterfacesPrimerTrimestre.Repositorios;
namespace PracticaInterfacesPrimerTrimestre;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//creamos la base de datos en el fichero appdata
        string ruta = GetRoute.ReturnRoute("usuarios.db");
        builder.Services.AddSingleton<UsuarioRepositorio>(
            s => ActivatorUtilities.CreateInstance<UsuarioRepositorio>(s, ruta)
        );
        builder.Services.AddSingleton<FavoritosRepositorio>(
            s => ActivatorUtilities.CreateInstance<FavoritosRepositorio>(s, ruta)
        );

        return builder.Build();
	}
}
