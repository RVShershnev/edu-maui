﻿using Edu.MauiForBeginners.ViewModels;
using Microsoft.Extensions.Logging;

namespace Edu.MauiForBeginners;

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

        // builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<DetailPage>();
        builder.Services.AddSingleton<DetailViewModel>();

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
