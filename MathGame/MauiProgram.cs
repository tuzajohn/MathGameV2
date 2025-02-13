using FluentValidation;
using MathGame.src.Application.Interfaces;
using MathGame.src.Infrastructure.Common.Behavior;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using SQLite;
using System.Reflection;

namespace MathGame
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            var flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Memory;

            builder.Services.AddSingleton(s => new SQLiteAsyncConnection(Constants.DatabasePath,openFlags: flags));
            builder.Services.AddSingleton(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //RegisterValidators(builder.Services, Assembly.Load("MyApp.Validators"));
            RegisterValidators(builder.Services, Assembly.GetExecutingAssembly());

            builder.Services.AddScoped<PlaygroundViewModel>();
            builder.Services.AddScoped<PlaygroundPage>();


            builder.Services.AddSingleton<ExceptionHandler>();

            var serviceProvider = builder.Services.BuildServiceProvider();

            DatabaseInitializer.Initialize(serviceProvider);

            var exceptionHandler = serviceProvider.GetService<ExceptionHandler>();

            var app = builder.Build();



            exceptionHandler?.Initialize(app.Services);
            return app;
        }

        private static void RegisterValidators(IServiceCollection services, Assembly assembly)
        {
            // Register all validators from the specified assembly
            var validatorTypes = assembly.GetTypes()
                                         .Where(type => !type.IsAbstract && !type.IsGenericTypeDefinition)
                                         .Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)));

            foreach (var validatorType in validatorTypes)
            {
                var interfaceType = validatorType.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>));
                services.AddTransient(interfaceType, validatorType);
            }
        }
    }
}
