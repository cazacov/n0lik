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
                if (!DoLoad())
                {
                    return;
                }
            }
            
            var exporter = new GCodeExporter(
                Int32.Parse(txtWidth.Text), 
                Int32.Parse(txtHeight.Text),
                txtHeader.Text,
                txtFooter.Text,
                txtPenUp.Text,
                txtPenDown.Text);

            var pathLengthMm = exporter.ExportGCode(generator.Path, txtOutput.Text);

            lblPathLength.Text = $@"{pathLengthMm:n}";
        }

        private void OnPathGenerated(object sender, Bitmap bitmap)
        {
            var bitmapCopy = bitmap.Clone(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            System.Drawing.Imaging.PixelFormat.DontCare);
            this.picPreview.Image = bitmapCopy;
            this.picPreview.Invalidate();
            this.picPreview.Refresh();
            this.lblCalculationTime.Text = $@"{generator.LastCalculationTimeInMs} ms";

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

        private bool DoLoad()
        {
            SaveSettings();
            try
            {
                generator.LoadImage(txtInput.Text);
                generator.PrepareCurve(tbOrder.Value);
                generator.GenerateCurve(this.tbGamma.Value/10.0, tbOrder.Value);
                this.isLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return false;
            }
            return true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            this.txtInput.Text = Properties.Settings.Default.InputFileName;
            this.txtOutput.Text = Properties.Settings.Default.OutputFileName;
            this.tbGamma.Value = Properties.Settings.Default.Gamma;
            this.tbOrder.Value = Properties.Settings.Default.MaxOrder;
            this.txtWidth.Text = Properties.Settings.Default.PlotWidth.ToString();
            this.txtHeight.Text = Properties.Settings.Default.PlotHeight.ToString();
            this.txtHeader.Text = Properties.Settings.Default.Header;
            this.txtFooter.Text = Properties.Settings.Default.Footer;
            this.txtPenUp.Text = Properties.Settings.Default.PenUp;
            this.txtPenDown.Text = Properties.Settings.Default.PenDown;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.InputFileName = this.txtInput.Text;
            Properties.Settings.Default.OutputFileName = this.txtOutput.Text;
            Properties.Settings.Default.Gamma = this.tbGamma.Value;
            Properties.Settings.Default.MaxOrder = this.tbOrder.Value;
            Properties.Settings.Default.PlotWidth = this.txtWidth.Text.ToIntDef(250);
            Properties.Settings.Default.PlotHeight = this.txtHeight.Text.ToIntDef(180);
            Properties.Settings.Default.Header = this.txtHeader.Text;
            Properties.Settings.Default.Footer = this.txtFooter.Text;
            Properties.Settings.Default.PenUp = this.txtPenUp.Text;
            Properties.Settings.Default.PenDown = this.txtPenDown.Text;
            Properties.Settings.Default.Save();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (fileInput.ShowDialog(this) == DialogResult.OK)
            {
                this.txtInput.Text = fileInput.FileName;
                SaveSettings();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void tbGamma_ValueChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                generator.GenerateCurve(tbGamma.Value / 10.0, tbOrder.Value);
                SaveSettings();
            }
        }

        private void tbOrder_ValueChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                generator.PrepareCurve(tbOrder.Value);
                generator.GenerateCurve(this.tbGamma.Value/10.0, tbOrder.Value);
                SaveSettings();
            }
        }
    }
}
