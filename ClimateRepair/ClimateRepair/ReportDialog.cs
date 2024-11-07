using System.Drawing;
using System.Windows.Forms;
using QRCoder;

namespace ClimateRepair
{
    public partial class ReportDialog : Form
    {
        public ReportDialog(string rep)
        {
            InitializeComponent();
            GenerateQrCode();
            label1.Text = rep;
        }

        private void GenerateQrCode()
        {
            string url = "https://forms.gle/H6Qx5EkXn6s6qrZd6";
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(10);
                    qrCodePictureBox.Image = qrCodeImage;
                }
            }
        }
    }
}
