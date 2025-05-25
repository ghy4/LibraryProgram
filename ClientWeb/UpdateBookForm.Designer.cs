namespace ClientWeb
{
	partial class UpdateBookForm
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
			SaveButton = new Button();
			AuthorTextBox = new TextBox();
			TitleTextBox = new TextBox();
			NumberLabel = new Label();
			AuthorLabel = new Label();
			TitleLabel = new Label();
			DesctiptionTextBox = new TextBox();
			DesctiptionLabel = new Label();
			DateOfPublicationDatePicker = new DateTimePicker();
			SuspendLayout();
			// 
			// SaveButton
			// 
			SaveButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			SaveButton.Location = new Point(605, 407);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(159, 52);
			SaveButton.TabIndex = 13;
			SaveButton.Text = "Save";
			SaveButton.UseVisualStyleBackColor = true;
			SaveButton.Click += SaveButton_Click;
			// 
			// AuthorTextBox
			// 
			AuthorTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			AuthorTextBox.Location = new Point(223, 89);
			AuthorTextBox.Name = "AuthorTextBox";
			AuthorTextBox.Size = new Size(541, 32);
			AuthorTextBox.TabIndex = 11;
			// 
			// TitleTextBox
			// 
			TitleTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			TitleTextBox.Location = new Point(223, 19);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.Size = new Size(541, 32);
			TitleTextBox.TabIndex = 10;
			// 
			// NumberLabel
			// 
			NumberLabel.AutoSize = true;
			NumberLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			NumberLabel.Location = new Point(37, 169);
			NumberLabel.Name = "NumberLabel";
			NumberLabel.Size = new Size(173, 25);
			NumberLabel.TabIndex = 9;
			NumberLabel.Text = "Date of publication";
			// 
			// AuthorLabel
			// 
			AuthorLabel.AutoSize = true;
			AuthorLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			AuthorLabel.Location = new Point(140, 92);
			AuthorLabel.Name = "AuthorLabel";
			AuthorLabel.Size = new Size(70, 25);
			AuthorLabel.TabIndex = 8;
			AuthorLabel.Text = "Author";
			// 
			// TitleLabel
			// 
			TitleLabel.AutoSize = true;
			TitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			TitleLabel.Location = new Point(162, 22);
			TitleLabel.Name = "TitleLabel";
			TitleLabel.Size = new Size(48, 25);
			TitleLabel.TabIndex = 7;
			TitleLabel.Text = "Title";
			// 
			// DesctiptionTextBox
			// 
			DesctiptionTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			DesctiptionTextBox.Location = new Point(223, 240);
			DesctiptionTextBox.Multiline = true;
			DesctiptionTextBox.Name = "DesctiptionTextBox";
			DesctiptionTextBox.Size = new Size(541, 161);
			DesctiptionTextBox.TabIndex = 14;
			// 
			// DesctiptionLabel
			// 
			DesctiptionLabel.AutoSize = true;
			DesctiptionLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			DesctiptionLabel.Location = new Point(102, 240);
			DesctiptionLabel.Name = "DesctiptionLabel";
			DesctiptionLabel.Size = new Size(108, 25);
			DesctiptionLabel.TabIndex = 15;
			DesctiptionLabel.Text = "Description";
			// 
			// DateOfPublicationDatePicker
			// 
			DateOfPublicationDatePicker.CalendarFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			DateOfPublicationDatePicker.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			DateOfPublicationDatePicker.Format = DateTimePickerFormat.Short;
			DateOfPublicationDatePicker.Location = new Point(223, 163);
			DateOfPublicationDatePicker.Name = "DateOfPublicationDatePicker";
			DateOfPublicationDatePicker.Size = new Size(146, 32);
			DateOfPublicationDatePicker.TabIndex = 16;
			// 
			// UpdateBookForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 490);
			Controls.Add(DateOfPublicationDatePicker);
			Controls.Add(DesctiptionLabel);
			Controls.Add(DesctiptionTextBox);
			Controls.Add(SaveButton);
			Controls.Add(AuthorTextBox);
			Controls.Add(TitleTextBox);
			Controls.Add(NumberLabel);
			Controls.Add(AuthorLabel);
			Controls.Add(TitleLabel);
			Name = "UpdateBookForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "UpdateBook";
			Load += UpdateBookForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button SaveButton;
		private TextBox AuthorTextBox;
		private TextBox TitleTextBox;
		private Label NumberLabel;
		private Label AuthorLabel;
		private Label TitleLabel;
		private TextBox DesctiptionTextBox;
		private Label DesctiptionLabel;
		private DateTimePicker DateOfPublicationDatePicker;
	}
}