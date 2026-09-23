using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Components
{
    public partial class StoreHeader : UserControl
    {
        public StoreHeader()
        {
            InitializeComponent();
        }

        //[속성 Setter 설정]
        // - 상위 폼에서 Title과 Description을 설정하면 내부 Label.Text에 반영하도록 해줌.
        // [Description 설정]
        // - 여러줄 입력할 수 있게 '타입 속성 추가'를 해줌.
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value ;}

        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]  
        public string Description { get => lblDescription.Text; set => lblDescription.Text = value;}

    }
}
