namespace UniversalModManager
{
    partial class Form1
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
            this.browseForFolderPopup = new System.Windows.Forms.FolderBrowserDialog();
            this.modSelectBox = new System.Windows.Forms.ListBox();
            this.gameSelectBox = new System.Windows.Forms.ListBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.importGameButton = new System.Windows.Forms.Button();
            this.importModButton = new System.Windows.Forms.Button();
            this.deleteModButton = new System.Windows.Forms.Button();
            this.deleteGameButton = new System.Windows.Forms.Button();
            this.deleteModPopup = new System.Windows.Forms.HelpProvider();
            this.deleteGamePopup = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // browseForFolderPopup
            // 
            this.browseForFolderPopup.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // modSelectBox
            // 
            this.modSelectBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modSelectBox.FormattingEnabled = true;
            this.modSelectBox.Items.AddRange(new object[] {
            "None Selelected"});
            this.modSelectBox.Location = new System.Drawing.Point(270, 12);
            this.modSelectBox.Name = "modSelectBox";
            this.modSelectBox.Size = new System.Drawing.Size(220, 533);
            this.modSelectBox.TabIndex = 0;
            this.modSelectBox.SelectedIndexChanged += new System.EventHandler(this.modSelectBox_SelectedIndexChanged);
            // 
            // gameSelectBox
            // 
            this.gameSelectBox.FormattingEnabled = true;
            this.gameSelectBox.Items.AddRange(new object[] {
            "None Selected"});
            this.gameSelectBox.Location = new System.Drawing.Point(131, 11);
            this.gameSelectBox.Name = "gameSelectBox";
            this.gameSelectBox.Size = new System.Drawing.Size(133, 537);
            this.gameSelectBox.TabIndex = 1;
            this.gameSelectBox.SelectedIndexChanged += new System.EventHandler(this.gameSelectBox_SelectedIndexChanged);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 12);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(113, 46);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply Modded State";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // importGameButton
            // 
            this.importGameButton.Location = new System.Drawing.Point(12, 116);
            this.importGameButton.Name = "importGameButton";
            this.importGameButton.Size = new System.Drawing.Size(113, 46);
            this.importGameButton.TabIndex = 3;
            this.importGameButton.Text = "Import New Game";
            this.importGameButton.UseVisualStyleBackColor = true;
            this.importGameButton.Click += new System.EventHandler(this.importGameButton_Click);
            // 
            // importModButton
            // 
            this.importModButton.Location = new System.Drawing.Point(12, 64);
            this.importModButton.Name = "importModButton";
            this.importModButton.Size = new System.Drawing.Size(113, 46);
            this.importModButton.TabIndex = 4;
            this.importModButton.Text = "Import New Modded State";
            this.importModButton.UseVisualStyleBackColor = true;
            this.importModButton.Click += new System.EventHandler(this.importModButton_Click);
            // 
            // deleteModButton
            // 
            this.deleteModButton.Location = new System.Drawing.Point(12, 168);
            this.deleteModButton.Name = "deleteModButton";
            this.deleteModButton.Size = new System.Drawing.Size(113, 46);
            this.deleteModButton.TabIndex = 5;
            this.deleteModButton.Text = "Delete Mod";
            this.deleteModButton.UseVisualStyleBackColor = true;
            this.deleteModButton.Click += new System.EventHandler(this.deleteModButton_Click);
            // 
            // deleteGameButton
            // 
            this.deleteGameButton.Location = new System.Drawing.Point(12, 220);
            this.deleteGameButton.Name = "deleteGameButton";
            this.deleteGameButton.Size = new System.Drawing.Size(113, 45);
            this.deleteGameButton.TabIndex = 6;
            this.deleteGameButton.Text = "Delete Game";
            this.deleteGameButton.UseVisualStyleBackColor = true;
            this.deleteGameButton.Click += new System.EventHandler(this.deleteGameButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 560);
            this.Controls.Add(this.deleteGameButton);
            this.Controls.Add(this.deleteModButton);
            this.Controls.Add(this.importModButton);
            this.Controls.Add(this.importGameButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.gameSelectBox);
            this.Controls.Add(this.modSelectBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog browseForFolderPopup;
        private System.Windows.Forms.ListBox modSelectBox;
        private System.Windows.Forms.ListBox gameSelectBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button importGameButton;
        private System.Windows.Forms.Button importModButton;
        private System.Windows.Forms.Button deleteModButton;
        private System.Windows.Forms.Button deleteGameButton;
        private System.Windows.Forms.HelpProvider deleteModPopup;
        private System.Windows.Forms.HelpProvider deleteGamePopup;
    }
}

