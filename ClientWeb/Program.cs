using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Windows.Forms;
using ClientWeb.Services;

namespace ClientWeb
{
	public static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var host = CreateHostBuilder().Build();
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			var signIn = host.Services.GetRequiredService<SignInForm>();
			Application.Run(signIn);
		}
		static IHostBuilder CreateHostBuilder()
		{
			return Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					services.AddHttpClient<BookHttpClientService>(client =>
					{
						client.BaseAddress = new Uri("https://localhost:7221");
					});

					services.AddHttpClient<LibraryHttpClientService>(client =>
					{
						client.BaseAddress = new Uri("https://localhost:7221");
					});

					services.AddHttpClient<UserHttpClientService>(client =>
					{
						client.BaseAddress = new Uri("https://localhost:7221");
					});

					services.AddSingleton<MainPage>();
					services.AddSingleton<SignInForm>();
					services.AddSingleton<SignUpForm>();
					services.AddSingleton<AdminPanel>();
					services.AddSingleton<SearchForm>();
					services.AddSingleton<UpdateBookForm>();
					services.AddSingleton<UpdateLibraryForm>();
					services.AddSingleton<UpdateUserForm>();
				});
		}
	}
}