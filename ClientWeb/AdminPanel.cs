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

namespace ClientWeb
{
	public partial class AdminPanel : Form
	{
		private readonly HttpClient _httpClient;
		private string _currentEntityType = "Library";
		private List<UserDTO> _users = new List<UserDTO>();
		public AdminPanel()
		{
			InitializeComponent();
			_httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7221") };
		}

		private async void AdminPanel_LoadAsync(object sender, EventArgs e)
		{
			try
			{
				AdminRadioButton.Visible = false;
				UserRadioButton.Visible = false;
				AllRadioButton.Visible = false;
				var response = await _httpClient.GetAsync("/api/Library/Libraries");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				var libraries = await JsonSerializer.DeserializeAsync<List<LibraryDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				var data = libraries.Select(lib => new
				{
					lib.Id,
					lib.Name,
					lib.Address,
					lib.ContactNumber,
					Bookslist = string.Join(", ", lib.Books.Select(b => b.Title))
				});

				UpdateDataGridView(data.ToList());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void BooksMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				AdminRadioButton.Visible = false;
				UserRadioButton.Visible = false;
				AllRadioButton.Visible = false;
				_currentEntityType = "Book";
				var response = await _httpClient.GetAsync("/api/Book/Books");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				var books = await JsonSerializer.DeserializeAsync<List<BookDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				var data = books.Select(b => new
				{
					b.Id,
					b.Title,
					b.Author,
					b.Description,
					b.DateOfPublication,
					b.Rating,
					Libraries = string.Join(", ", b.Libraries.Select(l => l.Name))
				});
				UpdateDataGridView(data.ToList());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void UsersMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				AdminRadioButton.Visible = true;
				UserRadioButton.Visible = true;
				AllRadioButton.Visible = true;
				_currentEntityType = "User";
				var response = await _httpClient.GetAsync("/api/User/Users");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				_users = await JsonSerializer.DeserializeAsync<List<UserDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});


				UpdateDataGridView(_users);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private async void LibrariesMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				AdminRadioButton.Visible = false;
				UserRadioButton.Visible = false;
				AllRadioButton.Visible = false;
				_currentEntityType = "Library";
				var response = await _httpClient.GetAsync("/api/Library/Libraries");
				response.EnsureSuccessStatusCode();


				var content = await response.Content.ReadAsStreamAsync();
				var libraries = await JsonSerializer.DeserializeAsync<List<LibraryDTO>>(content, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				var data = libraries.Select(lib => new
				{
					lib.Id,
					lib.Name,
					lib.Address,
					lib.ContactNumber,
					Bookslist = string.Join(", ", lib.Books.Select(b => b.Title))
				});

				UpdateDataGridView(data.ToList());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{

		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentRow == null)
				return;
			var selectedRow = dataGridView1.CurrentRow;
			var value = selectedRow.Cells["Id"].Value;
			switch (_currentEntityType)
			{
				case "Library":
					var library = new LibraryDTO() { Id = Convert.ToInt32(value.ToString()) };
					var libraryorm = new UpdateLibraryForm(library);
					libraryorm.Show();
					break;
				case "User":
					var user = new UserDTO() { Id = Convert.ToInt32(value.ToString()) };
					var userForm = new UpdateUserForm(user);
					userForm.Show();
					break;
				case "Book":
					var book = new BookDTO() { Id = Convert.ToInt32(value.ToString()) };
					var bookForm = new UpdateBookForm(book);
					bookForm.Show();
					break;
				default:
					throw new ArgumentException("Invalid entity type");
			};
		}

		private async void DeleteButton_Click(object sender, EventArgs e)
		{
			List<Task> deleteTasks = new List<Task>();
			try
			{
				foreach (var item in dataGridView1.Columns)
				{
					if (item is DataGridViewCheckBoxColumn checkBoxColumn)
					{
						foreach (DataGridViewRow row in dataGridView1.Rows)
						{
							if (Convert.ToBoolean(row.Cells[checkBoxColumn.Index].Value) == true)
							{
								int id = Convert.ToInt32(row.Cells["Id"].Value);

								// Add the delete task to the list
								deleteTasks.Add(DeleteEntityAsync(_currentEntityType, id));
							}
						}
					}
				}
				await Task.WhenAll(deleteTasks);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
		private async Task DeleteEntityAsync(string entityType, int id)
		{
			string endpoint = entityType switch
			{
				"Library" => $"/api/Library/{id}",
				"User" => $"/api/User/{id}",
				"Book" => $"/api/Book/{id}",
				_ => throw new ArgumentException("Invalid entity type")
			};

			var response = await _httpClient.DeleteAsync(endpoint);
			response.EnsureSuccessStatusCode();
		}

		private void UpdateDataGridView(object dataSource)
		{
			dataGridView1.DataSource = dataSource;
			if (dataGridView1.Columns.Contains("Select"))
			{
				dataGridView1.Columns.Remove("Select");
			}
			DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
			{
				Name = "Select",
				HeaderText = "Select",
				FalseValue = false,
				TrueValue = true
			};
			dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
		}

		private void RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			ShowFilteredUsers();
		}
		private void ShowFilteredUsers()
		{
			IEnumerable<UserDTO> filtered = _users;

			if (AdminRadioButton.Checked)
				filtered = _users.Where(u => u.Role == "Admin");
			else if (UserRadioButton.Checked)
				filtered = _users.Where(u => u.Role == "User");

			UpdateDataGridView(filtered
				.Select(u => new { u.Id, u.Name, u.Surname, u.Email, u.Password, u.ContactNumber, u.Role })
				.ToList());
		}

		private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			foreach (DataGridViewColumn column in dataGridView1.Columns)
			{
				column.MinimumWidth = 50;
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
		}
	}
}
