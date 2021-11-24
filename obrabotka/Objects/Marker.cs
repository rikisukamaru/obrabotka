using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace obrabotka.Objects
{
    class Marker : BaseObject
    {
        public Marker(float x,float y,float angle) : base(x,y,angle)
        {

        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Purple), -3, -3, 6, 6);
            g.DrawEllipse(new Pen(Color.Purple, 3), -6, -6, 12, 12);
            g.DrawEllipse(new Pen(Color.Purple, 3), -10, -10, 20, 20);
        }
    }
}
