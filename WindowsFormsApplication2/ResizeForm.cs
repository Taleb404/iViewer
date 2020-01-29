using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
namespace WindowsFormsApplication2
{
    public partial class ResizeForm : MetroFramework.Forms.MetroForm
    {
        public ResizeForm()
        {
            InitializeComponent();
        }

        private void ResizeForm_Load(object sender, EventArgs e)
        {
      
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            int x, y;
            Int32.TryParse(metroTextBox1.Text, out x);
            Int32.TryParse(metroTextBox2.Text, out y);
            ResizeBilinear filter = new ResizeBilinear(x, y);
            Bitmap newImage = filter.Apply((Bitmap)MainForm.getMainForm.imgFile);
            MainForm.getMainForm.imgFile = newImage;
            MainForm.getMainForm.pictureBox1ImagePreview.Image = newImage;
            MainForm.getMainForm.pictureBox1ImagePreview.SizeMode = PictureBoxSizeMode.Normal;
            MainForm.getMainForm.pictureBox1ImagePreview.Refresh();
            Close();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
