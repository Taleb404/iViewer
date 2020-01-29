using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AForge;
using AForge.Imaging;
using AForge.Imaging.ComplexFilters;
using AForge.Imaging.ColorReduction;
using AForge.Imaging.Filters;
namespace WindowsFormsApplication2
{
    public partial class WaveFilterControl : MetroFramework.Forms.MetroForm
    {
        Bitmap imgcopy1;
        Bitmap imgcopy;
        public WaveFilterControl()
        {
            InitializeComponent();
        }

        private void applyfilter(int a,int b,int c,int d)
        {
             imgcopy = imgcopy1 ;
            
            WaterWave filter = new WaterWave();
            filter.HorizontalWavesCount = a;
            filter.HorizontalWavesAmplitude = b;
            filter.VerticalWavesCount = c;
            filter.VerticalWavesAmplitude = d;
           imgcopy= filter.Apply(imgcopy);
            MainForm.getMainForm.pictureBox1ImagePreview.Image = imgcopy;

        }
        private void WaveFilterControl_Load(object sender, EventArgs e)
        {
             imgcopy1 = (Bitmap)MainForm.getMainForm.pictureBox1ImagePreview.Image;
        }

        private void metroTrackBar3_Scroll(object sender, ScrollEventArgs e)
        {
            applyfilter(metroTrackBar1.Value, metroTrackBar2.Value
             , metroTrackBar3.Value, metroTrackBar4.Value);
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            applyfilter(metroTrackBar1.Value, metroTrackBar2.Value
                , metroTrackBar3.Value, metroTrackBar4.Value);
        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            applyfilter(metroTrackBar1.Value, metroTrackBar2.Value
             , metroTrackBar3.Value, metroTrackBar4.Value);
        }

        private void metroTrackBar4_Scroll(object sender, ScrollEventArgs e)
        {
            applyfilter(metroTrackBar1.Value, metroTrackBar2.Value
             , metroTrackBar3.Value, metroTrackBar4.Value);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            applyfilter(0,0,0,0);
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MainForm.getMainForm.imgFile = imgcopy;
            this.Close();
        }
    }
}
