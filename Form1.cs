using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DigitalMediaMuseum
{
    public partial class Form1 : Form
    {
        private List<DatabaseEntry> entries = new List<DatabaseEntry>();

        public Form1()
        {
            InitializeComponent();
            SetupGridColumns();
            PopulateGrid();
        }

        private void dbStatusLabel_Click(object sender, EventArgs e)
        {
            // Do nothing, or add behavior later
        }


        // -----------------------------
        // Load JSON
        // -----------------------------
        private void LoadJsonDatabase(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show($"Database file not found:\n{path}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string json = File.ReadAllText(path);
                entries = JsonSerializer.Deserialize<List<DatabaseEntry>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                dbStatusLabel.Text = $"Database Loaded: {Path.GetFileName(path)}";
                entryCountLabel.Text = $"Entries: {entries.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load JSON:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add to Form1 class if missing
        private bool suppressCategoryChange = false;

        // -----------------------------
        // Setup DataGridView Columns
        // -----------------------------
        private void SetupGridColumns()
        {
            entryGrid.Columns.Clear();

            entryGrid.Columns.Add("id", "ID");
            entryGrid.Columns.Add("name", "Name");
            entryGrid.Columns.Add("category", "Category");
            entryGrid.Columns.Add("year", "Year");
            entryGrid.Columns.Add("status", "Status");

            entryGrid.CellClick += EntryGrid_CellClick;
        }

        // -----------------------------
        // Populate DataGridView
        // -----------------------------
        private void PopulateGrid()
        {
            entryGrid.Rows.Clear();

            foreach (var e in entries)
            {
                entryGrid.Rows.Add(e.id, e.name, e.category, e.release_year, e.status);
            }
        }

        // -----------------------------
        // When user clicks an entry
        // -----------------------------
        private void EntryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string id = entryGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            var entry = entries.Find(x => x.id == id);

            if (entry == null) return;

            // Update details panel
            detailsLabel.Text =
                $"Name: {entry.name}\n" +
                $"Category: {entry.category}\n" +
                $"Developer: {entry.developer}\n" +
                $"Status: {entry.status}\n" +
                $"Year: {entry.release_year}\n\n" +
                $"Description:\n{entry.description}\n\n" +
                $"Controversy:\n{entry.controversy_description}";

            // Update artwork panel
            string iconPath = entry.icon;

            if (File.Exists(iconPath))
            {
                artworkPanel.BackgroundImage = Image.FromFile(iconPath);
                artworkPanel.BackgroundImageLayout = ImageLayout.Zoom;
                artworkLabel.Visible = false;
            }
            else
            {
                artworkPanel.BackgroundImage = null;
                artworkLabel.Visible = true;
            }
        }

        private void shellToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutDigitalMediaMuseumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox = new AboutBox1();
            aboutbox.Show();
        }

        private void detailsLabel_Click(object sender, EventArgs e)
        {

        }

        private void categoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressCategoryChange) return;
            if (categoryFilter == null) return;
            if (entryGrid == null) return;

            var selected = categoryFilter.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(selected)) return;

            string s = selected.Trim();

            // Switch to Wii DB
            if (string.Equals(s, "Wii", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    suppressCategoryChange = true;
                    LoadJsonDatabase("db/wii_db.json");   // loads db/wii_db.json and updates UI
                    PopulateGrid();   // optional: refresh categories for the newly loaded DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load Wii database:\n{ex.Message}", "Load Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    suppressCategoryChange = false;
                }
                return;
            }

            if (string.Equals(s, "Android (INS)", StringComparison.OrdinalIgnoreCase)
                || string.Equals(s, "Android Market", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    suppressCategoryChange = true;
                    LoadJsonDatabase("db/amapk_db.json");
                    PopulateGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load Android Market (INSIDER) database:\n{ex.Message}", "Load Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    suppressCategoryChange = false;
                }
                return;
            }

            // Switch to Outfit7 / O7 DB
            if (string.Equals(s, "Outfit7", StringComparison.OrdinalIgnoreCase)
                || string.Equals(s, "Outfit 7", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    suppressCategoryChange = true;
                    LoadJsonDatabase("db/o7_db.json");    // loads db/o7_db.json and updates UI
                    PopulateGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load Outfit7 database:\n{ex.Message}", "Load Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    suppressCategoryChange = false;
                }
                return;
            }

            // If you ever add other category strings, filter in-memory by category
            entryGrid.Rows.Clear();
            if (entries == null) return;

            foreach (var ent in entries)
            {
                if (ent == null) continue;
                if (string.Equals(ent.category?.Trim(), s, StringComparison.OrdinalIgnoreCase))
                {
                    entryGrid.Rows.Add(
                        ent.id ?? string.Empty,
                        ent.name ?? string.Empty,
                        ent.category ?? string.Empty,
                        ent.release_year.ToString(),
                        ent.status ?? string.Empty
                    );
                }
            }
        }

        private void statusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yearFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void idSearchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void keywordSearchBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

    // -----------------------------
    // JSON Schema Class
    // -----------------------------
    public class DatabaseEntry
    {
        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string developer { get; set; }
        public string status { get; set; }
        public List<string> platform { get; set; }
        public int release_year { get; set; }
        public string description { get; set; }
        public string controversy_description { get; set; }
        public string icon { get; set; }
    }
}
