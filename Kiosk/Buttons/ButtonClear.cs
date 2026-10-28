using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Buttons
{
    public partial class ButtonClear : UserControl
    {
        public ButtonClear()
        {
            InitializeComponent();
            AddButtonClick(this);
        }
        public event EventHandler? ButtonClick;


        private void AddButtonClick(Control parentcontrol) 
        {
            parentcontrol.Click += (_, __) => ButtonClick?.Invoke(this, EventArgs.Empty);

            foreach(Control control in parentcontrol.Controls) 
            { 
                AddButtonClick(control);
            }

        }
        
    }
}
