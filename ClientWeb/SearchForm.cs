using Data.Models;
using Server.DTOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ClientWeb
{
	public partial class SearchForm : Form
	{
		private readonly HttpClient _httpClient;
		private int _libraryId;
		public SearchForm(int libraryId)
		{
			InitializeComponent();
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7221") };
			_libraryId = libraryId;
		}

		private async void TitleSearchButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
				{
					MessageBox.Show("Please fill Name field.");
					return;
				}
				var response = await _httpClient.GetAsync("/api/Library/Libraries");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				var libraries = await JsonSerializer.DeserializeAsync<List<LibraryDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				var book = libraries[_libraryId].Books.FirstOrDefault(x => x.Title == TitleTextBox.Text, null);
				if (book == null)
				{
					MessageBox.Show("No book with that title");
					return;
				}
				else
					MessageBox.Show($"Title: {book.Title}\nAuthor: {book.Author}\nDescription: {book.Description}");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void IdSearchButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(IdTextBox.Text))
				{
					MessageBox.Show("Please fill Id field.");
					return;
				}
				var response = await _httpClient.GetAsync("/api/Library/Libraries");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				var libraries = await JsonSerializer.DeserializeAsync<List<LibraryDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				var book = libraries[_libraryId].Books.FirstOrDefault(x => x.Id == Convert.ToInt32(IdTextBox.Text), null);
				if (book == null)
				{
					MessageBox.Show("No book with that Id");
					return;
				}
				else
					MessageBox.Show($"Title: {book.Title}\nAuthor: {book.Author}\nDescription: {book.Description}");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
	}
}
