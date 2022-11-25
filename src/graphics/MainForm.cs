namespace Raytracing
{
    public partial class MainForm : Form
    {

        System.Windows.Forms.Timer graphicsTimer;
        Point res;

        Camera cam;
        Mesh cube;

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

            cam = new Camera(res, new Vector3(-4, 0, 0), Math.PI/2);

            cube = new Mesh(new Triangle[] {
                //neg X side
                new Triangle(new Vector3(-1, -1, -1), new Vector3(-1, -1, 1), new Vector3(-1, 1, -1)),
                new Triangle(new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, 1)),
                //pos Y side
                new Triangle(new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, -1)),
                new Triangle(new Vector3(1, 1, 1), new Vector3(1, 1, -1), new Vector3(-1, 1, 1)),
                //pos Z side
                new Triangle(new Vector3(-1, -1, 1), new Vector3(1, -1, 1), new Vector3(-1, 1, 1)),
                new Triangle(new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(1, -1 ,1)),
                //pos X side
                new Triangle(new Vector3(1, -1, -1), new Vector3(1, -1, 1), new Vector3(1, 1, -1)),
                new Triangle(new Vector3(1, 1, 1), new Vector3(1, 1, -1), new Vector3(1, -1, 1)),
                //neg Z side
                new Triangle(new Vector3(1, -1, -1), new Vector3(-1, -1, -1), new Vector3(1, 1, -1)),
                new Triangle(new Vector3(-1, 1, -1), new Vector3(1, 1, -1), new Vector3(-1, -1, -1)),
                //neg Y side
                new Triangle(new Vector3(-1, -1, -1), new Vector3(-1, -1, 1), new Vector3(1, -1, -1)),
                new Triangle(new Vector3(1, -1, 1), new Vector3(1, -1, -1), new Vector3(-1, -1, 1)),
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            graphicsTimer.Start();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //Paint
            Graphics g = e.Graphics;
            Brush br = new SolidBrush(Color.White);
            for (int x = 0; x < res.X; x++)
            {
                for (int y = 0; y < res.Y; y++)
                {
                    Triangle triangle = cube.GetNearesIntersection(cam.pos, Vector3.Add(cam.pos, cam.GetPointingTo(x, y)));
                    if (triangle != null)
                        g.FillRectangle(br, x, y, 1, 1);
                }
            }

            cube.RotateX(.1);
            cube.RotateZ(.2);
        }

        private void GraphicsTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}