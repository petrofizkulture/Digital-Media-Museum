namespace DigitalMediaMuseum
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem editMenu;
        private ToolStripMenuItem toolsMenu;
        private ToolStripMenuItem databaseMenu;
        private ToolStripMenuItem helpMenu;

        private DataGridView entryGrid;

        private Panel detailsPanel;
        private Label detailsLabel;

        private Panel artworkPanel;
        private Label artworkLabel;

        private Label entryCountLabel;
        private Label dbStatusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            editMenu = new ToolStripMenuItem();
            toolsMenu = new ToolStripMenuItem();
            databaseMenu = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            entryGrid = new DataGridView();
            detailsPanel = new Panel();
            detailsLabel = new Label();
            artworkPanel = new Panel();
            artworkLabel = new Label();
            entryCountLabel = new Label();
            dbStatusLabel = new Label();
            keywordSearchButton = new Button();
            keywordSearchBox = new TextBox();
            idSearchButton = new Button();
            idSearchBox = new TextBox();
            categoryFilter = new ComboBox();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)entryGrid).BeginInit();
            detailsPanel.SuspendLayout();
            artworkPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, toolsMenu, databaseMenu, helpMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(986, 24);
            menuStrip.TabIndex = 0;
            // 
            // fileMenu
            // 
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "File";
            // 
            // editMenu
            // 
            editMenu.Name = "editMenu";
            editMenu.Size = new Size(39, 20);
            editMenu.Text = "Edit";
            // 
            // toolsMenu
            // 
            toolsMenu.Name = "toolsMenu";
            toolsMenu.Size = new Size(47, 20);
            toolsMenu.Text = "Tools";
            // 
            // databaseMenu
            // 
            databaseMenu.Name = "databaseMenu";
            databaseMenu.Size = new Size(67, 20);
            databaseMenu.Text = "Database";
            // 
            // helpMenu
            // 
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(44, 20);
            helpMenu.Text = "Help";
            // 
            // entryGrid
            // 
            entryGrid.AllowUserToAddRows = false;
            entryGrid.AllowUserToDeleteRows = false;
            entryGrid.Location = new Point(10, 70);
            entryGrid.Name = "entryGrid";
            entryGrid.ReadOnly = true;
            entryGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            entryGrid.Size = new Size(960, 300);
            entryGrid.TabIndex = 8;
            // 
            // detailsPanel
            // 
            detailsPanel.AutoScroll = true;
            detailsPanel.BorderStyle = BorderStyle.FixedSingle;
            detailsPanel.Controls.Add(detailsLabel);
            detailsPanel.Location = new Point(10, 380);
            detailsPanel.Name = "detailsPanel";
            detailsPanel.Size = new Size(480, 160);
            detailsPanel.TabIndex = 9;
            // 
            // detailsLabel
            // 
            detailsLabel.AutoSize = true;
            detailsLabel.Location = new Point(5, 5);
            detailsLabel.MaximumSize = new Size(460, 0);
            detailsLabel.Name = "detailsLabel";
            detailsLabel.Size = new Size(165, 15);
            detailsLabel.TabIndex = 0;
            detailsLabel.Text = "Select an entry to view details.";
            // 
            // artworkPanel
            // 
            artworkPanel.BorderStyle = BorderStyle.FixedSingle;
            artworkPanel.Controls.Add(artworkLabel);
            artworkPanel.Location = new Point(500, 380);
            artworkPanel.Name = "artworkPanel";
            artworkPanel.Size = new Size(470, 160);
            artworkPanel.TabIndex = 10;
            // 
            // artworkLabel
            // 
            artworkLabel.Dock = DockStyle.Fill;
            artworkLabel.Location = new Point(0, 0);
            artworkLabel.Name = "artworkLabel";
            artworkLabel.Size = new Size(468, 158);
            artworkLabel.TabIndex = 0;
            artworkLabel.Text = "No Image Available";
            artworkLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // entryCountLabel
            // 
            entryCountLabel.AutoSize = true;
            entryCountLabel.Location = new Point(10, 550);
            entryCountLabel.Name = "entryCountLabel";
            entryCountLabel.Size = new Size(54, 15);
            entryCountLabel.TabIndex = 11;
            entryCountLabel.Text = "Entries: 0";
            // 
            // dbStatusLabel
            // 
            dbStatusLabel.AutoSize = true;
            dbStatusLabel.Location = new Point(814, 550);
            dbStatusLabel.Name = "dbStatusLabel";
            dbStatusLabel.Size = new Size(160, 15);
            dbStatusLabel.TabIndex = 12;
            dbStatusLabel.Text = "Database Loaded: o7_db.json";
            // 
            // keywordSearchButton
            // 
            keywordSearchButton.Location = new Point(805, 30);
            keywordSearchButton.Name = "keywordSearchButton";
            keywordSearchButton.Size = new Size(60, 23);
            keywordSearchButton.TabIndex = 7;
            keywordSearchButton.Text = "Search";
            // 
            // keywordSearchBox
            // 
            keywordSearchBox.Location = new Point(600, 30);
            keywordSearchBox.Name = "keywordSearchBox";
            keywordSearchBox.Size = new Size(200, 23);
            keywordSearchBox.TabIndex = 6;
            keywordSearchBox.TextChanged += keywordSearchBox_TextChanged;
            // 
            // idSearchButton
            // 
            idSearchButton.Location = new Point(222, 30);
            idSearchButton.Name = "idSearchButton";
            idSearchButton.Size = new Size(40, 23);
            idSearchButton.TabIndex = 5;
            idSearchButton.Text = "Go";
            // 
            // idSearchBox
            // 
            idSearchBox.Location = new Point(116, 30);
            idSearchBox.Name = "idSearchBox";
            idSearchBox.Size = new Size(100, 23);
            idSearchBox.TabIndex = 4;
            idSearchBox.TextChanged += idSearchBox_TextChanged;
            // 
            // categoryFilter
            // 
            categoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryFilter.Items.AddRange(new object[] { "Outfit7", "Wii", "Android (INS), OS (INS)" });
            categoryFilter.Location = new Point(10, 30);
            categoryFilter.Name = "categoryFilter";
            categoryFilter.Size = new Size(100, 23);
            categoryFilter.TabIndex = 1;
            categoryFilter.SelectedIndexChanged += categoryFilter_SelectedIndexChanged;
            // 
            // Form1
            // 
            ClientSize = new Size(986, 569);
            Controls.Add(menuStrip);
            Controls.Add(categoryFilter);
            Controls.Add(idSearchBox);
            Controls.Add(idSearchButton);
            Controls.Add(keywordSearchBox);
            Controls.Add(keywordSearchButton);
            Controls.Add(entryGrid);
            Controls.Add(detailsPanel);
            Controls.Add(artworkPanel);
            Controls.Add(entryCountLabel);
            Controls.Add(dbStatusLabel);
            MainMenuStrip = menuStrip;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digital Media Museum - Lost and Unseen Software Database";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)entryGrid).EndInit();
            detailsPanel.ResumeLayout(false);
            detailsPanel.PerformLayout();
            artworkPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Button keywordSearchButton;
        private TextBox keywordSearchBox;
        private Button idSearchButton;
        private TextBox idSearchBox;
        private ComboBox categoryFilter;
    }
}
