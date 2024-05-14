namespace Block1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            Rectangle rect = new Rectangle(90, 50, 100, 100);
            g.DrawArc(pen, rect, 0, 180);

            Point[] points = { new Point(450, 200), new Point(550, 250), new Point(500, 350), new Point(400, 300) };
            g.DrawPolygon(pen, points);

            g.FillPie(Brushes.Aqua, 575, 15, 200, 200, 180, 90);
        }
    }
}
