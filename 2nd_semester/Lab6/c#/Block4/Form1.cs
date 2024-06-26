using System;
using System.Drawing;
using System.Windows.Forms;

namespace Block4
{
  public partial class Form1 : Form
  {
    private System.Windows.Forms.Timer bombTimer;
    private System.Windows.Forms.Timer cloudTimer;
    private float x, y, velocityX, velocityY;
    private bool isAnimating = false;

    private const float radius = 20;
    private const float gravity = 1;
    private const float initialVelocityX = 2;
    private float planeX;
    private float planeY;
    private float fallingPoint;

    private float cloudX;
    private float cloudY = 80; // Adjust this to change the height of the cloud
    private const float cloudSpeed = 1;
    private Bitmap cloudImage;

    private Bitmap bombImage;
    private Bitmap explosionImage;
    private Bitmap planeImage;
    private Bitmap smokeImage;

    public Form1()
    {
      InitializeComponent();

      this.DoubleBuffered = true;
      this.Paint += new PaintEventHandler(OnPaint);
      this.KeyDown += new KeyEventHandler(OnKeyDown);

      bombTimer = new System.Windows.Forms.Timer();
      bombTimer.Interval = 16; // Approximately 60 FPS
      bombTimer.Tick += new EventHandler(OnBombTimerTick);

      cloudTimer = new System.Windows.Forms.Timer();
      cloudTimer.Interval = 16; // Approximately 60 FPS
      cloudTimer.Tick += new EventHandler(OnCloudTimerTick);
      cloudTimer.Start();

      this.Load += new EventHandler(Form1_Load);

      bombImage = new Bitmap("assets/bomb.png");
      explosionImage = new Bitmap("assets/boom2.png");
      planeImage = new Bitmap("assets/combat_plane.png");
      smokeImage = new Bitmap("assets/smoke.png");
      cloudImage = new Bitmap("assets/cloud.png");
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      planeX = (this.ClientSize.Width) / 2 - 100;
      planeY = (this.ClientSize.Height) / 2 - 150;
      fallingPoint = this.ClientSize.Height * 0.9f;
      cloudX = this.ClientSize.Width;
    }

    private void InitializeBomb()
    {
      x = this.ClientSize.Width / 2;
      y = this.ClientSize.Height / 2 + 40;
      velocityX = initialVelocityX;
      velocityY = 0;
    }

    private void OnBombTimerTick(object sender, EventArgs e)
    {
      UpdateBombAnimation();
      this.Invalidate();
    }

    private void OnCloudTimerTick(object sender, EventArgs e)
    {
      UpdateCloudAnimation();
      this.Invalidate();
    }

    private void UpdateBombAnimation()
    {
      if (y + radius < fallingPoint)
      {
        velocityY += gravity;
        x += velocityX * 3;
        y += velocityY;
      }
      else if (x + radius > 0)
      {
        y = fallingPoint - radius;
        velocityY = 0;
        velocityX = -20;
        x += velocityX;
      }
      else
      {
        isAnimating = false;
        bombTimer.Stop();
      }
    }

    private void UpdateCloudAnimation()
    {
      cloudX -= cloudSpeed;
      if (cloudX + cloudImage.Width < 0)
      {
        cloudX = this.ClientSize.Width;
      }
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;

      g.Clear(Color.White);

      DrawSky(g);
      DrawGround(g);
      DrawSun(g);
      DrawCloud(g);
      DrawPlane(g);

      if (isAnimating)
      {
        if (y + radius < fallingPoint)
        {
          DrawBomb(g);
        }
        else
        {
          DrawExplosion(g);
        }
      }
    }

    private void DrawGround(Graphics g)
    {
      using (SolidBrush brush = new SolidBrush(Color.Green))
      {
        g.FillRectangle(brush, 0, this.ClientSize.Height * 0.75f, this.ClientSize.Width, this.ClientSize.Height * 0.25f);
      }
    }

    private void DrawSky(Graphics g)
    {
      using (SolidBrush brush = new SolidBrush(Color.FromArgb(71, 204, 171)))
      {
        g.FillRectangle(brush, 0, 0, this.ClientSize.Width, this.ClientSize.Height * 0.75f);
      }
    }

    private void DrawSun(Graphics g)
    {
      using (SolidBrush brush = new SolidBrush(Color.FromArgb(245, 237, 17)))
      {
        g.FillEllipse(brush, this.ClientSize.Width - 125, -55, 110, 110);
      }
    }

    private void DrawPlane(Graphics g)
    {
      g.DrawImage(smokeImage, -100, planeY);
      g.DrawImage(planeImage, planeX, planeY);
    }

    private void DrawCloud(Graphics g)
    {
      g.DrawImage(cloudImage, cloudX, cloudY);
    }

    private void DrawBomb(Graphics g)
    {
      g.DrawImage(bombImage, x - radius, y - radius, radius * 2, radius * 2);
    }

    private void DrawExplosion(Graphics g)
    {
      g.DrawImage(explosionImage, x - radius, y - radius, radius * 2, radius * 3);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Z && !isAnimating)
      {
        isAnimating = true;
        InitializeBomb();
        bombTimer.Start();
      }
    }
  }
}
