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
using ClientWeb.Services;

namespace ClientWeb
{
	public partial class SignInForm : Form
	{
		private readonly UserHttpClientService _userService;
		private readonly LibraryHttpClientService _libraryService;
		private readonly BookHttpClientService _bookService;
		private bool flag = true;

		public SignInForm(UserHttpClientService userService, BookHttpClientService bookService, LibraryHttpClientService libraryService)
		{
			InitializeComponent();
			_userService = userService;
			_libraryService = libraryService;
			_bookService = bookService;
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
			try
			{
				var loginResponse = await _userService.Login(email, password);

				if (loginResponse == null)
				{
					MessageBox.Show("Invalid email or password.");
					return;
				}

				Form nextForm = loginResponse.User.Role switch
				{
					"Admin" => new AdminPanel(_libraryService, _userService, _bookService),
					"User" => new MainPage(_libraryService, _userService, loginResponse.User.Id),
					_ => null
				};

				if (nextForm != null)
				{
					nextForm.Show();
					this.Hide();
				}
				else
				{
					MessageBox.Show("Unknown user role.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error to sign in: " + ex.Message);
			}
		}

		private void Sing_up_Click(object sender, EventArgs e)
		{
			SignUpForm singInForm = new SignUpForm(_userService, _libraryService);
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
