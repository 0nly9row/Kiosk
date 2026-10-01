using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Kiosk.Components
{
    internal class RoundedPanel : Panel
    {
        private int _borderWidth = 3;
        private int _borderRadius = 7;
        private Color _borderColor = Color.Black;
        private Color _backGround = Color.White;

        [DefaultValue(3)]
        [Category("RoundedPanel"), Description("테두리 두께")]
        public int BorderWidth
        {
            get => _borderWidth;
            set { _borderWidth = value; Invalidate(); }
        }

        [DefaultValue(7)]
        [Category("RoundedPanel"), Description("테두리 모서리 둥글기")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        [DefaultValue(typeof(Color), "Black")]
        [Category("RoundedPanel"), Description("테두리 색깔")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [DefaultValue(typeof(Color), "White")]
        [Category("RoundedPanel"), Description("사각형 내부 색깔")]
        public Color BackGround
        {
            get => _backGround;
            set { _backGround = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            Rectangle rect = new Rectangle(_borderWidth, _borderWidth,
                                           Width - _borderWidth * 2, Height - _borderWidth * 2);
            GraphicsPath path = RoundedRectanglePath(rect, _borderRadius);

            SolidBrush innerBrush = new SolidBrush(_backGround);
            graphics.FillPath(innerBrush, path);
            Pen borderPen = new Pen(_borderColor, _borderWidth);
            graphics.DrawPath(borderPen, path);
        }

        private static GraphicsPath RoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;

            Rectangle topLeft = new Rectangle(rect.X, rect.Y, diameter, diameter);
            Rectangle topRight = new Rectangle(rect.Right - diameter, rect.Y, diameter, diameter);
            Rectangle bottomRight = new Rectangle(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter);
            Rectangle bottomLeft = new Rectangle(rect.X, rect.Bottom - diameter, diameter, diameter);

            path.AddArc(topLeft, 180, 90);
            path.AddArc(topRight, 270, 90);
            path.AddArc(bottomRight, 0, 90);
            path.AddArc(bottomLeft, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}

