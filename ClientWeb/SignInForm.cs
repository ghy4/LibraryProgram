using Database.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using Server.Controllers;
using Server.DTOModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Windows.Forms;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClientWeb
{
	public partial class SignInForm : Form
	{
		private readonly HttpClient _httpClient;
		private bool flag = true;

		public SignInForm()
		{
			InitializeComponent();
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7221") };
		}

		private async void SingInButton_Click(object sender, EventArgs e)
		{
			var email = EmailTextBox.Text.Trim();
			var password = PasswordTextBox.Text;

			if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Please enter both email and password.");
				return;
			}

			var loginRequest = new { Email = email, Password = password };
			string json = JsonSerializer.Serialize(loginRequest);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			try
			{
				HttpResponseMessage response = await _httpClient.PostAsync("/api/User/login", content);

				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
					var options = new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					};
					var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseBody, options);

					_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
					Form nextform = loginResponse.User.Role switch
					{
						"Admin" => new AdminPanel(),
						"User" => new MainPage(),
					};
					if (nextform != null)
					{
						nextform.Show();
						this.Hide();
					}
					else
					{
						MessageBox.Show("Unknown user role.");
					}
				}
				else
				{
					string errorbody = await response.Content.ReadAsStringAsync();
					MessageBox.Show(errorbody);
				}
				//var user = await _httpClient.GetFromJsonAsync<UserDTO>($"/api/User/email?email={email}");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error to sign in: " + ex.Message);
			}
		}

		private void Sing_up_Click(object sender, EventArgs e)
		{
			SignUpForm singInForm = new SignUpForm();
			singInForm.Show();
			this.Hide();
		}

		private void PasswordIcon_Click(object sender, EventArgs e)
		{
			if (flag)
			{
				using (var ms = new MemoryStream(Properties.Resources.password_lock))
				{
					PasswordIcon.Image = Image.FromStream(ms);
				}
				PasswordTextBox.UseSystemPasswordChar = false;
			}
			else
			{
				using (var ms = new MemoryStream(Properties.Resources.password_padlock))
				{
					PasswordIcon.Image = Image.FromStream(ms);
				}
				PasswordTextBox.UseSystemPasswordChar = true;
			}
			flag = !flag;
		}
	}
	public class LoginResponse
	{
		public string Token { get; set; }
		public UserInfoLogin User { get; set; }
	}

	public class UserInfoLogin
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }
	}
}
