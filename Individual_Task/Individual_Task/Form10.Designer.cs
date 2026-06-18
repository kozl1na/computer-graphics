using System;
using System.Windows.Forms;
using System.Drawing;

namespace Individual_Task
{
    partial class Form10
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button topViewButton;
        private System.Windows.Forms.Button frontViewButton;
        private System.Windows.Forms.Button sideViewButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.GroupBox transformGroup;
        private System.Windows.Forms.GroupBox instructionsGroup;
        private System.Windows.Forms.GroupBox viewsGroup;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();

                if (backBuffer != null)
                {
                    backBuffer.Dispose();
                    backBuffer = null;
                }

                if (backGraphics != null)
                {
                    backGraphics.Dispose();
                    backGraphics = null;
                }

                zValues = null;
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.drawingPanel = new Panel();
            this.controlPanel = new Panel();
            this.resetButton = new Button();
            this.transformGroup = new GroupBox();
            this.infoLabel = new Label();
            this.instructionsGroup = new GroupBox();
            this.instructionsLabel = new Label();
            this.viewsGroup = new GroupBox();
            this.topViewButton = new Button();
            this.frontViewButton = new Button();
            this.sideViewButton = new Button();

            this.controlPanel.SuspendLayout();
            this.transformGroup.SuspendLayout();
            this.instructionsGroup.SuspendLayout();
            this.viewsGroup.SuspendLayout();
            this.SuspendLayout();

            // drawingPanel
            this.drawingPanel.BackColor = Color.White;
            this.drawingPanel.Dock = DockStyle.Fill;
            this.drawingPanel.Location = new Point(0, 0);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new Size(700, 700);
            this.drawingPanel.Paint += DrawingPanel_Paint;
            this.drawingPanel.MouseDown += DrawingPanel_MouseDown;
            this.drawingPanel.MouseMove += DrawingPanel_MouseMove;
            this.drawingPanel.MouseUp += DrawingPanel_MouseUp;
            this.drawingPanel.MouseWheel += DrawingPanel_MouseWheel;
            this.drawingPanel.Resize += DrawingPanel_Resize;

            // controlPanel
            this.controlPanel.BackColor = Color.LightGray;
            this.controlPanel.Dock = DockStyle.Right;
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new Size(200, 700);

            // resetButton
            this.resetButton.Text = "Сброс";
            this.resetButton.Size = new Size(180, 34);
            this.resetButton.Location = new Point(10, 40);
            this.resetButton.Click += ResetButton_Click;

            // transformGroup
            this.transformGroup.Text = "Параметры";
            this.transformGroup.Size = new Size(180, 120);
            this.transformGroup.Location = new Point(10, 90);

            // infoLabel
            this.infoLabel.Text = "Вращение X: 30°\nВращение Y: 30°\nМасштаб: 1.0x\nПозиция: (0, 0)";
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new Point(10, 20);

            this.transformGroup.Controls.Add(this.infoLabel);

            // instructionsGroup
            this.instructionsGroup.Text = "Инструкция";
            this.instructionsGroup.Size = new Size(180, 140);
            this.instructionsGroup.Location = new Point(10, 220);

            this.instructionsLabel.Text =
                "• ЛКМ — вращение\n" +
                "• ПКМ — перемещение\n" +
                "• Колесо — масштаб\n" +
                "• Сброс — вернуть вид";

            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new Point(10, 20);

            this.instructionsGroup.Controls.Add(this.instructionsLabel);

            // viewsGroup
            this.viewsGroup.Text = "Виды";
            this.viewsGroup.Size = new Size(180, 120);
            this.viewsGroup.Location = new Point(10, 380);

            // topViewButton
            this.topViewButton.Text = "Вид сверху";
            this.topViewButton.Size = new Size(160, 25);
            this.topViewButton.Location = new Point(10, 20);
            this.topViewButton.Click += TopViewButton_Click;

            // frontViewButton
            this.frontViewButton.Text = "Вид спереди";
            this.frontViewButton.Size = new Size(160, 25);
            this.frontViewButton.Location = new Point(10, 50);
            this.frontViewButton.Click += FrontViewButton_Click;

            // sideViewButton
            this.sideViewButton.Text = "Вид сбоку";
            this.sideViewButton.Size = new Size(160, 25);
            this.sideViewButton.Location = new Point(10, 80);
            this.sideViewButton.Click += SideViewButton_Click;

            this.viewsGroup.Controls.Add(this.topViewButton);
            this.viewsGroup.Controls.Add(this.frontViewButton);
            this.viewsGroup.Controls.Add(this.sideViewButton);

            // controlPanel add
            this.controlPanel.Controls.Add(this.resetButton);
            this.controlPanel.Controls.Add(this.transformGroup);
            this.controlPanel.Controls.Add(this.instructionsGroup);
            this.controlPanel.Controls.Add(this.viewsGroup);

            // Form10
            this.ClientSize = new Size(900, 700);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.controlPanel);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "3D график Z = sin²(x) + sin²(y)";

            this.ResumeLayout(false);
        }
    }
}