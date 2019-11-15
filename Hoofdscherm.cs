using System;
using System.Drawing;
using System.Windows.Forms;

namespace SchetsEditor
{
    public class Hoofdscherm : Form
    {
        MenuStrip MenuStrip;

        public Hoofdscherm()
        {
            ClientSize = new Size(800, 600);
            MenuStrip = new MenuStrip();
            Controls.Add(MenuStrip);
            MaakFileMenu();
            MaakHelpMenu();
            Text = "Schets editor";
            IsMdiContainer = true;
            MainMenuStrip = MenuStrip;
        }
        private void MaakFileMenu()
        {
            ToolStripDropDownItem menu;
            menu = new ToolStripMenuItem("File");
            menu.DropDownItems.Add("Nieuw", null, this.Nieuw);
            menu.DropDownItems.Add("Exit", null, this.Afsluiten);
            MenuStrip.Items.Add(menu);
        }
        private void MaakHelpMenu()
        {
            ToolStripDropDownItem menu;
            menu = new ToolStripMenuItem("Help");
            menu.DropDownItems.Add("Over \"Schets\"", null, this.About);
            MenuStrip.Items.Add(menu);
        }
        private void About(object o, EventArgs ea)
        {
            MessageBox.Show("Schets versie 1.0\n(c) UU Informatica 2010"
                           , "Over \"Schets\""
                           , MessageBoxButtons.OK
                           , MessageBoxIcon.Information
                           );
        }

        private void Nieuw(object sender, EventArgs e)
        {
            SchetsWin s = new SchetsWin();
            s.MdiParent = this;
            s.Show();
        }
        private void Afsluiten(object sender, EventArgs e)
        {
            Close();
        }
    }
}
