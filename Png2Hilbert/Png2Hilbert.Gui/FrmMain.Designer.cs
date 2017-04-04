namespace Png2Hilbert.Gui
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
            this.fileInput = new System.Windows.Forms.OpenFileDialog();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpSize = new System.Windows.Forms.GroupBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblSizeHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblSizeWidth = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.lblPenUp = new System.Windows.Forms.Label();
            this.txtPenUp = new System.Windows.Forms.TextBox();
            this.lblPenDown = new System.Windows.Forms.Label();
            this.txtPenDown = new System.Windows.Forms.TextBox();
            this.tbGamma = new System.Windows.Forms.TrackBar();
            this.lblGamma = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.grpSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGamma)).BeginInit();
            this.SuspendLayout();
            // 
            // fileInput
            // 
            this.fileInput.Filter = "PNG files (*.png)|*.png|JPG files (*.jpg)|*.jpg";
            this.fileInput.Title = "Input image";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(118, 10);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(327, 20);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = "C:\\Temporary\\kate_bw.png";
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
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
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
            this.txtHeader.Size = new System.Drawing.Size(249, 112);
            this.txtHeader.TabIndex = 7;
            this.txtHeader.Text = "G21\r\n\r\nM3 S100\r\n\r\nG0 X100 Y100 F4000\r\n";
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
            // grpSize
            // 
            this.grpSize.Controls.Add(this.txtHeight);
            this.grpSize.Controls.Add(this.lblSizeHeight);
            this.grpSize.Controls.Add(this.txtWidth);
            this.grpSize.Controls.Add(this.lblSizeWidth);
            this.grpSize.Location = new System.Drawing.Point(541, 104);
            this.grpSize.Name = "grpSize";
            this.grpSize.Size = new System.Drawing.Size(247, 76);
            this.grpSize.TabIndex = 10;
            this.grpSize.TabStop = false;
            this.grpSize.Text = "Plot size (mm)";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(103, 45);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(82, 20);
            this.txtHeight.TabIndex = 12;
            this.txtHeight.Text = "200";
            // 
            // lblSizeHeight
            // 
            this.lblSizeHeight.AutoSize = true;
            this.lblSizeHeight.Location = new System.Drawing.Point(21, 48);
            this.lblSizeHeight.Name = "lblSizeHeight";
            this.lblSizeHeight.Size = new System.Drawing.Size(38, 13);
            this.lblSizeHeight.TabIndex = 11;
            this.lblSizeHeight.Text = "Height";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(103, 19);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(82, 20);
            this.txtWidth.TabIndex = 10;
            this.txtWidth.Text = "280";
            // 
            // lblSizeWidth
            // 
            this.lblSizeWidth.AutoSize = true;
            this.lblSizeWidth.Location = new System.Drawing.Point(21, 22);
            this.lblSizeWidth.Name = "lblSizeWidth";
            this.lblSizeWidth.Size = new System.Drawing.Size(35, 13);
            this.lblSizeWidth.TabIndex = 9;
            this.lblSizeWidth.Text = "Width";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(632, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(158, 48);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Export to G-code!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Location = new System.Drawing.Point(538, 333);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(72, 13);
            this.lblFooter.TabIndex = 13;
            this.lblFooter.Text = "G-code footer";
            // 
            // txtFooter
            // 
            this.txtFooter.Location = new System.Drawing.Point(541, 349);
            this.txtFooter.Multiline = true;
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFooter.Size = new System.Drawing.Size(249, 170);
            this.txtFooter.TabIndex = 12;
            this.txtFooter.Text = "G21\r\n\r\nM3 S100\r\n\r\n";
            // 
            // lblPenUp
            // 
            this.lblPenUp.AutoSize = true;
            this.lblPenUp.Location = new System.Drawing.Point(538, 531);
            this.lblPenUp.Name = "lblPenUp";
            this.lblPenUp.Size = new System.Drawing.Size(78, 13);
            this.lblPenUp.TabIndex = 16;
            this.lblPenUp.Text = "G-code pen up";
            // 
            // txtPenUp
            // 
            this.txtPenUp.Location = new System.Drawing.Point(541, 547);
            this.txtPenUp.Name = "txtPenUp";
            this.txtPenUp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPenUp.Size = new System.Drawing.Size(249, 20);
            this.txtPenUp.TabIndex = 15;
            this.txtPenUp.Text = "M3 S120";
            // 
            // lblPenDown
            // 
            this.lblPenDown.AutoSize = true;
            this.lblPenDown.Location = new System.Drawing.Point(538, 580);
            this.lblPenDown.Name = "lblPenDown";
            this.lblPenDown.Size = new System.Drawing.Size(92, 13);
            this.lblPenDown.TabIndex = 18;
            this.lblPenDown.Text = "G-code pen down";
            // 
            // txtPenDown
            // 
            this.txtPenDown.Location = new System.Drawing.Point(541, 596);
            this.txtPenDown.Name = "txtPenDown";
            this.txtPenDown.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPenDown.Size = new System.Drawing.Size(249, 20);
            this.txtPenDown.TabIndex = 17;
            this.txtPenDown.Text = "M3 S0";
            // 
            // tbGamma
            // 
            this.tbGamma.AutoSize = false;
            this.tbGamma.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.tbGamma.Location = new System.Drawing.Point(118, 63);
            this.tbGamma.Maximum = 25;
            this.tbGamma.Minimum = 5;
            this.tbGamma.Name = "tbGamma";
            this.tbGamma.Size = new System.Drawing.Size(406, 35);
            this.tbGamma.TabIndex = 19;
            this.tbGamma.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbGamma.UseWaitCursor = true;
            this.tbGamma.Value = 10;
            // 
            // lblGamma
            // 
            this.lblGamma.AutoSize = true;
            this.lblGamma.Location = new System.Drawing.Point(13, 73);
            this.lblGamma.Name = "lblGamma";
            this.lblGamma.Size = new System.Drawing.Size(43, 13);
            this.lblGamma.TabIndex = 20;
            this.lblGamma.Text = "Gamma";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(540, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 48);
            this.btnLoad.TabIndex = 21;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 630);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblGamma);
            this.Controls.Add(this.tbGamma);
            this.Controls.Add(this.lblPenDown);
            this.Controls.Add(this.txtPenDown);
            this.Controls.Add(this.lblPenUp);
            this.Controls.Add(this.txtPenUp);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.txtFooter);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grpSize);
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
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.grpSize.ResumeLayout(false);
            this.grpSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGamma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grpSize;
        private System.Windows.Forms.Label lblSizeWidth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblSizeHeight;
        private System.Windows.Forms.Label lblPenUp;
        private System.Windows.Forms.TextBox txtPenUp;
        private System.Windows.Forms.Label lblPenDown;
        private System.Windows.Forms.TextBox txtPenDown;
        private System.Windows.Forms.TrackBar tbGamma;
        private System.Windows.Forms.Label lblGamma;
        private System.Windows.Forms.Button btnLoad;
    }
}

