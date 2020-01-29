using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.ComplexFilters;
using AForge.Imaging.ColorReduction;
using AForge.Imaging.Filters;
namespace WindowsFormsApplication2
{
    public partial class ChannelFilterControl : MetroFramework.Forms.MetroForm
    {
        Bitmap copyimg;
        Bitmap copyimg1;

        public ChannelFilterControl()
        {
            InitializeComponent();
        }
        private void applyfilter(int a,int b ,int c)
        {
            copyimg = copyimg1;
            ChannelFiltering filter = new ChannelFiltering();
            filter.Red = new IntRange(a, 255);
            filter.Green = new IntRange(b, 255);
            filter.Blue = new IntRange(c, 255);
            try
            {
                copyimg = filter.Apply(copyimg);
                MainForm.getMainForm.pictureBox1ImagePreview.Image = copyimg;
            }
            catch(Exception ex)
            { }
        }
        private void ChannelFilterControl_Load(object sender, EventArgs e)
        {
            copyimg1 = (Bitmap)MainForm.getMainForm.pictureBox1ImagePreview.Image;

        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            applyfilter(metroTrackBar1.Value, metroTrackBar2.Value, metroTrackBar3.Value);
        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            applyfilter(metroTrackBar1.Value, metroTrackBar2.Value, metroTrackBar3.Value);
        }

        private void metroTrackBar3_Scroll(object sender, ScrollEventArgs e)
        {
            applyfilter(metroTrackBar1.Value, metroTrackBar2.Value, metroTrackBar3.Value);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MainForm.getMainForm.imgFile = copyimg;
            Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            applyfilter(0, 0, 0);
            Close();
        }
    }
}
