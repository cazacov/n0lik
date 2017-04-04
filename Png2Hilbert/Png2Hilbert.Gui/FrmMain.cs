using System;
using System.Drawing;
using System.Windows.Forms;

namespace Png2Hilbert.Gui
{
    public partial class FrmMain : Form
    {
        private bool isLoaded;
        private readonly HilbertGenerator generator;

        public FrmMain()
        {
            InitializeComponent();
            this.isLoaded = false;

            this.generator = new HilbertGenerator();
            generator.OnLoad += OnImageLoaded;
            generator.OnPathGenerated += OnPathGenerated;
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            SaveSettings();
            if (!isLoaded)
            {
                DoLoad();
            }
            generator.GenerateCurve(tbGamma.Value / 10.0);
            
            var exporter = new GCodeExporter(
                Int32.Parse(txtWidth.Text), 
                Int32.Parse(txtHeight.Text),
                txtHeader.Text,
                txtFooter.Text,
                txtPenUp.Text,
                txtPenDown.Text);

            exporter.ExportGCode(generator.Path, txtOutput.Text);
        }

        private void OnPathGenerated(object sender, Bitmap bitmap)
        {
            var bitmapCopy = bitmap.Clone(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            System.Drawing.Imaging.PixelFormat.DontCare);
            this.picPreview.Image = bitmapCopy;
            this.picPreview.Invalidate();
            this.picPreview.Refresh();
            Application.DoEvents();
        }

        private void OnImageLoaded(object sender, Bitmap bitmap)
        {
            var bitmapCopy = bitmap.Clone(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            System.Drawing.Imaging.PixelFormat.DontCare);
            this.picPreview.Image = bitmapCopy;
            this.picPreview.Invalidate();
            this.picPreview.Refresh();
            Application.DoEvents();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.DoLoad();
            this.isLoaded = true;
        }

        private void DoLoad()
        {
            SaveSettings();
            generator.LoadImage(txtInput.Text);
            this.isLoaded = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.txtInput.Text = Properties.Settings.Default.InputFileName;
            this.txtOutput.Text = Properties.Settings.Default.OutputFileName;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.InputFileName = this.txtInput.Text;
            Properties.Settings.Default.InputFileName = this.txtOutput.Text;

            Properties.Settings.Default.Save();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (fileInput.ShowDialog(this) == DialogResult.OK)
            {
                this.txtInput.Text = fileInput.FileName;
                Properties.Settings.Default.InputFileName = this.txtInput.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
