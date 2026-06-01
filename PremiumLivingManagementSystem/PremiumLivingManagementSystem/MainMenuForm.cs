
using System;
using System.Windows.Forms;

namespace PremiumLivingManagementSystem
{
    public class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            this.Text = "Premium Living Management System";
            this.Size = new System.Drawing.Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblWelcome = new Label()
            {
                Text = "Welcome, " + DatabaseHelper.CurrentUserName,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold),
                Left = 300,
                Top = 200,
                AutoSize = true
            };

            MenuStrip menuStrip = new MenuStrip();

            ToolStripMenuItem ordersMenu = new ToolStripMenuItem("Orders");
            ToolStripMenuItem logisticsMenu = new ToolStripMenuItem("Logistics");
            ToolStripMenuItem inventoryMenu = new ToolStripMenuItem("Inventory");
            ToolStripMenuItem afterServiceMenu = new ToolStripMenuItem("After-service");
            ToolStripMenuItem masterDataMenu = new ToolStripMenuItem("Master Data");
            ToolStripMenuItem usmanDataMenu = new ToolStripMenuItem("Usman Data");
            ToolStripMenuItem logoutMenu = new ToolStripMenuItem("Logout");
            ToolStripMenuItem exitMenu = new ToolStripMenuItem("Exit");


            ordersMenu.Click += (s, e) => MessageBox.Show("Order Management - Coming Soon");
            logisticsMenu.Click += (s, e) => MessageBox.Show("Logistics - Coming Soon");
            inventoryMenu.Click += (s, e) => MessageBox.Show("Inventory - Coming Soon");
            afterServiceMenu.Click += (s, e) => MessageBox.Show("After-service - Coming Soon");
            masterDataMenu.Click += (s, e) => MessageBox.Show("Master Data - Coming Soon");
            usmanDataMenu.Click += (s, e) => MessageBox.Show("Usman Data - Coming Soon");

            logoutMenu.Click += (s, e) =>
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            };

            exitMenu.Click += (s, e) => Application.Exit();

            menuStrip.Items.Add(ordersMenu);
            menuStrip.Items.Add(logisticsMenu);
            menuStrip.Items.Add(inventoryMenu);
            menuStrip.Items.Add(afterServiceMenu);
            menuStrip.Items.Add(masterDataMenu);
            menuStrip.Items.Add(usmanDataMenu);
            menuStrip.Items.Add(logoutMenu);
            menuStrip.Items.Add(exitMenu);

            this.Controls.Add(lblWelcome);
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainMenuForm
            // 
            this.ClientSize = new System.Drawing.Size(1256, 614);
            this.Name = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);

        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}