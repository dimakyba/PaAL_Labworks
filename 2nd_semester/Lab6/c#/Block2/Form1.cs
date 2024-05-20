namespace Block2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Graphics g = e.Graphics;
            // Pen pen = new Pen(Color.Black, 2);

            // Rectangle rect = new Rectangle(90, 50, 100, 100);
            // g.DrawArc(pen, rect, 0, 180);

            // Point[] points = { new Point(450, 200), new Point(550, 250), new Point(500, 350), new Point(400, 300) };
            // g.DrawPolygon(pen, points);

            // g.FillPie(Brushes.Aqua, 575, 15, 200, 200, 180, 90);
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            Rectangle bodyRect = new Rectangle(150, 200, 300, 150);
            g.DrawEllipse(pen, bodyRect);
            g.FillEllipse(Brushes.LightBlue, bodyRect);

            Point[] tailPoints = {
            new Point(450, 275),
            new Point(550, 200),
            new Point(550, 350)
        };
            g.DrawPolygon(pen, tailPoints);
            g.FillPolygon(Brushes.LightBlue, tailPoints);

            Rectangle eyeRect = new Rectangle(180, 240, 30, 30);
            g.DrawEllipse(pen, eyeRect);
            g.FillEllipse(Brushes.White, eyeRect);

            Rectangle pupilRect = new Rectangle(190, 250, 10, 10);
            g.DrawEllipse(pen, pupilRect);
            g.FillEllipse(Brushes.Black, pupilRect);

            Point[] topFinPoints = {
            new Point(250, 200),
            new Point(300, 100),
            new Point(350, 200)
        };
            g.DrawPolygon(pen, topFinPoints);
            g.FillPolygon(Brushes.LightBlue, topFinPoints);

            Point[] bottomFinPoints = {
            new Point(250, 350),
            new Point(300, 450),
            new Point(350, 350)
        };
            g.DrawPolygon(pen, bottomFinPoints);
            g.FillPolygon(Brushes.LightBlue, bottomFinPoints);
        }
    }
}
