using Kiosk.Components.Products;
using Kiosk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Components.Products
{
    public partial class MenuItemControl : UserControl
    {
        public MenuItemControl()
        {
            InitializeComponent();
        }

        public event EventHandler MenuClicked;

        public int ID { get; set; }
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; } 
        public decimal Price { get => decimal.Parse(lblPrice.Text); set => lblPrice.Text = value.ToString(); }
        public Image? Image { get => picBox.Image; set => picBox.Image = value; }

        private void AddClickEvent(Control parentControl) 
        {
            foreach (Control control in parentControl.Controls) 
            { 
                control.Click += Control_Click;
                if (control.HasChildren)
                {
                    AddClickEvent(control);
                }
            }
        }

        private void Control_Click(object? sender,EventArgs e)
        {
            MenuClicked?.Invoke(this,EventArgs.Empty);
        }
    }
}


