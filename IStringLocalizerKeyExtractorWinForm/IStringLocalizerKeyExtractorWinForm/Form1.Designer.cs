namespace IStringLocalizerKeyExtractorWinForm
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
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.Browse = new System.Windows.Forms.Button();
            this.MainPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Variables = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResourcePath = new System.Windows.Forms.TextBox();
            this.ResoucePath = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(753, 94);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // MainPath
            // 
            this.MainPath.Location = new System.Drawing.Point(175, 94);
            this.MainPath.Name = "MainPath";
            this.MainPath.Size = new System.Drawing.Size(562, 20);
            this.MainPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Directory:";
            // 
            // Variables
            // 
            this.Variables.Location = new System.Drawing.Point(175, 155);
            this.Variables.Name = "Variables";
            this.Variables.Size = new System.Drawing.Size(562, 238);
            this.Variables.TabIndex = 3;
            this.Variables.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Variables (new line separated)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Resource path";
            // 
            // ResourcePath
            // 
            this.ResourcePath.Location = new System.Drawing.Point(175, 413);
            this.ResourcePath.Name = "ResourcePath";
            this.ResourcePath.Size = new System.Drawing.Size(562, 20);
            this.ResourcePath.TabIndex = 6;
            // 
            // ResoucePath
            // 
            this.ResoucePath.Location = new System.Drawing.Point(753, 413);
            this.ResoucePath.Name = "ResoucePath";
            this.ResoucePath.Size = new System.Drawing.Size(75, 23);
            this.ResoucePath.TabIndex = 7;
            this.ResoucePath.Text = "Browse";
            this.ResoucePath.UseVisualStyleBackColor = true;
            this.ResoucePath.Click += new System.EventHandler(this.ResoucePath_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(753, 467);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 8;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(175, 467);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 467);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Save location";
            // 
            // SaveLocation
            // 
            this.SaveLocation.Location = new System.Drawing.Point(175, 467);
            this.SaveLocation.Name = "SaveLocation";
            this.SaveLocation.Size = new System.Drawing.Size(562, 20);
            this.SaveLocation.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 581);
            this.Controls.Add(this.SaveLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.ResoucePath);
            this.Controls.Add(this.ResourcePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Variables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainPath);
            this.Controls.Add(this.Browse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox MainPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Variables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ResourcePath;
        private System.Windows.Forms.Button ResoucePath;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SaveLocation;
    }
}

