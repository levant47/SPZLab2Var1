namespace SPZLab2Var1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateAutoShopButton = new System.Windows.Forms.Button();
            this.autoShopsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CreateAutoShopButton
            // 
            this.CreateAutoShopButton.Location = new System.Drawing.Point(38, 27);
            this.CreateAutoShopButton.Name = "CreateAutoShopButton";
            this.CreateAutoShopButton.Size = new System.Drawing.Size(133, 23);
            this.CreateAutoShopButton.TabIndex = 0;
            this.CreateAutoShopButton.Text = "Create Auto Shop";
            this.CreateAutoShopButton.UseVisualStyleBackColor = true;
            this.CreateAutoShopButton.Click += new System.EventHandler(this.CreateAutoShopButton_Click);
            // 
            // autoShopsListBox
            // 
            this.autoShopsListBox.FormattingEnabled = true;
            this.autoShopsListBox.ItemHeight = 15;
            this.autoShopsListBox.Location = new System.Drawing.Point(38, 85);
            this.autoShopsListBox.Name = "autoShopsListBox";
            this.autoShopsListBox.Size = new System.Drawing.Size(133, 199);
            this.autoShopsListBox.TabIndex = 3;
            this.autoShopsListBox.DoubleClick += new System.EventHandler(this.autoShopsListBox_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.autoShopsListBox);
            this.Controls.Add(this.CreateAutoShopButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateAutoShopButton;
        private System.Windows.Forms.ListBox autoShopsListBox;
    }
}

