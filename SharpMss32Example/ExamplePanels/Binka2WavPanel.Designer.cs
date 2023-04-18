namespace SharpMss32Example
{
    partial class Binka2WavPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label2;
            this.letsGoButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 14);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(26, 13);
            label2.TabIndex = 5;
            label2.Text = "File:";
            // 
            // letsGoButton
            // 
            this.letsGoButton.Location = new System.Drawing.Point(137, 56);
            this.letsGoButton.Name = "letsGoButton";
            this.letsGoButton.Size = new System.Drawing.Size(128, 23);
            this.letsGoButton.TabIndex = 2;
            this.letsGoButton.Text = "Convert to Wav";
            this.letsGoButton.Click += new System.EventHandler(this.letsGoButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(3, 56);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(128, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.Location = new System.Drawing.Point(3, 30);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(262, 23);
            this.fileLabel.TabIndex = 4;
            this.fileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Binka2WavPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(label2);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.letsGoButton);
            this.Name = "Binka2WavPanel";
            this.Size = new System.Drawing.Size(417, 491);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button letsGoButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label fileLabel;
    }
}
