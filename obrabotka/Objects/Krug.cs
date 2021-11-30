using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace obrabotka.Objects
{
    class Krug : BaseObject
    {
        public Action<Krug> onKrugOverlap;
        
        public Krug(float x, float y, float angle) : base(x, y, angle)
        {

        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Aquamarine), -20, -20, 40, 40);
             
           
        }

        public override GraphicsPath GetGraphicsPath()
        {

            var path = base.GetGraphicsPath();
            path.AddEllipse(-10, -10, 20, 20);
            return path;

        }
        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);
            if (obj is Krug)
            {
                onKrugOverlap(obj as Krug);
            }
        }
    }
}
