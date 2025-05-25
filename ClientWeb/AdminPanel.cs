using Database.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using ClientWeb.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ClientWeb
{
	public partial class AdminPanel : Form
	{
		private readonly LibraryHttpClientService _libraryService;
		private readonly UserHttpClientService _userService;
		private readonly BookHttpClientService _bookService;

		private string _currentEntityType = "Library";
		private List<UserDTO> _users = new List<UserDTO>();
		private List<LibraryDTO> _libraries = new List<LibraryDTO>();
		private List<BookDTO> _books = new List<BookDTO>();

		public AdminPanel(LibraryHttpClientService libraryService, UserHttpClientService userService, BookHttpClientService bookService)
		{
			InitializeComponent();

			_libraryService = libraryService;
			_userService = userService;
			_bookService = bookService;
		}

		private async void AdminPanel_Load(object sender, EventArgs e)
		{
			await LoadLibrariesAsync();
		}

		private async Task LoadLibrariesAsync()
		{
			try
			{
				AdminRadioButton.Visible = false;
				UserRadioButton.Visible = false;
				AllRadioButton.Visible = false;
				BookAddButton.Visible = true;
				BookAddTextBox.Visible = true;
				_currentEntityType = "Library";

				_libraries = await _libraryService.GetLibrariesAsync();

				var data = _libraries.Select(lib => new
				{
					lib.Id,
					lib.Name,
					lib.Address,
					lib.ContactNumber,
					Bookslist = string.Join(", ", lib.Books.Select(b => b.Title))
				}).ToList();

				UpdateDataGridView(data);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading libraries: " + ex.Message);
			}
		}

		private async Task LoadBooksAsync()
		{
			try
			{
				AdminRadioButton.Visible = false;
				UserRadioButton.Visible = false;
				AllRadioButton.Visible = false;
				BookAddButton.Visible = false;
				BookAddTextBox.Visible = false;
				_currentEntityType = "Book";

				_books = await _bookService.GetBooksAsync();

				var data = _books.Select(b => new
				{
					b.Id,
					b.Title,
					b.Author,
					b.Description,
					b.DateOfPublication,
					b.Rating,
					Libraries = string.Join(", ", b.Libraries.Select(l => l.Name))
				}).ToList();

				UpdateDataGridView(data);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading books: " + ex.Message);
			}
		}

		private async Task LoadUsersAsync()
		{
			try
			{
				AdminRadioButton.Visible = true;
				UserRadioButton.Visible = true;
				AllRadioButton.Visible = true;
				BookAddButton.Visible = false;
				BookAddTextBox.Visible = false;
				_currentEntityType = "User";

				_users = await _userService.GetUsersAsync();

				ShowFilteredUsers();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading users: " + ex.Message);
			}
		}

		private void ShowFilteredUsers()
		{
			IEnumerable<UserDTO> filtered = _users;

			if (AdminRadioButton.Checked)
				filtered = _users.Where(u => u.Role == "Admin");
			else if (UserRadioButton.Checked)
				filtered = _users.Where(u => u.Role == "User");

			var result = filtered.Select(u => new { u.Id, u.Name, u.Surname, u.Email, u.Password, u.ContactNumber, u.Role }).ToList();

			UpdateDataGridView(result);
		}

		private void UpdateDataGridView(object dataSource)
		{
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = dataSource;

			if (dataGridView1.Columns.Contains("Select"))
				dataGridView1.Columns.Remove("Select");

			var checkBoxColumn = new DataGridViewCheckBoxColumn
			{
				Name = "Select",
				HeaderText = "Select",
				FalseValue = false,
				TrueValue = true
			};

			dataGridView1.Columns.Insert(dataGridView1.Columns.Count, checkBoxColumn);
		}

		private async void LibrariesMenuItem_Click(object sender, EventArgs e)
		{
			await LoadLibrariesAsync();
		}

		private async void BooksMenuItem_Click(object sender, EventArgs e)
		{
			await LoadBooksAsync();
		}

		private async void UsersMenuItem_Click(object sender, EventArgs e)
		{
			await LoadUsersAsync();
		}

		private async void DeleteButton_Click(object sender, EventArgs e)
		{
			try
			{
				var selectedIds = dataGridView1.Rows.Cast<DataGridViewRow>()
					.Where(r => Convert.ToBoolean(r.Cells["Select"].Value) == true)
					.Select(r => Convert.ToInt32(r.Cells["Id"].Value))
					.ToList();

				if (selectedIds.Count == 0)
				{
					MessageBox.Show("Please select items to delete.");
					return;
				}

				var confirmResult = MessageBox.Show($"Are you sure to delete {selectedIds.Count} item(s)?",
									"Confirm Delete",
									MessageBoxButtons.YesNo);

				if (confirmResult != DialogResult.Yes)
					return;

				foreach (var id in selectedIds)
				{
					switch (_currentEntityType)
					{
						case "Library":
							await _libraryService.DeleteLibraryAsync(id);
							break;
						case "Book":
							await _bookService.DeleteBookAsync(id);
							break;
						case "User":
							await _userService.DeleteUserAsync(id);
							break;
					}
				}

				MessageBox.Show("Selected items deleted successfully.");

				await RefreshCurrentEntityAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error deleting items: " + ex.Message);
			}
		}

		private async Task RefreshCurrentEntityAsync()
		{
			switch (_currentEntityType)
			{
				case "Library":
					await LoadLibrariesAsync();
					break;
				case "Book":
					await LoadBooksAsync();
					break;
				case "User":
					await LoadUsersAsync();
					break;
			}
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			var selectedRows = dataGridView1.Rows.Cast<DataGridViewRow>()
			.Where(r => Convert.ToBoolean(r.Cells["Select"].Value) == true)
			.ToList();

			if (selectedRows.Count == 0)
			{
				MessageBox.Show("Please select one item to edit.");
				return;
			}

			if (selectedRows.Count > 1)
			{
				MessageBox.Show("Please select only one item to edit at a time.");
				return;
			}

			var selectedRow = selectedRows.First();
			var id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

			switch (_currentEntityType)
			{
				case "Library":
					var library = _libraries.FirstOrDefault(l => l.Id == id);
					if (library != null)
					{
						var form = new UpdateLibraryForm(_libraryService, library);
						form.Show();
					}
					break;
				case "User":
					var user = _users.FirstOrDefault(u => u.Id == id);
					if (user != null)
					{
						var form = new UpdateUserForm(_userService, user);
						form.Show();
					}
					break;
				case "Book":
					var book = _books.FirstOrDefault(b => b.Id == id);
					if (book != null)
					{
						var form = new UpdateBookForm(_bookService, book);
						form.Show();
					}
					break;
			}
		}

		private void RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (_currentEntityType == "User")
				ShowFilteredUsers();
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			switch (_currentEntityType)
			{
				case "Library":
					var form = new UpdateLibraryForm(_libraryService);
					form.Show();
					break;
				case "User":
					var form1 = new UpdateUserForm(_userService);
					form1.Show();
					break;
				case "Book":
					var form2 = new UpdateBookForm(_bookService);
					form2.Show();
					break;
			}
		}

		private async void BookAddButton_Click(object sender, EventArgs e)
		{
			if (!int.TryParse(BookAddTextBox.Text.Trim(), out int bookId))
			{
				MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var selectedRows = dataGridView1.Rows.Cast<DataGridViewRow>()
			.Where(r => Convert.ToBoolean(r.Cells["Select"].Value) == true)
			.ToList();

			if (selectedRows.Count == 0)
			{
				MessageBox.Show("Please select one item to edit.");
				return;
			}

			if (selectedRows.Count > 1)
			{
				MessageBox.Show("Please select only one item to edit at a time.");
				return;
			}

			var selectedRow = selectedRows.First();
			var id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

			try
			{
				await _libraryService.AddBookToLibraryAsync(id, bookId);
				MessageBox.Show("Book added successfully!");
				BookAddTextBox.Text = "";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to add book: " + ex.Message, "Error");
			}
		}
	}
}
