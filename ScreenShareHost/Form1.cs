using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShareHost
{
    public partial class ScreenShare : Form
    {
        private Bitmap prevBitmap = null;
        private const int GCCollectCycle = 20;
        private const string HOSTNAME = "192.168.1.9";
        private const int PORT = 3000;
        private const int TCP_PORT = 3001;
        private int Cycle = 0;
        private string id;
        private TcpClient client;

        public ScreenShare()
        {
            InitializeComponent();
        }

        public Bitmap getScreenImage()
        {
            Size size = new Size(pbScreen.Width, pbScreen.Height);
            Bitmap screenWithCursor = ScreenCapture.CapturePrimaryScreen(true);
            if (screenWithCursor != null)
                return new Bitmap(screenWithCursor, size);
            else
                return null;
        }

        private void btnStreaming_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                getId();
                client = new TcpClient(HOSTNAME, TCP_PORT);
            }
            else
            {
                pbScreen.Image = null;
                timer1.Enabled = false;
                client.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap BM = getScreenImage();
            if (pbScreen.Image != null)
            {
                pbScreen.Image.Dispose();
            }
            if (BM != null)
            {
                pbScreen.Image = BM;
                sendBitmap(BM);
            }

            Cycle++;
            if (Cycle % GCCollectCycle == 0)
                GC.Collect();
        }

        private void sendBitmap(Bitmap bitmap)
        {
            if (prevBitmap != null)
            {
                if (!CompareBitmaps(prevBitmap, bitmap))
                {
                    // 서버로 전송
                    Byte[] data = Encoding.Default.GetBytes(Convert.ToBase64String(ImageToByte(prevBitmap)) + "&end");
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                }
            }
            prevBitmap = (Bitmap)bitmap.Clone();
        }


        public static bool CompareBitmaps(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            int bytes = bmp1.Width * bmp1.Height * (Image.GetPixelFormatSize(bmp1.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bitmapData1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), ImageLockMode.ReadOnly, bmp2.PixelFormat);

            Marshal.Copy(bitmapData1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bitmapData2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            bmp1.UnlockBits(bitmapData1);
            bmp2.UnlockBits(bitmapData2);

            return result;
        }

        private void getId()
        {
            string uri = "http://" + HOSTNAME + ":" + PORT + "/host/getId";
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(uri);
            string responseJSON = new StreamReader(stream).ReadToEnd();
            this.id = responseJSON;

            lbHostId.Text = id + "\n이 코드를\n웹에서 입력하십시오.";
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
