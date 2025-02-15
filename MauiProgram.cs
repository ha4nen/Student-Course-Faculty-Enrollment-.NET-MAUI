﻿using exam.DataTransactions;
using Microsoft.Extensions.Logging;

namespace exam
{
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "Project.db");

            builder.Services.AddSingleton(S => ActivatorUtilities.CreateInstance<DBTrans>(S, _dbPath));

            return builder.Build();
        }
    }
}
