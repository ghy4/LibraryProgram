using ClientWeb.Services;
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
		private readonly BookHttpClientService _bookService;
		private readonly BookDTO? _book;
		private readonly bool _isEditMode;

		public UpdateBookForm(BookHttpClientService bookService, BookDTO? book = null)
		{
			InitializeComponent();
			_bookService = bookService;
			_book = book;
			_isEditMode = book != null;
		}

		private async void UpdateBookForm_Load(object sender, EventArgs e)
		{
			if (_isEditMode)
			{
				var book = await _bookService.GetBookByIdAsync(_book!.Id);

				TitleTextBox.Text = book.Title;
				AuthorTextBox.Text = book.Author;
				DateOfPublicationDatePicker.Value = book.DateOfPublication;
				DesctiptionTextBox.Text = book.Description;

				this.Text = "Update Book";
				SaveButton.Text = "Update";
			}
			else
			{
				this.Text = "Create Book";
				SaveButton.Text = "Create";
			}
		}

		private async void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				var book = new BookDTO
				{
					Id = _book?.Id ?? 0,
					Title = TitleTextBox.Text,
					Author = AuthorTextBox.Text,
					DateOfPublication = DateOfPublicationDatePicker.Value,
					Description = DesctiptionTextBox.Text
				};

				if (_isEditMode)
				{
					await _bookService.UpdateBookAsync(book);
				}
				else
				{
					await _bookService.CreateBookAsync(book);
				}

				MessageBox.Show(_isEditMode ? "Book updated successfully." : "Book created successfully.");
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
	}
}
