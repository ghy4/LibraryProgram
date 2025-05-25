namespace ClientWeb
{
	partial class UpdateLibraryForm
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
			NameLabel = new Label();
			AddressLabel = new Label();
			NumberLabel = new Label();
			NameTextBox = new TextBox();
			AddressTextBox = new TextBox();
			NumberTextBox = new TextBox();
			SaveButton = new Button();
			SuspendLayout();
			// 
			// NameLabel
			// 
			NameLabel.AutoSize = true;
			NameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			NameLabel.Location = new Point(131, 23);
			NameLabel.Name = "NameLabel";
			NameLabel.Size = new Size(62, 25);
			NameLabel.TabIndex = 0;
			NameLabel.Text = "Name";
			// 
			// AddressLabel
			// 
			AddressLabel.AutoSize = true;
			AddressLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			AddressLabel.Location = new Point(114, 93);
			AddressLabel.Name = "AddressLabel";
			AddressLabel.Size = new Size(79, 25);
			AddressLabel.TabIndex = 1;
			AddressLabel.Text = "Address";
			// 
			// NumberLabel
			// 
			NumberLabel.AutoSize = true;
			NumberLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			NumberLabel.Location = new Point(42, 170);
			NumberLabel.Name = "NumberLabel";
			NumberLabel.Size = new Size(151, 25);
			NumberLabel.TabIndex = 2;
			NumberLabel.Text = "Contact Number";
			// 
			// NameTextBox
			// 
			NameTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			NameTextBox.Location = new Point(228, 20);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.Size = new Size(541, 32);
			NameTextBox.TabIndex = 3;
			// 
			// AddressTextBox
			// 
			AddressTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			AddressTextBox.Location = new Point(228, 90);
			AddressTextBox.Name = "AddressTextBox";
			AddressTextBox.Size = new Size(541, 32);
			AddressTextBox.TabIndex = 4;
			// 
			// NumberTextBox
			// 
			NumberTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			NumberTextBox.Location = new Point(228, 167);
			NumberTextBox.Name = "NumberTextBox";
			NumberTextBox.Size = new Size(541, 32);
			NumberTextBox.TabIndex = 5;
			// 
			// SaveButton
			// 
			SaveButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			SaveButton.Location = new Point(610, 248);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(159, 52);
			SaveButton.TabIndex = 6;
			SaveButton.Text = "Save";
			SaveButton.UseVisualStyleBackColor = true;
			SaveButton.Click += SaveButton_Click;
			// 
			// UpdateLibraryForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 318);
			Controls.Add(SaveButton);
			Controls.Add(NumberTextBox);
			Controls.Add(AddressTextBox);
			Controls.Add(NameTextBox);
			Controls.Add(NumberLabel);
			Controls.Add(AddressLabel);
			Controls.Add(NameLabel);
			Name = "UpdateLibraryForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "UpdateLibrary";
			Load += UpdateLibraryForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label NameLabel;
		private Label AddressLabel;
		private Label NumberLabel;
		private TextBox NameTextBox;
		private TextBox AddressTextBox;
		private TextBox NumberTextBox;
		private Button SaveButton;
	}
}