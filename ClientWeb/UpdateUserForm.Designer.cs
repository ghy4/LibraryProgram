namespace ClientWeb
{
	partial class UpdateUserForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DesctiptionLabel = new Label();
			ContactNumberTextBox = new TextBox();
			SaveButton = new Button();
			EmailTextBox = new TextBox();
			SurnameTextBox = new TextBox();
			NameTextBox = new TextBox();
			EmailLabel = new Label();
			SurnameLabel = new Label();
			NameLabel = new Label();
			RoleLabel = new Label();
			RoleComboBox = new ComboBox();
			SuspendLayout();
			// 
			// DesctiptionLabel
			// 
			DesctiptionLabel.AutoSize = true;
			DesctiptionLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			DesctiptionLabel.Location = new Point(64, 249);
			DesctiptionLabel.Name = "DesctiptionLabel";
			DesctiptionLabel.Size = new Size(146, 25);
			DesctiptionLabel.TabIndex = 24;
			DesctiptionLabel.Text = "ContactNumber";
			// 
			// ContactNumberTextBox
			// 
			ContactNumberTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			ContactNumberTextBox.Location = new Point(223, 246);
			ContactNumberTextBox.Name = "ContactNumberTextBox";
			ContactNumberTextBox.Size = new Size(541, 32);
			ContactNumberTextBox.TabIndex = 23;
			// 
			// SaveButton
			// 
			SaveButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			SaveButton.Location = new Point(605, 367);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(159, 52);
			SaveButton.TabIndex = 22;
			SaveButton.Text = "Save";
			SaveButton.UseVisualStyleBackColor = true;
			SaveButton.Click += SaveButton_Click;
			// 
			// EmailTextBox
			// 
			EmailTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			EmailTextBox.Location = new Point(223, 172);
			EmailTextBox.Name = "EmailTextBox";
			EmailTextBox.Size = new Size(541, 32);
			EmailTextBox.TabIndex = 21;
			// 
			// SurnameTextBox
			// 
			SurnameTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			SurnameTextBox.Location = new Point(223, 95);
			SurnameTextBox.Name = "SurnameTextBox";
			SurnameTextBox.Size = new Size(541, 32);
			SurnameTextBox.TabIndex = 20;
			// 
			// NameTextBox
			// 
			NameTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			NameTextBox.Location = new Point(223, 25);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.Size = new Size(541, 32);
			NameTextBox.TabIndex = 19;
			// 
			// EmailLabel
			// 
			EmailLabel.AutoSize = true;
			EmailLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			EmailLabel.Location = new Point(152, 175);
			EmailLabel.Name = "EmailLabel";
			EmailLabel.Size = new Size(58, 25);
			EmailLabel.TabIndex = 18;
			EmailLabel.Text = "Email";
			// 
			// SurnameLabel
			// 
			SurnameLabel.AutoSize = true;
			SurnameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			SurnameLabel.Location = new Point(123, 98);
			SurnameLabel.Name = "SurnameLabel";
			SurnameLabel.Size = new Size(87, 25);
			SurnameLabel.TabIndex = 17;
			SurnameLabel.Text = "Surname";
			// 
			// NameLabel
			// 
			NameLabel.AutoSize = true;
			NameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			NameLabel.Location = new Point(148, 28);
			NameLabel.Name = "NameLabel";
			NameLabel.Size = new Size(62, 25);
			NameLabel.TabIndex = 16;
			NameLabel.Text = "Name";
			// 
			// RoleLabel
			// 
			RoleLabel.AutoSize = true;
			RoleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			RoleLabel.Location = new Point(162, 314);
			RoleLabel.Name = "RoleLabel";
			RoleLabel.Size = new Size(48, 25);
			RoleLabel.TabIndex = 25;
			RoleLabel.Text = "Role";
			// 
			// RoleComboBox
			// 
			RoleComboBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			RoleComboBox.FormattingEnabled = true;
			RoleComboBox.Items.AddRange(new object[] { "User", "Admin" });
			RoleComboBox.Location = new Point(223, 311);
			RoleComboBox.Name = "RoleComboBox";
			RoleComboBox.Size = new Size(541, 33);
			RoleComboBox.TabIndex = 26;
			// 
			// UpdateUserForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 440);
			Controls.Add(RoleComboBox);
			Controls.Add(RoleLabel);
			Controls.Add(DesctiptionLabel);
			Controls.Add(ContactNumberTextBox);
			Controls.Add(SaveButton);
			Controls.Add(EmailTextBox);
			Controls.Add(SurnameTextBox);
			Controls.Add(NameTextBox);
			Controls.Add(EmailLabel);
			Controls.Add(SurnameLabel);
			Controls.Add(NameLabel);
			Name = "UpdateUserForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "UpdateUserForm";
			Load += UpdateUserForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label DesctiptionLabel;
		private TextBox ContactNumberTextBox;
		private Button SaveButton;
		private TextBox EmailTextBox;
		private TextBox SurnameTextBox;
		private TextBox NameTextBox;
		private Label EmailLabel;
		private Label SurnameLabel;
		private Label NameLabel;
		private Label RoleLabel;
		private ComboBox RoleComboBox;
	}
}