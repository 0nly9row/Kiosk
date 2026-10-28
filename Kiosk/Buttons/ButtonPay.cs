using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Kiosk.Buttons
{
    public partial class ButtonPay : UserControl
    {
        public ButtonPay()
        {
            InitializeComponent();
            AddButtonClick(this);
        }

        public event EventHandler? ButtonClick;

        private void AddButtonClick(Control parentControl)
        {
            parentControl.Click += (_, __) => ButtonClick?.Invoke(this, EventArgs.Empty);

            foreach (Control control in parentControl.Controls)
            {
                AddButtonClick(control);
            }
        }
    }
}
