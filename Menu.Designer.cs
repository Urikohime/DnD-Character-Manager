namespace DnD_Character_Manager
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.CreationBTN = new System.Windows.Forms.Button();
            this.CreatorLabel = new System.Windows.Forms.Label();
            this.UseBTN = new System.Windows.Forms.Button();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.MenuSettingsBtn = new System.Windows.Forms.Button();
            this.MButtonPanel = new System.Windows.Forms.Panel();
            this.MLabelPanel = new System.Windows.Forms.Panel();
            this.MButtonPanel.SuspendLayout();
            this.MLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreationBTN
            // 
            this.CreationBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreationBTN.Location = new System.Drawing.Point(13, 11);
            this.CreationBTN.Name = "CreationBTN";
            this.CreationBTN.Size = new System.Drawing.Size(120, 32);
            this.CreationBTN.TabIndex = 0;
            this.CreationBTN.Text = "Create Character";
            this.CreationBTN.UseVisualStyleBackColor = true;
            this.CreationBTN.Click += new System.EventHandler(this.CreationBTN_Click);
            // 
            // CreatorLabel
            // 
            this.CreatorLabel.AutoSize = true;
            this.CreatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatorLabel.Location = new System.Drawing.Point(9, 132);
            this.CreatorLabel.Name = "CreatorLabel";
            this.CreatorLabel.Size = new System.Drawing.Size(207, 13);
            this.CreatorLabel.TabIndex = 20;
            this.CreatorLabel.Text = "Made by: Patrik Schodrowski (aka.: Neko)";
            // 
            // UseBTN
            // 
            this.UseBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseBTN.Location = new System.Drawing.Point(13, 57);
            this.UseBTN.Name = "UseBTN";
            this.UseBTN.Size = new System.Drawing.Size(120, 32);
            this.UseBTN.TabIndex = 21;
            this.UseBTN.Text = "Load Character";
            this.UseBTN.UseVisualStyleBackColor = true;
            this.UseBTN.Click += new System.EventHandler(this.UseBTN_Click);
            // 
            // MenuLabel
            // 
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuLabel.Location = new System.Drawing.Point(16, 11);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(396, 75);
            this.MenuLabel.TabIndex = 22;
            this.MenuLabel.Text = resources.GetString("MenuLabel.Text");
            // 
            // MenuSettingsBtn
            // 
            this.MenuSettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuSettingsBtn.ForeColor = System.Drawing.Color.DimGray;
            this.MenuSettingsBtn.Location = new System.Drawing.Point(531, 125);
            this.MenuSettingsBtn.Name = "MenuSettingsBtn";
            this.MenuSettingsBtn.Size = new System.Drawing.Size(78, 25);
            this.MenuSettingsBtn.TabIndex = 23;
            this.MenuSettingsBtn.Text = "Options";
            this.MenuSettingsBtn.UseVisualStyleBackColor = true;
            this.MenuSettingsBtn.Click += new System.EventHandler(this.MenuSettingsBtn_Click);
            // 
            // MButtonPanel
            // 
            this.MButtonPanel.BackColor = System.Drawing.Color.BurlyWood;
            this.MButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MButtonPanel.Controls.Add(this.UseBTN);
            this.MButtonPanel.Controls.Add(this.CreationBTN);
            this.MButtonPanel.ForeColor = System.Drawing.Color.DimGray;
            this.MButtonPanel.Location = new System.Drawing.Point(12, 13);
            this.MButtonPanel.Name = "MButtonPanel";
            this.MButtonPanel.Size = new System.Drawing.Size(151, 105);
            this.MButtonPanel.TabIndex = 24;
            // 
            // MLabelPanel
            // 
            this.MLabelPanel.BackColor = System.Drawing.Color.BurlyWood;
            this.MLabelPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MLabelPanel.Controls.Add(this.MenuLabel);
            this.MLabelPanel.ForeColor = System.Drawing.Color.DimGray;
            this.MLabelPanel.Location = new System.Drawing.Point(169, 13);
            this.MLabelPanel.Name = "MLabelPanel";
            this.MLabelPanel.Size = new System.Drawing.Size(426, 105);
            this.MLabelPanel.TabIndex = 24;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(608, 149);
            this.Controls.Add(this.MenuSettingsBtn);
            this.Controls.Add(this.CreatorLabel);
            this.Controls.Add(this.MLabelPanel);
            this.Controls.Add(this.MButtonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.MButtonPanel.ResumeLayout(false);
            this.MLabelPanel.ResumeLayout(false);
            this.MLabelPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreationBTN;
        private System.Windows.Forms.Label CreatorLabel;
        private System.Windows.Forms.Button UseBTN;
        private System.Windows.Forms.Label MenuLabel;
        private System.Windows.Forms.Button MenuSettingsBtn;
        private System.Windows.Forms.Panel MButtonPanel;
        private System.Windows.Forms.Panel MLabelPanel;
    }
}