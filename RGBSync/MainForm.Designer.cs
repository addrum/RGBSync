namespace RGBSync
{
    partial class MainForm
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
            this.numericUpDownR = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownG = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonHue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownR
            // 
            this.numericUpDownR.Location = new System.Drawing.Point(13, 13);
            this.numericUpDownR.Name = "numericUpDownR";
            this.numericUpDownR.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownR.TabIndex = 0;
            this.numericUpDownR.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownG
            // 
            this.numericUpDownG.Location = new System.Drawing.Point(119, 12);
            this.numericUpDownG.Name = "numericUpDownG";
            this.numericUpDownG.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownG.TabIndex = 1;
            this.numericUpDownG.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownB
            // 
            this.numericUpDownB.Location = new System.Drawing.Point(225, 12);
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownB.TabIndex = 2;
            this.numericUpDownB.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(119, 39);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(100, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonHue
            // 
            this.buttonHue.Location = new System.Drawing.Point(119, 88);
            this.buttonHue.Name = "buttonHue";
            this.buttonHue.Size = new System.Drawing.Size(100, 41);
            this.buttonHue.TabIndex = 4;
            this.buttonHue.Text = "Connect Hue Bridge";
            this.buttonHue.UseVisualStyleBackColor = true;
            this.buttonHue.Click += new System.EventHandler(this.buttonHue_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 141);
            this.Controls.Add(this.buttonHue);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.numericUpDownB);
            this.Controls.Add(this.numericUpDownG);
            this.Controls.Add(this.numericUpDownR);
            this.Name = "MainForm";
            this.Text = "RGBSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NumericUpDown numericUpDownR;
        public System.Windows.Forms.NumericUpDown numericUpDownG;
        public System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonHue;
    }
}

