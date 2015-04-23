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
    public partial class ViewCharacterForm : Form
    {
        private Character _character; 

        public ViewCharacterForm(Character c)
        {
            _character = c;
            InitializeComponent();
            StrLabel.Text = c.Strength.ToString();
            ConLabel.Text = c.Constitution.ToString();
            DexLabel.Text = c.Dexterity.ToString();
            IntLabel.Text = c.Intelligence.ToString();
            WisLabel.Text = c.Wisdom.ToString();
            ChaLabel.Text = c.Charisma.ToString();
            StrModifierLabel.Text = Util.GetModifier(c.Strength).ToString();
            ConModifierLabel.Text = Util.GetModifier(c.Constitution).ToString();
            DexModifierLabel.Text = Util.GetModifier(c.Dexterity).ToString();
            IntModifierLabel.Text = Util.GetModifier(c.Intelligence).ToString();
            WisModifierLabel.Text = Util.GetModifier(c.Wisdom).ToString();
            ChaModifierLabel.Text = Util.GetModifier(c.Charisma).ToString();
            this.Text = c.Name;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new CreateCharacterForm(_character);
            f.Show();
        }
    }
}
