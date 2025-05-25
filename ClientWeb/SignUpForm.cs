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
using ClientWeb.Services;
using Database.Services;
using static ClientWeb.Services.UserHttpClientService;

namespace ClientWeb
{
	public partial class SignUpForm : Form
	{
		private readonly UserHttpClientService _userService;
		private readonly LibraryHttpClientService _libraryService;
		public SignUpForm(UserHttpClientService userService, LibraryHttpClientService libraryService)
		{
			InitializeComponent();
			_userService = userService;
			_libraryService = libraryService;
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

			try
			{
				var registerRequest = new RegisterRequest
				{
					Name = name,
					Surname = surname,
					Email = email,
					Password = password,
					ContactNumber = contactNumber,
					Role = "User"
				};

				var registerResponse = await _userService.RegisterAsync(registerRequest);

				if (registerResponse != null)
				{
					_userService.SetBearerToken(registerResponse.Token);

					MainPage mainPage = new MainPage(_libraryService, _userService, registerResponse.User.Id);
					mainPage.Show();
					this.Hide();
				}
				else
				{
					MessageBox.Show("Registration failed.");
				}
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
				return false;
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
