using ClientWeb.Services;
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
		private readonly LibraryHttpClientService _libraryService;
		private readonly int _libraryId;
		private List<LibraryDTO> _libraries;

		public SearchForm(LibraryHttpClientService libraryService, int libraryId)
		{
			InitializeComponent();
			_libraryService = libraryService;
			_libraryId = libraryId;
		}

		private async Task LoadLibrariesAsync()
		{
			try
			{
				_libraries = await _libraryService.GetLibrariesAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to load libraries: " + ex.Message);
			}
		}

		private async void TitleSearchButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
			{
				MessageBox.Show("Please fill Name field.");
				return;
			}

			if (_libraries == null)
				await LoadLibrariesAsync();

			var book = _libraries[_libraryId].Books.FirstOrDefault(b => string.Equals(b.Title, TitleTextBox.Text, StringComparison.OrdinalIgnoreCase));

			if (book == null)
				MessageBox.Show("No book with that title");
			else
				MessageBox.Show($"Title: {book.Title}\nAuthor: {book.Author}\nDescription: {book.Description}\n Rating: {book.Rating}");
		}

		private async void IdSearchButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(IdTextBox.Text) || !int.TryParse(IdTextBox.Text, out int bookId))
			{
				MessageBox.Show("Please fill Id field with a valid number.");
				return;
			}

			if (_libraries == null)
				await LoadLibrariesAsync();

			var book = _libraries[_libraryId].Books.FirstOrDefault(b => b.Id == bookId);

			if (book == null)
				MessageBox.Show("No book with that Id");
			else
				MessageBox.Show($"Title: {book.Title}\nAuthor: {book.Author}\nDescription: {book.Description}");
		}
	}
}
