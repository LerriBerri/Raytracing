namespace Raytracing
{
    public partial class MainForm : Form
    {

        System.Windows.Forms.Timer graphicsTimer;
        Point res;

        public MainForm()
        {   
            res = new Point(400, 400);

            InitializeComponent();

            DoubleBuffered = true;

            Load += MainForm_Load;
            Paint += MainForm_Paint;

            graphicsTimer = new System.Windows.Forms.Timer();
            graphicsTimer.Interval = 1;
            graphicsTimer.Tick += GraphicsTimer_Tick;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            graphicsTimer.Start();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e) {
            //Paint
            Graphics g = e.Graphics;
        }

        private void GraphicsTimer_Tick(object sender, EventArgs e) {
            Invalidate();
        }
    }
}