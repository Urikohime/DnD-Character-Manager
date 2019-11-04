namespace DnD_Character_Manager
{
    partial class OptionsForm
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
            this.OChangeSaveDirBTN = new System.Windows.Forms.Button();
            this.OBackBtn = new System.Windows.Forms.Button();
            this.OChangeDirLabel = new System.Windows.Forms.Label();
            this.OBackLabel = new System.Windows.Forms.Label();
            this.OCurrentDirLabel = new System.Windows.Forms.Label();
            this.OBackPanel = new System.Windows.Forms.Panel();
            this.OBackPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OChangeSaveDirBTN
            // 
            this.OChangeSaveDirBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OChangeSaveDirBTN.Location = new System.Drawing.Point(3, 3);
            this.OChangeSaveDirBTN.Name = "OChangeSaveDirBTN";
            this.OChangeSaveDirBTN.Size = new System.Drawing.Size(160, 24);
            this.OChangeSaveDirBTN.TabIndex = 0;
            this.OChangeSaveDirBTN.Text = "Change Save Directory";
            this.OChangeSaveDirBTN.UseVisualStyleBackColor = true;
            this.OChangeSaveDirBTN.Click += new System.EventHandler(this.OChangeSaveDirBTN_Click);
            // 
            // OBackBtn
            // 
            this.OBackBtn.Location = new System.Drawing.Point(3, 75);
            this.OBackBtn.Name = "OBackBtn";
            this.OBackBtn.Size = new System.Drawing.Size(160, 23);
            this.OBackBtn.TabIndex = 1;
            this.OBackBtn.Text = "Back";
            this.OBackBtn.UseVisualStyleBackColor = true;
            this.OBackBtn.Click += new System.EventHandler(this.OBackBtn_Click);
            // 
            // OChangeDirLabel
            // 
            this.OChangeDirLabel.AutoSize = true;
            this.OChangeDirLabel.Location = new System.Drawing.Point(169, 10);
            this.OChangeDirLabel.Name = "OChangeDirLabel";
            this.OChangeDirLabel.Size = new System.Drawing.Size(301, 13);
            this.OChangeDirLabel.TabIndex = 2;
            this.OChangeDirLabel.Text = "Change the Directory in which the Character files will be stored";
            // 
            // OBackLabel
            // 
            this.OBackLabel.AutoSize = true;
            this.OBackLabel.Location = new System.Drawing.Point(169, 80);
            this.OBackLabel.Name = "OBackLabel";
            this.OBackLabel.Size = new System.Drawing.Size(134, 13);
            this.OBackLabel.TabIndex = 2;
            this.OBackLabel.Text = "Go back to the Main Menu";
            // 
            // OCurrentDirLabel
            // 
            this.OCurrentDirLabel.AutoSize = true;
            this.OCurrentDirLabel.Location = new System.Drawing.Point(3, 30);
            this.OCurrentDirLabel.Name = "OCurrentDirLabel";
            this.OCurrentDirLabel.Size = new System.Drawing.Size(89, 13);
            this.OCurrentDirLabel.TabIndex = 3;
            this.OCurrentDirLabel.Text = "Current Directory:";
            // 
            // OBackPanel
            // 
            this.OBackPanel.BackColor = System.Drawing.Color.BurlyWood;
            this.OBackPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OBackPanel.Controls.Add(this.OBackLabel);
            this.OBackPanel.Controls.Add(this.OCurrentDirLabel);
            this.OBackPanel.Controls.Add(this.OBackBtn);
            this.OBackPanel.Controls.Add(this.OChangeSaveDirBTN);
            this.OBackPanel.Controls.Add(this.OChangeDirLabel);
            this.OBackPanel.ForeColor = System.Drawing.Color.DimGray;
            this.OBackPanel.Location = new System.Drawing.Point(15, 12);
            this.OBackPanel.Name = "OBackPanel";
            this.OBackPanel.Size = new System.Drawing.Size(478, 103);
            this.OBackPanel.TabIndex = 8;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(511, 132);
            this.Controls.Add(this.OBackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OptionsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OClosed);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.OBackPanel.ResumeLayout(false);
            this.OBackPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OChangeSaveDirBTN;
        private System.Windows.Forms.Button OBackBtn;
        private System.Windows.Forms.Label OChangeDirLabel;
        private System.Windows.Forms.Label OBackLabel;
        private System.Windows.Forms.Label OCurrentDirLabel;
        private System.Windows.Forms.Panel OBackPanel;
    }
}