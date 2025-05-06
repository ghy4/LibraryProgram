using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWeb
{
	public partial class SignUpForm : Form
	{
		private readonly HttpClient _httpClient;
		public SignUpForm()
		{
			InitializeComponent();
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7221") };
		}

		private async void SignUpButton_Click(object sender, EventArgs e)
		{
			var email = EmailTextBox.Text;
			var password = PasswordTextBox.Text;
			var name = NameTextBox.Text;
			var surname = SurnameTextBox.Text;
			var contactNumber = ContactNumberTextBox.Text;
			var confiPassword = ConfirmationPasswordTextBox.Text;

			if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(confiPassword) || string.IsNullOrWhiteSpace(contactNumber))
			{
				MessageBox.Show("Fill all empty spaces.");
				return;
			}

			if (password != confiPassword)
			{
				MessageBox.Show("Passwords are not identical.");
				return;
			}
			if(contactNumber.Length != 12 && contactNumber.Length != 10)
			{
				MessageBox.Show("Contact number is not correct.");
				return;
			}

			if (!IsValidEmail(email))
			{
				MessageBox.Show("Email is not correct.");
				return;
			} 

			var registerRequest = new RegisterRequest{Name = name, Surname = surname, Email = email, ContactNumber = contactNumber,  Password = password };
			string json = JsonSerializer.Serialize(registerRequest);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			try
			{
				HttpResponseMessage response = await _httpClient.PostAsync("/api/User/register", content);

				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					var registerResponse = JsonSerializer.Deserialize<RegisterResponse>(responseBody);

					_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", registerResponse.Token);

					MainPage mainPage = new MainPage();
					mainPage.Show();
					this.Hide();
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
				MessageBox.Show("Error to sign up: " + ex.Message);
			}
		}
		bool IsValidEmail(string email)
		{
			var trimmedEmail = email.Trim();

			if (trimmedEmail.EndsWith("."))
			{
				return false; // suggested by @TK-421
			}
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == trimmedEmail;
			}
			catch
			{
				return false;
			}
		}
	}
	public class RegisterRequest
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ContactNumber { get; set; }
		public string Role { get; set; } = "User";
	}
	public class RegisterResponse
	{
		public string Token { get; set; }
		public UserInfoRegister User { get; set; }
	}
    public class  UserInfoRegister
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string ContactNumber { get; set; }
		public string Role { get; set; }
	}
}
