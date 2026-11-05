namespace Kiosk
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Models.MenuItemData menuItemData4 = new Models.MenuItemData();
            Models.MenuItemData menuItemData5 = new Models.MenuItemData();
            Models.MenuItemData menuItemData6 = new Models.MenuItemData();
            storeHeader1 = new Kiosk.Components.StoreHeader();
            menuBoard1 = new Kiosk.Components.Products.MenuBoard();
            shoppingCartControl1 = new Kiosk.Components.Cart.ShoppingCartControl();
            orderTotalControl1 = new Kiosk.Components.OrderTotal.OrderTotalControl();
            buttonPay1 = new Kiosk.Buttons.ButtonPay();
            buttonClear1 = new Kiosk.Buttons.ButtonClear();
            SuspendLayout();
            // 
            // storeHeader1
            // 
            storeHeader1.Description = "스티커 제국에 오신걸 환영함니다.\r\n귀엽우니 많이 사주시길 바람니다.\r\n";
            storeHeader1.Dock = DockStyle.Top;
            storeHeader1.Location = new Point(0, 0);
            storeHeader1.Name = "storeHeader1";
            storeHeader1.Size = new Size(1113, 136);
            storeHeader1.TabIndex = 0;
            storeHeader1.Title = "먼지덩이";
            // 
            // menuBoard1
            // 
            menuBoard1.BackColor = Color.Transparent;
            menuItemData4.ID = 0;
            menuItemData4.Image = Properties.Resources.똥파리_슈렉;
            menuItemData4.Price = new decimal(new int[] { 1000, 0, 0, 0 });
            menuItemData4.Title = "똥파리 슈렉";
            menuItemData5.ID = 1;
            menuItemData5.Image = Properties.Resources.슈퍼맨_슈렉;
            menuItemData5.Price = new decimal(new int[] { 1000, 0, 0, 0 });
            menuItemData5.Title = "슈퍼맨 슈렉";
            menuItemData6.ID = 2;
            menuItemData6.Image = Properties.Resources.코끼리_슈렉;
            menuItemData6.Price = new decimal(new int[] { 1000, 0, 0, 0 });
            menuItemData6.Title = "코끼리 슈렉";
            menuBoard1.Items.Add(menuItemData4);
            menuBoard1.Items.Add(menuItemData5);
            menuBoard1.Items.Add(menuItemData6);
            menuBoard1.Location = new Point(12, 142);
            menuBoard1.Name = "menuBoard1";
            menuBoard1.Size = new Size(1089, 346);
            menuBoard1.TabIndex = 1;
            menuBoard1.ItemClicked += menuBoard1_ItemClicked;
            // 
            // shoppingCartControl1
            // 
            shoppingCartControl1.Location = new Point(12, 494);
            shoppingCartControl1.Name = "shoppingCartControl1";
            shoppingCartControl1.Size = new Size(758, 286);
            shoppingCartControl1.TabIndex = 2;
            shoppingCartControl1.CartChanged += shoppingCartControl1_CartChanged;
            // 
            // orderTotalControl1
            // 
            orderTotalControl1.Location = new Point(776, 494);
            orderTotalControl1.Name = "orderTotalControl1";
            orderTotalControl1.Size = new Size(325, 124);
            orderTotalControl1.TabIndex = 3;
            orderTotalControl1.TotalCountView = 0;
            orderTotalControl1.TotalPriceView = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // buttonPay1
            // 
            buttonPay1.Location = new Point(776, 624);
            buttonPay1.Name = "buttonPay1";
            buttonPay1.Size = new Size(153, 122);
            buttonPay1.TabIndex = 4;
            buttonPay1.ButtonClick += buttonPay1_ButtonClick;
            // 
            // buttonClear1
            // 
            buttonClear1.Location = new Point(948, 624);
            buttonClear1.Name = "buttonClear1";
            buttonClear1.Size = new Size(153, 122);
            buttonClear1.TabIndex = 5;
            buttonClear1.ButtonClick += buttonClear1_ButtonClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 792);
            Controls.Add(buttonClear1);
            Controls.Add(buttonPay1);
            Controls.Add(orderTotalControl1);
            Controls.Add(shoppingCartControl1);
            Controls.Add(menuBoard1);
            Controls.Add(storeHeader1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Components.StoreHeader storeHeader1;
        private Components.Products.MenuBoard menuBoard1;
        private Components.Cart.ShoppingCartControl shoppingCartControl1;
        private Components.OrderTotal.OrderTotalControl orderTotalControl1;
        private Buttons.ButtonPay buttonPay1;
        private Buttons.ButtonClear buttonClear1;
    }
}
