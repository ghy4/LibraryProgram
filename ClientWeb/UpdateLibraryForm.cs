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
	public partial class UpdateLibraryForm : Form
	{
		private readonly LibraryHttpClientService _libraryService;
		private readonly LibraryDTO? _library;
		private readonly bool _isEditMode;

		public UpdateLibraryForm(LibraryHttpClientService libraryService, LibraryDTO? library = null)
		{
			InitializeComponent();
			_libraryService = libraryService;
			_library = library;
			_isEditMode = library != null;
		}

		private async void UpdateLibraryForm_Load(object sender, EventArgs e)
		{
			if (_isEditMode)
			{
				var library = await _libraryService.GetLibraryByIdAsync(_library!.Id);
				NameTextBox.Text = library.Name;
				AddressTextBox.Text = library.Address;
				NumberTextBox.Text = library.ContactNumber;

				this.Text = "Update Library";
				SaveButton.Text = "Update";
			}
			else
			{
				this.Text = "Create Library";
				SaveButton.Text = "Create";
			}
		}

		private async void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				var library = new LibraryDTO
				{
					Id = _library?.Id ?? 0,
					Name = NameTextBox.Text,
					Address = AddressTextBox.Text,
					ContactNumber = NumberTextBox.Text
				};

				if (_isEditMode)
				{
					await _libraryService.UpdateLibraryAsync(library);
				}
				else
				{
					await _libraryService.CreateLibraryAsync(library);
				}

				MessageBox.Show(_isEditMode ? "Library updated successfully." : "Library created successfully.");
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
	}
}
