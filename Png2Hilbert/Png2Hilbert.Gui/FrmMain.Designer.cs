namespace Png2Hilbert
{
    partial class FrmMain
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.grpSize = new System.Windows.Forms.GroupBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.grpSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(118, 10);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(327, 20);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = "C:\\Temporary\\anna-bw2.png";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(13, 13);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(79, 13);
            this.lblInput.TabIndex = 1;
            this.lblInput.Text = "Input file (PNG)";
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(12, 104);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(512, 512);
            this.picPreview.TabIndex = 2;
            this.picPreview.TabStop = false;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(453, 9);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 20);
            this.btnInput.TabIndex = 3;
            this.btnInput.Text = "Browse";
            this.btnInput.UseVisualStyleBackColor = true;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(453, 37);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 20);
            this.btnOutput.TabIndex = 6;
            this.btnOutput.Text = "Browse";
            this.btnOutput.UseVisualStyleBackColor = true;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(13, 40);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(99, 13);
            this.lblOutput.TabIndex = 5;
            this.lblOutput.Text = "Output file (G-code)";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(118, 37);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(327, 20);
            this.txtOutput.TabIndex = 4;
            this.txtOutput.Text = "C:\\Temporary\\anna.g";
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(541, 212);
            this.txtHeader.Multiline = true;
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHeader.Size = new System.Drawing.Size(249, 155);
            this.txtHeader.TabIndex = 7;
            this.txtHeader.Text = "G21\r\n\r\nM3 S100\r\n\r\nG0 X100 Y100 F4000\r\n";
            this.txtHeader.TextChanged += new System.EventHandler(this.txtHeader_TextChanged);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(544, 196);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(78, 13);
            this.lblHeader.TabIndex = 8;
            this.lblHeader.Text = "G-code header";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 63);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(774, 25);
            this.progressBar1.TabIndex = 9;
            // 
            // grpSize
            // 
            this.grpSize.Controls.Add(this.txtSize);
            this.grpSize.Controls.Add(this.lblSize);
            this.grpSize.Location = new System.Drawing.Point(543, 104);
            this.grpSize.Name = "grpSize";
            this.grpSize.Size = new System.Drawing.Size(247, 65);
            this.grpSize.TabIndex = 10;
            this.grpSize.TabStop = false;
            this.grpSize.Text = "Plot size (mm)";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(101, 26);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(82, 20);
            this.txtSize.TabIndex = 10;
            this.txtSize.Text = "200";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(19, 29);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(88, 13);
            this.lblSize.TabIndex = 9;
            this.lblSize.Text = "Width = height = ";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(552, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(238, 40);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Location = new System.Drawing.Point(538, 430);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(72, 13);
            this.lblFooter.TabIndex = 13;
            this.lblFooter.Text = "G-code footer";
            // 
            // txtFooter
            // 
            this.txtFooter.Location = new System.Drawing.Point(541, 446);
            this.txtFooter.Multiline = true;
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFooter.Size = new System.Drawing.Size(249, 170);
            this.txtFooter.TabIndex = 12;
            this.txtFooter.Text = "G21\r\n\r\nM3 S100\r\n\r\n";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 637);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(778, 97);
            this.txtLog.TabIndex = 14;
            this.txtLog.Text = "\r\n\r\n";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 746);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.txtFooter);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grpSize);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtHeader);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.Name = "FrmMain";
            this.Text = "PNG to Hilbert curve converter";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.grpSize.ResumeLayout(false);
            this.grpSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox grpSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.TextBox txtLog;
    }
}

