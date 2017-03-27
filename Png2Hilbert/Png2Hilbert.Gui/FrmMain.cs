using System.Drawing;
using System.Windows.Forms;

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
                generator.LoadImage(txtInput.Text);
                generator.GenerateCurve();
            }
        }

        private void OnImageLoaded(object sender, Bitmap bitmap)
        {
            var bitmapCopy = bitmap.Clone(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            System.Drawing.Imaging.PixelFormat.DontCare);

            this.picPreview.Image = bitmapCopy;
        }
    }
}
