using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Individual_Task
{
    public partial class Form10 : Form
    {
        private double xMin = -3.0, xMax = 3.0;
        private double yMin = -3.0, yMax = 3.0;
        private int gridSize = 100;

        private float rotationX = 30.0f;
        private float rotationY = 30.0f;
        private float rotationZ = 0.0f;

        private float scale = 1.0f;
        private float translateX = 0.0f;
        private float translateY = 0.0f;

        private Point lastMousePos;
        private bool isDragging = false;
        private MouseButtons dragButton;

        private Bitmap backBuffer;
        private Graphics backGraphics;

        private double[,] zValues;
        private bool needRecalculateZ = true;
        private bool isRendering = false;

        public Form10()
        {
            InitializeComponent();
            SetupDrawingPanel();
        }

        private void SetupDrawingPanel()
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, drawingPanel, new object[] { true });

            this.Load += (s, e) => InitializeBackBuffer();
        }

        // Вид сверху (XY)
        private void TopViewButton_Click(object sender, EventArgs e)
        {
            rotationX = 90;
            rotationY = 0;
            rotationZ = 0;
            RefreshDrawing();
        }

        // Вид спереди (XZ)
        private void FrontViewButton_Click(object sender, EventArgs e)
        {
            rotationX = 0;
            rotationY = 0;
            rotationZ = 0;
            RefreshDrawing();
        }

        // Вид сбоку (YZ)
        private void SideViewButton_Click(object sender, EventArgs e)
        {
            rotationX = 0;
            rotationY = 90;
            rotationZ = 0;
            RefreshDrawing();
        }

        private void InitializeBackBuffer()
        {
            if (drawingPanel.Width > 0 && drawingPanel.Height > 0)
            {
                if (backBuffer != null)
                {
                    backBuffer.Dispose();
                    backGraphics.Dispose();
                }

                backBuffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                backGraphics = Graphics.FromImage(backBuffer);

                backGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                backGraphics.CompositingQuality = CompositingQuality.HighQuality;
                backGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            }
        }

        private void DrawingPanel_Resize(object sender, EventArgs e)
        {
            InitializeBackBuffer();
            needRecalculateZ = true;
            RefreshDrawing();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            rotationX = 30.0f;
            rotationY = 30.0f;
            rotationZ = 0.0f;

            scale = 1.0f;
            translateX = 0.0f;
            translateY = 0.0f;

            RefreshDrawing();
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragButton = e.Button;
            lastMousePos = e.Location;
            drawingPanel.Cursor = Cursors.Hand;
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int dx = e.X - lastMousePos.X;
                int dy = e.Y - lastMousePos.Y;

                if (dragButton == MouseButtons.Left)
                {
                    rotationY += dx * 0.5f;
                    rotationX += dy * 0.5f;
                }
                else if (dragButton == MouseButtons.Right)
                {
                    translateX += dx;
                    translateY += dy;
                }

                lastMousePos = e.Location;
                RefreshDrawing();
            }
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            drawingPanel.Cursor = Cursors.Default;
        }

        private void DrawingPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                scale *= 1.1f;
            else
                scale /= 1.1f;

            scale = Math.Max(0.1f, Math.Min(5.0f, scale));
            RefreshDrawing();
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (isRendering) return;

            try
            {
                isRendering = true;

                if (backBuffer == null ||
                    backBuffer.Width != drawingPanel.Width ||
                    backBuffer.Height != drawingPanel.Height)
                {
                    InitializeBackBuffer();
                }

                if (backGraphics == null) return;

                backGraphics.Clear(Color.White);
                DrawSurface(backGraphics, drawingPanel.ClientSize);

                e.Graphics.DrawImageUnscaled(backBuffer, 0, 0);
            }
            finally
            {
                isRendering = false;
            }
        }

        private void CalculateZValues()
        {
            if (!needRecalculateZ) return;

            int nx = gridSize;
            int ny = gridSize;

            zValues = new double[nx + 1, ny + 1];

            double dx = (xMax - xMin) / nx;
            double dy = (yMax - yMin) / ny;

            for (int i = 0; i <= nx; i++)
            {
                double x = xMin + i * dx;

                for (int j = 0; j <= ny; j++)
                {
                    double y = yMin + j * dy;

                    zValues[i, j] = Math.Sin(x) * Math.Sin(x)
                                  + Math.Sin(y) * Math.Sin(y);
                }
            }

            needRecalculateZ = false;
        }

        private void UpdateInfoLabel()
        {
            if (infoLabel != null)
            {
                infoLabel.Text =
                    $"Вращение X: {rotationX:F0}°\n" +
                    $"Вращение Y: {rotationY:F0}°\n" +
                    $"Вращение Z: {rotationZ:F0}°\n" +
                    $"Масштаб: {scale:F1}x\n" +
                    $"Позиция: ({translateX:F0}, {translateY:F0})";
            }
        }

        private PointF Project(double x, double y, double z, Size clientSize)
        {
            double radX = rotationX * Math.PI / 180.0;
            double radY = rotationY * Math.PI / 180.0;
            double radZ = rotationZ * Math.PI / 180.0;

            double cosX = Math.Cos(radX), sinX = Math.Sin(radX);
            double cosY = Math.Cos(radY), sinY = Math.Sin(radY);
            double cosZ = Math.Cos(radZ), sinZ = Math.Sin(radZ);

            double y1 = y * cosX - z * sinX;
            double z1 = y * sinX + z * cosX;

            double x2 = x * cosY + z1 * sinY;
            double z2 = -x * sinY + z1 * cosY;

            double x3 = x2 * cosZ - y1 * sinZ;
            double y3 = x2 * sinZ + y1 * cosZ;

            float screenX = (float)(x3 * scale * 40 + clientSize.Width / 2 + translateX);
            float screenY = (float)(-y3 * scale * 40 + clientSize.Height / 2 + translateY);

            return new PointF(screenX, screenY);
        }

        private void DrawSurface(Graphics g, Size clientSize)
        {
            CalculateZValues();
            if (zValues == null) return;

            int nx = gridSize;
            int ny = gridSize;

            double dx = (xMax - xMin) / nx;
            double dy = (yMax - yMin) / ny;

            PointF[,] projectedPoints = new PointF[nx + 1, ny + 1];

            for (int i = 0; i <= nx; i++)
            {
                double x = xMin + i * dx;

                for (int j = 0; j <= ny; j++)
                {
                    double y = yMin + j * dy;
                    projectedPoints[i, j] = Project(x, y, zValues[i, j], clientSize);
                }
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.FromArgb(100, 0, 0, 255), 0.5f))
            {
                for (int j = 0; j <= ny; j++)
                {
                    PointF[] points = new PointF[nx + 1];
                    for (int i = 0; i <= nx; i++)
                        points[i] = projectedPoints[i, j];

                    g.DrawLines(pen, points);
                }

                for (int i = 0; i <= nx; i++)
                {
                    PointF[] points = new PointF[ny + 1];
                    for (int j = 0; j <= ny; j++)
                        points[j] = projectedPoints[i, j];

                    g.DrawLines(pen, points);
                }
            }

            DrawAxes(g, clientSize);
            DrawLabels(g, clientSize);
        }

        private bool IsPointVisible(PointF point, Size clientSize)
        {
            return point.X >= -100 && point.X <= clientSize.Width + 100 &&
                   point.Y >= -100 && point.Y <= clientSize.Height + 100;
        }

        private void DrawAxes(Graphics g, Size clientSize)
        {
            PointF origin = Project(0, 0, 0, clientSize);
            PointF xAxis = Project(xMax, 0, 0, clientSize);
            PointF yAxis = Project(0, yMax, 0, clientSize);
            PointF zAxis = Project(0, 0, 2.0, clientSize);

            using (Pen axisPen = new Pen(Color.Red, 2.5f))
            {
                axisPen.EndCap = LineCap.ArrowAnchor;
                g.DrawLine(axisPen, origin, xAxis);
            }

            using (Pen axisPen = new Pen(Color.Green, 2.5f))
            {
                axisPen.EndCap = LineCap.ArrowAnchor;
                g.DrawLine(axisPen, origin, yAxis);
            }

            using (Pen axisPen = new Pen(Color.Blue, 2.5f))
            {
                axisPen.EndCap = LineCap.ArrowAnchor;
                g.DrawLine(axisPen, origin, zAxis);
            }

            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            {
                g.DrawString("X", font, Brushes.Red, xAxis.X + 5, xAxis.Y - 15);
                g.DrawString("Y", font, Brushes.Green, yAxis.X + 5, yAxis.Y - 15);
                g.DrawString("Z", font, Brushes.Blue, zAxis.X - 20, zAxis.Y - 15);
            }
        }

        private void DrawLabels(Graphics g, Size clientSize)
        {
            using (Font font = new Font("Arial", 8))
            {
                for (double x = xMin; x <= xMax; x += 1.0)
                {
                    if (Math.Abs(x) < 0.001) continue;

                    PointF pt = Project(x, 0, 0, clientSize);
                    if (IsPointVisible(pt, clientSize))
                        g.DrawString(x.ToString("F0"), font, Brushes.Red, pt);
                }

                for (double y = yMin; y <= yMax; y += 1.0)
                {
                    if (Math.Abs(y) < 0.001) continue;

                    PointF pt = Project(0, y, 0, clientSize);
                    if (IsPointVisible(pt, clientSize))
                        g.DrawString(y.ToString("F0"), font, Brushes.Green, pt);
                }

                for (double z = 0.5; z <= 2.0; z += 0.5)
                {
                    PointF pt = Project(0, 0, z, clientSize);
                    if (IsPointVisible(pt, clientSize))
                        g.DrawString(z.ToString("F1"), font, Brushes.Blue, pt);
                }
            }
        }

        private void RefreshDrawing()
        {
            if (drawingPanel != null && !drawingPanel.IsDisposed)
            {
                drawingPanel.Invalidate();
                drawingPanel.Update();
                UpdateInfoLabel();
            }
        }
    }
}