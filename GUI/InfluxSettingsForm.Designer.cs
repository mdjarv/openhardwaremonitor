namespace OpenHardwareMonitor.GUI
{
    partial class InfluxSettingsForm
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
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.hostLabel = new System.Windows.Forms.Label();
            this.portNumericUpDn = new System.Windows.Forms.NumericUpDown();
            this.portLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDn)).BeginInit();
            this.SuspendLayout();
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(50, 6);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(181, 20);
            this.hostTextBox.TabIndex = 0;
            this.hostTextBox.Text = "localhost";
            this.hostTextBox.TextChanged += new System.EventHandler(this.hostTextBox_TextChanged);
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(12, 9);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(32, 13);
            this.hostLabel.TabIndex = 1;
            this.hostLabel.Text = "Host:";
            // 
            // portNumericUpDn
            // 
            this.portNumericUpDn.Location = new System.Drawing.Point(275, 7);
            this.portNumericUpDn.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumericUpDn.Name = "portNumericUpDn";
            this.portNumericUpDn.Size = new System.Drawing.Size(65, 20);
            this.portNumericUpDn.TabIndex = 2;
            this.portNumericUpDn.Value = new decimal(new int[] {
            8086,
            0,
            0,
            0});
            this.portNumericUpDn.ValueChanged += new System.EventHandler(this.portNumericUpDn_ValueChanged);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(237, 9);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "Port:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(184, 33);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(265, 33);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // InfluxSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 66);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.portNumericUpDn);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.hostTextBox);
            this.Name = "InfluxSettingsForm";
            this.Text = "InfluxDB Settings";
            this.Load += new System.EventHandler(this.InfluxSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.NumericUpDown portNumericUpDn;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}