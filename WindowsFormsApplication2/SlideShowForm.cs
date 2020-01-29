using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class SlideShowForm : MetroFramework.Forms.MetroForm
    {

        int i, c;
        public SlideShowForm()
        {
            InitializeComponent();
        }

        private void SlideShowForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.None;
            i= 1;
             c = MainForm.getMainForm.listBox1.Items.Count;

            var selectedImage = MainForm.getMainForm.listBox1.Items[0].Text;
            var fullPath = Path.Combine(MainForm.getMainForm.currentDir, selectedImage);
            pictureBox1.Image = Image.FromFile(fullPath);
            pictureBox1.Refresh();
        }

        private void SlideShowForm_Shown(object sender, EventArgs e)
        {
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (i == c - 1)
                i = 0;
                  i++;
                var selectedImage = MainForm.getMainForm.listBox1.Items[i].Text;
                var fullPath = Path.Combine(MainForm.getMainForm.currentDir, selectedImage);
                pictureBox1.Image = Image.FromFile(fullPath);
                pictureBox1.Refresh();
 
            
            
        }
    }
}
