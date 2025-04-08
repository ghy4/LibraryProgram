namespace ClientWeb
{
	partial class SignUpForm
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
			NameTextBox = new TextBox();
			ContactNumberTextBox = new TextBox();
			SurnameTextBox = new TextBox();
			EmailTextBox = new TextBox();
			ConfirmationPasswordTextBox = new TextBox();
			PasswordTextBox = new TextBox();
			NameLabel = new Label();
			SurnameLabel = new Label();
			EmailLabel = new Label();
			PasswordLabel = new Label();
			ConfirmationPasswordLabel = new Label();
			ContactNumberLabel = new Label();
			label1 = new Label();
			SignUpButton = new Button();
			SuspendLayout();
			// 
			// NameTextBox
			// 
			NameTextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			NameTextBox.Location = new Point(354, 80);
			NameTextBox.Multiline = true;
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PlaceholderText = "Enter your name";
			NameTextBox.Size = new Size(455, 40);
			NameTextBox.TabIndex = 1;
			// 
			// ContactNumberTextBox
			// 
			ContactNumberTextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			ContactNumberTextBox.Location = new Point(354, 320);
			ContactNumberTextBox.Multiline = true;
			ContactNumberTextBox.Name = "ContactNumberTextBox";
			ContactNumberTextBox.PlaceholderText = "Enter your contact number";
			ContactNumberTextBox.Size = new Size(455, 41);
			ContactNumberTextBox.TabIndex = 4;
			ContactNumberTextBox.UseSystemPasswordChar = true;
			// 
			// SurnameTextBox
			// 
			SurnameTextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			SurnameTextBox.Location = new Point(354, 160);
			SurnameTextBox.Multiline = true;
			SurnameTextBox.Name = "SurnameTextBox";
			SurnameTextBox.PlaceholderText = "Enter your surname";
			SurnameTextBox.Size = new Size(455, 42);
			SurnameTextBox.TabIndex = 2;
			// 
			// EmailTextBox
			// 
			EmailTextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			EmailTextBox.Location = new Point(354, 240);
			EmailTextBox.Multiline = true;
			EmailTextBox.Name = "EmailTextBox";
			EmailTextBox.PlaceholderText = "Enter your email";
			EmailTextBox.Size = new Size(455, 40);
			EmailTextBox.TabIndex = 3;
			// 
			// ConfirmationPasswordTextBox
			// 
			ConfirmationPasswordTextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			ConfirmationPasswordTextBox.Location = new Point(354, 480);
			ConfirmationPasswordTextBox.Multiline = true;
			ConfirmationPasswordTextBox.Name = "ConfirmationPasswordTextBox";
			ConfirmationPasswordTextBox.PlaceholderText = "Enter your password again";
			ConfirmationPasswordTextBox.Size = new Size(455, 40);
			ConfirmationPasswordTextBox.TabIndex = 6;
			// 
			// PasswordTextBox
			// 
			PasswordTextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			PasswordTextBox.Location = new Point(354, 400);
			PasswordTextBox.Multiline = true;
			PasswordTextBox.Name = "PasswordTextBox";
			PasswordTextBox.PlaceholderText = "Enter your password";
			PasswordTextBox.Size = new Size(455, 41);
			PasswordTextBox.TabIndex = 5;
			PasswordTextBox.UseSystemPasswordChar = true;
			// 
			// NameLabel
			// 
			NameLabel.AutoSize = true;
			NameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			NameLabel.Location = new Point(62, 80);
			NameLabel.Name = "NameLabel";
			NameLabel.Size = new Size(78, 32);
			NameLabel.TabIndex = 8;
			NameLabel.Text = "Name";
			// 
			// SurnameLabel
			// 
			SurnameLabel.AutoSize = true;
			SurnameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			SurnameLabel.Location = new Point(62, 160);
			SurnameLabel.Name = "SurnameLabel";
			SurnameLabel.Size = new Size(109, 32);
			SurnameLabel.TabIndex = 9;
			SurnameLabel.Text = "Surname";
			// 
			// EmailLabel
			// 
			EmailLabel.AutoSize = true;
			EmailLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			EmailLabel.Location = new Point(62, 240);
			EmailLabel.Name = "EmailLabel";
			EmailLabel.Size = new Size(71, 32);
			EmailLabel.TabIndex = 10;
			EmailLabel.Text = "Email";
			// 
			// PasswordLabel
			// 
			PasswordLabel.AutoSize = true;
			PasswordLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			PasswordLabel.Location = new Point(62, 400);
			PasswordLabel.Name = "PasswordLabel";
			PasswordLabel.Size = new Size(111, 32);
			PasswordLabel.TabIndex = 11;
			PasswordLabel.Text = "Password";
			// 
			// ConfirmationPasswordLabel
			// 
			ConfirmationPasswordLabel.AutoSize = true;
			ConfirmationPasswordLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			ConfirmationPasswordLabel.Location = new Point(62, 480);
			ConfirmationPasswordLabel.Name = "ConfirmationPasswordLabel";
			ConfirmationPasswordLabel.Size = new Size(258, 32);
			ConfirmationPasswordLabel.TabIndex = 12;
			ConfirmationPasswordLabel.Text = "Password Confirmation";
			// 
			// ContactNumberLabel
			// 
			ContactNumberLabel.AutoSize = true;
			ContactNumberLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			ContactNumberLabel.Location = new Point(62, 320);
			ContactNumberLabel.Name = "ContactNumberLabel";
			ContactNumberLabel.Size = new Size(191, 32);
			ContactNumberLabel.TabIndex = 13;
			ContactNumberLabel.Text = "Contact Number";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(62, 20);
			label1.Name = "label1";
			label1.Size = new Size(198, 32);
			label1.TabIndex = 14;
			label1.Text = "Registration form";
			// 
			// SignUpButton
			// 
			SignUpButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			SignUpButton.Location = new Point(813, 588);
			SignUpButton.Name = "SignUpButton";
			SignUpButton.Size = new Size(242, 53);
			SignUpButton.TabIndex = 15;
			SignUpButton.Text = "Sign Up";
			SignUpButton.UseVisualStyleBackColor = true;
			SignUpButton.Click += SignUpButton_Click;
			// 
			// SignUpForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.InactiveCaption;
			ClientSize = new Size(1082, 653);
			Controls.Add(SignUpButton);
			Controls.Add(label1);
			Controls.Add(ContactNumberLabel);
			Controls.Add(ConfirmationPasswordLabel);
			Controls.Add(PasswordLabel);
			Controls.Add(EmailLabel);
			Controls.Add(SurnameLabel);
			Controls.Add(NameLabel);
			Controls.Add(PasswordTextBox);
			Controls.Add(ConfirmationPasswordTextBox);
			Controls.Add(EmailTextBox);
			Controls.Add(SurnameTextBox);
			Controls.Add(ContactNumberTextBox);
			Controls.Add(NameTextBox);
			Name = "SignUpForm";
			ShowIcon = false;
			Text = "SignUp";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox NameTextBox;
		private TextBox ContactNumberTextBox;
		private TextBox SurnameTextBox;
		private TextBox EmailTextBox;
		private TextBox Confirmation;
		private TextBox PasswordTextBox;
		private Label NameLabel;
		private Label SurnameLabel;
		private Label EmailLabel;
		private Label PasswordLabel;
		private Label ConfirmationPasswordLabel;
		private Label ContactNumberLabel;
		private Label label1;
		private Button SignUpButton;
		private TextBox ConfirmationPasswordTextBox;
	}
}