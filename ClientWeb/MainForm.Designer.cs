namespace ClientWeb
{
	partial class MainPage
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
			menuStrip1 = new MenuStrip();
			LibraryMenuComboBox = new ToolStripComboBox();
			SearchMenuItem = new ToolStripMenuItem();
			MainPagePanel = new Panel();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(20, 20);
			menuStrip1.Items.AddRange(new ToolStripItem[] { LibraryMenuComboBox, SearchMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1182, 40);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// LibraryMenuComboBox
			// 
			LibraryMenuComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			LibraryMenuComboBox.Name = "LibraryMenuComboBox";
			LibraryMenuComboBox.Size = new Size(160, 36);
			LibraryMenuComboBox.SelectedIndexChanged += LibraryMenuComboBox_SelectedIndexChanged;
			// 
			// SearchMenuItem
			// 
			SearchMenuItem.BackColor = SystemColors.ControlLight;
			SearchMenuItem.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			SearchMenuItem.Margin = new Padding(2);
			SearchMenuItem.Name = "SearchMenuItem";
			SearchMenuItem.Size = new Size(83, 32);
			SearchMenuItem.Text = "Search";
			SearchMenuItem.Click += SearchMenuItem_Click;
			// 
			// MainPagePanel
			// 
			MainPagePanel.AutoScroll = true;
			MainPagePanel.Location = new Point(0, 43);
			MainPagePanel.Name = "MainPagePanel";
			MainPagePanel.Size = new Size(1182, 707);
			MainPagePanel.TabIndex = 1;
			// 
			// MainPage
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1182, 753);
			Controls.Add(MainPagePanel);
			Controls.Add(menuStrip1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MainMenuStrip = menuStrip1;
			Name = "MainPage";
			ShowIcon = false;
			Text = "MainPage";
			Load += MainPage_Load;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripComboBox LibraryMenuComboBox;
		private ToolStripMenuItem SearchMenuItem;
		private Panel MainPagePanel;
	}
}