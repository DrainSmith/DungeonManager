using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace DungeonManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Settings.LoadSettings();
            Settings.MainForm = this;
            RefreshCharacters();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new CreateCharacterForm();
            f.Show();
            Settings.SaveSettings();
        }

        public void RefreshCharacters()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            
            dataGridView1.Columns.Add("guid", "Guid");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Armor Class", "Armor Class");
            dataGridView1.Columns.Add("Passive Perception", "Passive Perception");
            dataGridView1.Columns.Add("Spell DC", "Spell DC");

            for (int x = 0; x < Settings.Characters.Count; x++)
            {
                int pp = 10 + Util.GetModifier(Settings.Characters[x].Wisdom);
                int dc = Util.GetSpellDC(Settings.Characters[x]);

                dataGridView1.Rows.Add(Settings.Characters[x]._guid, Settings.Characters[x].Name, Settings.Characters[x].ArmorClass, pp, dc);
            }
            
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
                if (MessageBox.Show("Are you sure you want to permanently delete this character?", "DungeonManager", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    string _guid = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                    int i = Settings.Characters.FindIndex(ch => ch._guid == _guid);
                    //int rowIndex = dataGridView1.SelectedRows[0].Index;
                    //dataGridView1.Rows.RemoveAt(rowIndex);
                    Settings.Characters.RemoveAt(i);
                    Settings.SaveSettings();
                    RefreshCharacters();
                }
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

        private void ChracterUpButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                if (selectedRowIndex - 1 < 0)
                    return;
                else
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    dataGridView1.Rows.Remove(row);
                    dataGridView1.Rows.Insert(selectedRowIndex - 1, row);
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[selectedRowIndex - 1].Selected = true;
                }
            }
        }

        private void CharacterDownButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                if (selectedRowIndex +1 >= dataGridView1.Rows.Count)
                    return;
                else
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    dataGridView1.Rows.Remove(row);
                    dataGridView1.Rows.Insert(selectedRowIndex + 1, row);
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[selectedRowIndex + 1].Selected = true;
                }
            }
        }

        private void saveSelectedCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string _guid = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                var c = Settings.Characters.Find(ch => ch._guid == _guid);
                saveFileDialog1.FileName = c.Name + ".chr";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string settingsPath = saveFileDialog1.FileName;
                    


                    XmlSerializer xmlSerial = new XmlSerializer(typeof(Character));
                    try
                    {
                        using (Stream fStream = new FileStream(settingsPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            xmlSerial.Serialize(fStream, c);
                        }

                    }
                    catch (Exception exp)
                    {
                        System.Windows.Forms.MessageBox.Show("Could not save character to file. Check permissions.", "DungeonManager");
                    }
                }
            }
        }

        private void importCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string settingsPath = openFileDialog1.FileName;
                try
                {
                    Character XmlSave;
                    XmlSerializer xmlSerial = new XmlSerializer(typeof(Character));
                    using (Stream fStream = new FileStream(settingsPath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        XmlSave = (Character)xmlSerial.Deserialize(fStream);
                        XmlSave._guid = Guid.NewGuid().ToString();
                        Settings.Characters.Add(XmlSave);
                        Settings.SaveSettings();
                        RefreshCharacters();
                    }

                }
                catch (Exception exp)
                {

                }
            }
        }
    }
}
