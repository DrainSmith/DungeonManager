using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Settings.LoadSettings();
            RefreshCharacters();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new CreateCharacterForm();
            f.ShowDialog();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                RefreshCharacters();
            }
            Settings.SaveSettings();
        }

        public void RefreshCharacters()
        {
            dataGridView1.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("guid", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Armor Class", typeof(int)); 
            dt.Columns.Add("Passive Perception", typeof(int));
            dt.Columns.Add("Spell DC", typeof(int));
            //dt.Columns.Add("ac", typeof(int));
            for (int x = 0; x < Settings.Characters.Count; x++)
            {
                int pp = 10 + Util.GetModifier(Settings.Characters[x].Wisdom);
                int dc = Util.GetSpellDC(Settings.Characters[x]);
                dt.Rows.Add(Settings.Characters[x]._guid, Settings.Characters[x].Name, Settings.Characters[x].ArmorClass, pp, dc);
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string _guid = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                var c = Settings.Characters.Find(ch => ch._guid == _guid);
                var f = new CreateCharacterForm(c);
                f.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.SaveSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string _guid = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                int i = Settings.Characters.FindIndex(ch => ch._guid == _guid);
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(rowIndex);
                Settings.Characters.RemoveAt(i);
                Settings.SaveSettings();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string _guid = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                var c = Settings.Characters.Find(ch => ch._guid == _guid);
                var f = new CreateCharacterForm(c);
                f.Show();
            }
        }
    }
}
