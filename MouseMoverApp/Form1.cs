using System;
using System.Runtime.InteropServices;
//using System.Threading;
using System.Windows.Forms;
using System.Drawing;


namespace MouseMoverApp
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENT_MOVE = 0x0001;
        private Timer mouseMoveTimer;

        public Form1()
        {
            InitializeComponent();

            mouseMoveTimer = new Timer();
            mouseMoveTimer.Interval = 5000;
            mouseMoveTimer.Tick += MouseMoveTiemr_Tick;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            mouseMoveTimer.Start();
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            mouseMoveTimer.Stop();
        }

        private void MouseMoveTiemr_Tick(object sender, EventArgs e)
        {
            mouse_event(MOUSEEVENT_MOVE, 100, 0, 0, 0);
            mouse_event(MOUSEEVENT_MOVE, -100, 0, 0, 0);
        }
    }
}
