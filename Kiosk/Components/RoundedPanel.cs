using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DefaultValue(3)]
        [Category("RoundedPanel"), Description("테두리 두께")]
        public int BorderWidth 
        { 
            get => _borderWidth; 
            set {_borderWidth = value; Invalidate();} 
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

        [DefaultValue(2)]
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
