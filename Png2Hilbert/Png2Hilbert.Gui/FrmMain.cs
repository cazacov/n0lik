using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Png2Hilbert
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            using (var generator = new HilbertGenerator())
            {
                generator.OnLoad += OnImageLoaded;
                generator.OnPathGenerated += OnPathGenerated;
                generator.LoadImage(txtInput.Text);
                generator.GenerateCurve();
                var maxSize = Int32.Parse(txtSize.Text);

                generator.ExportGCode(txtOutput.Text, txtHeader.Text, txtFooter.Text, maxSize);
            }
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

        private void txtHeader_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
