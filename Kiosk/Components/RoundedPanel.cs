using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Components
{
    internal class RoundedPanel: Panel
    {
        private int _borderWidth = 3;
        private int _borderRadius = 7;
        private Color _borderColor = Color.Black;
        private Color _backGround = Color.White;

        public int BorderWidth 
        { 
            get => _borderWidth; 
            set {_borderWidth = value; Invalidate();} 
        }
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }
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
            GraphicsPath path = new GraphicsPath();

        }

        }
    }
