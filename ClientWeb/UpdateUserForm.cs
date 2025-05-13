using Server.DTOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWeb
{
	public partial class UpdateUserForm : Form
	{
		private readonly HttpClient _httpClient;
		private UserDTO _user;
		public UpdateUserForm(UserDTO user)
		{
			InitializeComponent();
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7221") };
			_user = user;
		}

		private async void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{

				var updatedUser = new UserDTO
				{
					Id = _user.Id,
					Name = NameTextBox.Text,
					Surname = SurnameTextBox.Text,
					Email = EmailTextBox.Text,
					ContactNumber = ContactNumberTextBox.Text,
					Role = RoleComboBox.SelectedIndex == 0 ? "User" : "Admin",
					Password =  _user.Password
				};
				var json = JsonSerializer.Serialize(updatedUser);

				var content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await _httpClient.PutAsync($"/api/User/{_user.Id}", content);
				response.EnsureSuccessStatusCode();
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void UpdateUserForm_Load(object sender, EventArgs e)
		{
			var response = await _httpClient.GetAsync($"/api/User/{_user.Id}");
			response.EnsureSuccessStatusCode();


			var content = await response.Content.ReadAsStreamAsync();
			var user = await JsonSerializer.DeserializeAsync<UserDTO>(content, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			NameTextBox.Text = user.Name;
			SurnameTextBox.Text = user.Surname;
			EmailTextBox.Text = user.Email;
			ContactNumberTextBox.Text = user.ContactNumber;
			RoleComboBox.SelectedIndex = (user.Role == "User") ? 0 : 1;
			_user = user;
		}
	}
}
