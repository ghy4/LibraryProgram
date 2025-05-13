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
	public partial class UpdateBookForm : Form
	{
		private readonly HttpClient _httpClient;
		private BookDTO _book;
		public UpdateBookForm(BookDTO book)
		{
			InitializeComponent();
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7221") };
			_book = book;
		}

		private async void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				var updatedbook = new BookDTO
				{
					Id = _book.Id,
					Title = TitleTextBox.Text,
					Author = AuthorTextBox.Text,
					DateOfPublication = DateOfPublicationDatePicker.Value,
					Description = DesctiptionTextBox.Text
				};
				var json = JsonSerializer.Serialize(updatedbook);

				var content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await _httpClient.PutAsync($"/api/Book/{_book.Id}", content);
				response.EnsureSuccessStatusCode();
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void UpdateBookForm_Load(object sender, EventArgs e)
		{
			var response = await _httpClient.GetAsync($"/api/Book/{_book.Id}");
			response.EnsureSuccessStatusCode();


			var content = await response.Content.ReadAsStreamAsync();
			var book = await JsonSerializer.DeserializeAsync<BookDTO>(content, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			TitleTextBox.Text = book.Title;
			AuthorTextBox.Text = book.Author;
			DateOfPublicationDatePicker.Value = book.DateOfPublication;
			DesctiptionTextBox.Text = book.Description;
		}
	}
}
