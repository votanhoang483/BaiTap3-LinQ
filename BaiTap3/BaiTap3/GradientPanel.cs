using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap3
{
    public class GradientPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                   Color.LightSkyBlue,   
                                                                   Color.DeepSkyBlue,
                                                                   90F))         
            {
                // Vẽ gradient trên toàn bộ panel
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
