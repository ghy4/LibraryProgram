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
	public partial class UpdateUserForm : Form
	{
		private readonly UserHttpClientService _userService;
		private UserDTO? _user;
		private readonly bool _isEditMode;

		public UpdateUserForm(UserHttpClientService userService, UserDTO? user = null)
		{
			InitializeComponent();
			_userService = userService;
			_user = user;
			_isEditMode = user != null;
		}

		private async void UpdateUserForm_Load(object sender, EventArgs e)
		{
			if (_isEditMode)
			{
				var user = await _userService.GetUserByIdAsync(_user!.Id);

				NameTextBox.Text = user.Name;
				SurnameTextBox.Text = user.Surname;
				EmailTextBox.Text = user.Email;
				ContactNumberTextBox.Text = user.ContactNumber;
				RoleComboBox.SelectedIndex = user.Role == "Admin" ? 1 : 0;

				_user = user;
				this.Text = "Update User";
				SaveButton.Text = "Update";
			}
			else
			{
				this.Text = "Create User";
				SaveButton.Text = "Create";
				RoleComboBox.SelectedIndex = 0;
			}
		}

		private async void SaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				var user = new UserDTO
				{
					Id = _user?.Id ?? 0,
					Name = NameTextBox.Text,
					Surname = SurnameTextBox.Text,
					Email = EmailTextBox.Text,
					ContactNumber = ContactNumberTextBox.Text,
					Role = RoleComboBox.SelectedIndex == 1 ? "Admin" : "User",
					Password = _isEditMode ? _user!.Password : "defaultpassword123"
				};

				if (_isEditMode)
				{
					await _userService.UpdateUserAsync(user);
				}
				else
				{
					await _userService.CreateUserAsync(user);
				}

				MessageBox.Show(_isEditMode ? "User updated successfully." : "User created successfully.");
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
	}
}
