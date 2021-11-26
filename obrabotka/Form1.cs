using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using obrabotka.Objects;


namespace obrabotka
{
    public partial class Form1 : Form
    {
        MyRectangle myRect;
        List<BaseObject> objects = new List<BaseObject>();
        Player player;
        Marker marker;
        public Form1()
        {
            InitializeComponent();
            player = new Player(pbMain.Width / 2, pbMain.Height/2,0);
            marker  = new Marker(pbMain.Width / 2+50, pbMain.Height / 2+50, 0);
            objects.Add(marker);
            objects.Add(player);

            myRect = new MyRectangle(100, 100, 45);
            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
          foreach(var obj in objects.ToList())
            {
                if(obj != player && player.Overlaps(obj, g))
                {
                    txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
                }
                if(obj == marker)
                {
                    objects.Remove(marker);
                    marker = null;
                }
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                float lenght = MathF.Sqrt(dx * dx + dy * dy);
                dx /= lenght;
                dy /= lenght;

                player.X += dx * 2;
                player.Y += dy * 2;

            }
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker); 
            } 
            marker.X = e.X;
            marker.Y = e.Y;
        }

        private void pbMain_Click(object sender, EventArgs e)
        {

        }
    }
}
