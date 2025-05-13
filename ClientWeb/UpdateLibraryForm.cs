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
	public partial class UpdateLibraryForm : Form
	{
		private readonly HttpClient _httpClient;
		private LibraryDTO _library;
		public UpdateLibraryForm(LibraryDTO library)
		{
			InitializeComponent();
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7221") };
			_library = library;
		}

		private async void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				var updatedLibrary = new LibraryDTO
				{
					Id = _library.Id,
					Name = NameTextBox.Text,
					Address = AddressTextBox.Text,
					ContactNumber = NumberTextBox.Text
				};
				var json = JsonSerializer.Serialize(updatedLibrary);

				var content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await _httpClient.PutAsync($"/api/Library/{_library.Id}", content);
				response.EnsureSuccessStatusCode();
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void UpdateLibraryForm_Load(object sender, EventArgs e)
		{
			var response = await _httpClient.GetAsync($"/api/Library/{_library.Id}");
			response.EnsureSuccessStatusCode();


			var content = await response.Content.ReadAsStreamAsync();
			var library = await JsonSerializer.DeserializeAsync<LibraryDTO>(content, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			NameTextBox.Text = library.Name;
			AddressTextBox.Text = library.Address;
			NumberTextBox.Text = library.ContactNumber;
		}
	}
}
