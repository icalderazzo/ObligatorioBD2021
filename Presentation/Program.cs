using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Obligatorio.Repositories.Interfaces;
using Obligatorio.Repositories.Repositories;
using Obligatorio.Services.Interfaces;
using Obligatorio.Services.Services;
using Presentation.Forms;
using System;
using System.Windows.Forms;

namespace Presentation
{
    static class Program
    {
        public static IConfiguration Configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@".\appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            Obligatorio.Repositories.DatabaseSettingsRepository.ConnectionString = Configuration.GetConnectionString("Production");

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var login = serviceProvider.GetRequiredService<LoginForm>();
                Application.Run(login);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.Configure<EmailService.Settings>(options => Configuration.GetSection("emailSettings").Bind(options));
            services.AddTransient<EmailService.Service.IEmailService, EmailService.Service.EmailService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>()
                    .AddScoped<LoginForm>();
        }
    }
}
