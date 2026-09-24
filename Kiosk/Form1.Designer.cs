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
            storeHeader1 = new Kiosk.Components.StoreHeader();
            SuspendLayout();
            // 
            // storeHeader1
            // 
            storeHeader1.Description = "어서 오세요~\r\n모든 메뉴가 맛있습니당\r\n";
            storeHeader1.Dock = DockStyle.Top;
            storeHeader1.Location = new Point(0, 0);
            storeHeader1.Name = "storeHeader1";
            storeHeader1.Size = new Size(800, 136);
            storeHeader1.TabIndex = 0;
            storeHeader1.Title = " 상점";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(storeHeader1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Components.StoreHeader storeHeader1;
    }
}
