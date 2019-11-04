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
    public partial class OptionsForm : Form
    {
        private String SPath;
        private Menu Paren;

        public OptionsForm(Menu Parent)
        {
            Paren = Parent;
            InitializeComponent();
        }

        private void OChangeSaveDirBTN_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {
                DialogResult DR = FBD.ShowDialog();

                if ( DR == DialogResult.OK && !String.IsNullOrEmpty(FBD.SelectedPath))
                {
                    try
                    {
                        using (StreamWriter SW = new StreamWriter("settings.ini"))
                        {
                            SW.Write("!!THIS FILE NEEDS TO BE IN THE SAME DIRECTORY AS THE APPLICATION!!" + "\n \n" +
                                "PATH=" + FBD.SelectedPath);
                        }
                    }
                    catch (Exception) { MessageBox.Show("Oh no!\nSomething went wrong!", "Error", MessageBoxButtons.OK); }
                    OCurrentDirLabel.Text = "Current Directory= " + FBD.SelectedPath;
                }
                else { OCurrentDirLabel.Text = "Current Directory= " + SPath; }
                
            }
        }

        private void OBackBtn_Click(object sender, EventArgs e)
        {
            Paren.Visible = true;
            this.Dispose();
            this.Close();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader SR = new StreamReader("settings.ini"))
                {
                    while (!SR.EndOfStream)
                    {
                        String DATATEMP = SR.ReadLine();
                        String[] DATASEC = DATATEMP.Split('=');
                        if (DATASEC[0] == "PATH") { SPath = DATASEC[1]; }
                    }
                }
            }
            catch (Exception) { SPath = "c:\\"; }
            OCurrentDirLabel.Text = "Current Directory= " + SPath;
        }

        private void OClosed(object sender, FormClosedEventArgs e)
        {
            Paren.Visible = true;
            this.Dispose();
            this.Close();
        }
    }
}
