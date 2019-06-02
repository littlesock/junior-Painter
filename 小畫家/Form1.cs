using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 小畫家
{
    public partial class From1 : Form
    {
        public From1()
        {
            InitializeComponent();
        }

        private void 開新檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(800, 600);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
        }

        private void From1_Load(object sender, EventArgs e)
        {
            開新檔案ToolStripMenuItem_Click(sender, e);
        }

        private void 開啟舊檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                bmp.Save(saveFileDialog1.FileName);
            }
        }

        int x0, y0;
        Bitmap bg;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                Pen p = new Pen(colorDialog1.Color, int.Parse(toolStripComboBox1.Text));
                g.DrawLine(p,x0, y0, e.X, e.Y);
                x0 = e.X;
                y0 = e.Y;
                pictureBox1.Refresh();
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Bitmap bf = new Bitmap(bg);
                Graphics g2 = Graphics.FromImage(bf);
                Brush bush = new SolidBrush(colorDialog1.Color);
                g2.FillEllipse(bush, x0, y0, Math.Abs(e.X - x0), Math.Abs(e.Y - y0));
                pictureBox1.Image = bf;

            }
        }

        private void 顏色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x0 = e.X;
            y0 = e.Y;
            bg = new Bitmap(pictureBox1.Image);
        }
    }
}
