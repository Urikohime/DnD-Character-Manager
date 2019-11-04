using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DnD_Character_Manager
{
    public partial class Menu : Form
    {
        private String SPath;
        public Menu()
        {
            InitializeComponent();
        }

        private void CreationBTN_Click(object sender, EventArgs e)
        {
            CharacterForm UGCForm = new CharacterForm(this, SPath);
            UGCForm.Visible = true;
            UGCForm.Activate();
            this.Visible = false;
        }

        private void UseBTN_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.InitialDirectory = SPath;
                OFD.Filter = "DDC fies (*.ddc)|*.ddc";
                OFD.FilterIndex = 1;
                OFD.RestoreDirectory = true;

                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    CharacterForm UGCForm = new CharacterForm(this, OFD.FileName, SPath);
                    UGCForm.Visible = true;
                    UGCForm.Activate();
                    this.Visible = false;
                }
            }
        }

        private void MenuSettingsBtn_Click(object sender, EventArgs e)
        {
            OptionsForm OF = new OptionsForm(this);
            OF.Visible = true;
            OF.Activate();
            this.Visible = false;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                using(StreamReader SR = new StreamReader("settings.ini"))
                {
                    while(!SR.EndOfStream)
                    {
                        String DATATEMP = SR.ReadLine();
                        String[] DATASEC = DATATEMP.Split('=');
                        if (DATASEC[0] == "PATH") { SPath = DATASEC[1]; }
                    }
                }
            }
            catch(Exception) { SPath = "C:\\"; }
        }
    }
}
