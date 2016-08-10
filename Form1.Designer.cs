namespace timer
{
    partial class AutoTime
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoTime));
            this.Log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuBar = new System.Windows.Forms.MenuItem();
            this.clearItem = new System.Windows.Forms.MenuItem();
            this.exitItem = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // Log
            // 
            resources.ApplyResources(this.Log, "Log");
            this.Log.Name = "Log";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuBar});
            // 
            // menuBar
            // 
            this.menuBar.Index = 0;
            this.menuBar.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.clearItem,
            this.exitItem});
            resources.ApplyResources(this.menuBar, "menuBar");
            this.menuBar.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // clearItem
            // 
            this.clearItem.Index = 0;
            resources.ApplyResources(this.clearItem, "clearItem");
            this.clearItem.Click += new System.EventHandler(this.clearItem_Click);
            // 
            // exitItem
            // 
            this.exitItem.Index = 1;
            resources.ApplyResources(this.exitItem, "exitItem");
            this.exitItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // AutoTime
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Log);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Menu = this.mainMenu1;
            this.Name = "AutoTime";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuBar;
        private System.Windows.Forms.MenuItem clearItem;
        private System.Windows.Forms.MenuItem exitItem;
    }
}

