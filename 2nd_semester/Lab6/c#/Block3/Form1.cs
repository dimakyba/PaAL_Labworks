using System.Drawing.Drawing2D;

namespace Block2
{
    public partial class Form1 : Form
    {
        private double angle = 0f;
        private const int dotRadius = 10;
        private const int orbitRadius1 = 100;
        private const int orbitRadius2 = 150;

        private double x1, y1, x2, y2;
        private int centerX, centerY;

        public Form1()
        {
            InitializeComponent();
            centerX = this.ClientSize.Width / 2;
            centerY = this.ClientSize.Height / 2;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle += 0.05;

            x1 = centerX + orbitRadius1 * Math.Cos(angle);
            y1 = centerY + orbitRadius1 * Math.Sin(angle);

            x2 = centerX + orbitRadius2 * Math.Cos(-angle);
            y2 = centerY + orbitRadius2 * Math.Sin(-angle);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            DrawFilledCircle(g, centerX, centerY, dotRadius, Color.Black);

            DrawFilledCircle(g, (int)x1, (int)y1, dotRadius, Color.Blue);
            DrawFilledCircle(g, (int)x2, (int)y2, dotRadius, Color.Yellow);
        }

        private void DrawFilledCircle(Graphics g, int x, int y, int radius, Color color)
        {
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, x - radius, y - radius, radius * 2, radius * 2);
            }
        }
    }
}
