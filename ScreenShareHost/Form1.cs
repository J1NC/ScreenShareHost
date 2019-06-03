using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShareHost
{
    public partial class ScreenShare : Form
    {
        private const int GCCollectCycle = 20;
        private int Cycle = 0;
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
            }
            else
            {
                pbScreen.Image = null;
                timer1.Enabled = false;
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
            }
            Debug.WriteLine(Cycle);
            Cycle++;
            if (Cycle % GCCollectCycle == 0)
                GC.Collect();
        }
    }
}
