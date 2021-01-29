using System;
using System.Reflection;
using System.Threading.Tasks;
using ElectronNET.API.Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using Sidekick.Application;
using Sidekick.Application.Settings;
using Sidekick.Domain.Initialization.Commands;
using Sidekick.Domain.Platforms;
using Sidekick.Domain.Settings.Commands;
using Sidekick.Domain.Views;
using Sidekick.Infrastructure;
using Sidekick.Logging;
using Sidekick.Mapper;
using Sidekick.Mediator;
using Sidekick.Persistence;
using Sidekick.Platform;
using Sidekick.Presentation.Blazor.Electron.Tray;
using Sidekick.Presentation.Blazor.Electron.Views;

namespace Sidekick.Presentation.Blazor.Electron
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services
                // Common
                .AddSidekickLogging()
                .AddSidekickMapper(
                    Assembly.Load("Sidekick.Infrastructure"),
                    Assembly.Load("Sidekick.Persistence"))
                .AddSidekickMediator(
                    Assembly.Load("Sidekick.Application"),
                    Assembly.Load("Sidekick.Domain"),
                    Assembly.Load("Sidekick.Infrastructure"),
                    Assembly.Load("Sidekick.Persistence"),
                    Assembly.Load("Sidekick.Platform"),
                    Assembly.Load("Sidekick.Presentation"),
                    Assembly.Load("Sidekick.Presentation.Blazor"),
                    Assembly.Load("Sidekick.Presentation.Blazor.Electron"))

                // Layers
                .AddSidekickApplication()
                .AddSidekickInfrastructure()
                .AddSidekickPersistence()
                .AddSidekickPlatform()
                .AddSidekickPresentation();

            services.AddSingleton<TrayProvider>();
            services.AddSingleton<IViewLocator, ViewLocator>();

            services
                .AddMudBlazorDialog()
                .AddMudBlazorSnackbar()
                .AddMudBlazorResizeListener();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider,
            TrayProvider trayProvider,
            IMediator mediator,
            IKeyboardProvider keyboardProvider,
            ILogger<Startup> logger)
        {
            serviceProvider.UseSidekickMapper();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            // Electron stuff
            ElectronNET.API.Electron.WindowManager.IsQuitOnWindowAllClosed = false;
            Task.Run(async () =>
            {
                trayProvider.Initialize();
                var browserWindow = await ElectronNET.API.Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
                {
                    Width = 1,
                    Height = 1,
                    Frame = false,
                    Show = true,
                    Transparent = true,
                    Fullscreenable = false,
                    Minimizable = false,
                    Maximizable = false,
                    SkipTaskbar = true,
                    WebPreferences = new WebPreferences()
                    {
                        NodeIntegration = false,
                    }
                });
                await Task.Delay(50);
                browserWindow.Close();
            });

            Task.Run(async () =>
            {
                await mediator.Send(new SaveSettingsCommand(new SidekickSettings()
                {
                    LeagueId = "Ritual",
                    Language_Parser = "en",
                    Language_UI = "en",
                }));

                await mediator.Send(new InitializeCommand(true));
            });

            /* For testing purposes
            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(5000);
                    keyboardProvider.Initialize();
                    await keyboardProvider.PressKey("A", "B", "C", "D", "E");
                }
                catch (Exception e)
                {
                    logger.LogError("Bad keybind", e);
                    logger.LogError(e.Message);
                    logger.LogError(e.StackTrace);
                }
            });
            */
        }
    }
}