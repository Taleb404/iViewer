
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using AForge.Imaging.Filters;
using System.Drawing.Drawing2D;
using System.Threading;

namespace WindowsFormsApplication2
{

    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private static MainForm frm;
        public string currentDir = ""; // Direcrory of images
        public Image imgFile; // save image function
        public Bitmap copyimgFile;
        public string filenameforsave = "";
        int zoomfactor;
        int zoomvalwidth ;
        int zoomvalheight ;
        public string fullPath;
        /// <summary>
        /// Crop Variables
        /// </summary>
        bool mouseClicked;
        bool cropagree;
        Point startPoint = new System.Drawing.Point();
        System.Drawing.Point endPoint = new System.Drawing.Point();
        Rectangle rectCropArea;
       
        /// <summary>
        /// End of Crop Variables
        /// </summary>
        /// 
        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static MainForm getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new MainForm();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }
        public MainForm()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(1000);
            InitializeComponent();
            mouseClicked = false;
            cropagree = false;
            if (frm == null)
                frm = this;
            t.Abort();
            flowLayoutPanel1.MouseWheel += new MouseEventHandler(zoomonflow);
            this.pictureBox1ImagePreview.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBox1ImagePreview_MouseMove);
            zoomfactor = 16;
        }
        void zoomonflow(object sender, MouseEventArgs e)
        {
            if (pictureBox1ImagePreview.Image == null)
                return;
            /*Handle the mouse wheel here*/
            if (e.Delta > 0 && pictureBox1ImagePreview.Image != null)
            {
                pictureBox1ImagePreview.Width += zoomvalwidth;
                pictureBox1ImagePreview.Height += zoomvalheight;
            }
            else if (e.Delta < 0 && pictureBox1ImagePreview.Image != null)
            {
                pictureBox1ImagePreview.Width -= zoomvalwidth;
                pictureBox1ImagePreview.Height -= zoomvalheight;
            }

        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            /*Handle the mouse wheel here*/
            if (e.Delta > 0 && pictureBox1ImagePreview.Image != null)
            {
                pictureBox1ImagePreview.Width += zoomvalwidth;
                pictureBox1ImagePreview.Height += zoomvalheight ;
            }
            else if (e.Delta < 0 && pictureBox1ImagePreview.Image != null)
            {
                pictureBox1ImagePreview.Width -= zoomvalwidth;
                pictureBox1ImagePreview.Height -= zoomvalheight;
            }
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void StartForm()
        {
            Application.Run(new SplashForm());
        }
        private int checkifthereisimage()
        {
            if (imgFile == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "There is No Image In The Box !", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error,95);
                return -1;
            }
            else
                return 1;
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
           
            try
            {
                  var fb = new FolderBrowserDialog();
                  if(fb.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                {

                    currentDir = fb.SelectedPath;
                    metroTextBox1Directory.Text = currentDir;
                    var dirInfo = new DirectoryInfo(currentDir);

                    var files = dirInfo.GetFiles().Where(c => c.Extension.Equals(".jpeg") || c.Extension.Equals(".jpg")
                    || c.Extension.Equals(".png") || c.Extension.Equals(".bmp")
                    || c.Extension.Equals(".PNG") || c.Extension.Equals(".BMP")
                    || c.Extension.Equals(".JPEG")|| c.Extension.Equals(".JPG"));
                    listBox1.Clear();
                    foreach (var image in files)
                    {
                        listBox1.Items.Add(image.Name);
                    }
                    if(listBox1.Items.Count>0)
                    {
                        listBox1.SelectedIndices.Add(0);
                    }
                }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "There is an Error : " + ex.Message + " " + ex.Source, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                var selectedImage = listBox1.SelectedItems[0].Text.ToString();

                if (!string.IsNullOrEmpty(selectedImage) && !string.IsNullOrEmpty(currentDir))
                {
                     fullPath = Path.Combine(currentDir, selectedImage);
                    pictureBox1ImagePreview.Image = System.Drawing.Image.FromFile(fullPath);
                    imgFile = pictureBox1ImagePreview.Image;
                    filenameforsave = listBox1.SelectedItems[0].Text.ToString();
                    copyimgFile = (Bitmap)pictureBox1ImagePreview.Image;

                    zoomvalheight = imgFile.Height / zoomfactor;
                    zoomvalwidth = imgFile.Width / zoomfactor;
                    pictureBox1ImagePreview.SizeMode = PictureBoxSizeMode.StretchImage;
                    int scale1 = pictureBox1ImagePreview.Image.Width * pictureBox1ImagePreview.Image.Height;
                    int scale2 = flowLayoutPanel1.Width * flowLayoutPanel1.Height;
                    if (scale1 > scale2)
                    {
                        pictureBox1ImagePreview.Width = flowLayoutPanel1.Width - 10;
                        pictureBox1ImagePreview.Height = flowLayoutPanel1.Height - 10;
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void RotateStripMenuItem1_Click(object sender, EventArgs e)
        {

            RotateBicubic ro = new RotateBicubic(90, false);
            try
            {
                pictureBox1ImagePreview.Image = ro.Apply((Bitmap)pictureBox1ImagePreview.Image);
                imgFile = pictureBox1ImagePreview.Image;
                pictureBox1ImagePreview.Image = imgFile;
                pictureBox1ImagePreview.Refresh();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "There is no Loaded Picture ib the Box !."+ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = filenameforsave;
            if (imgFile == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "There is no Loaded Picture in the Box !.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (sf.ShowDialog() == DialogResult.OK)
            {
                imgFile.Save(sf.FileName);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgFile != null)
            {
                PrintDialog pd = new PrintDialog();
                PrintDocument doc = new PrintDocument();
                doc.PrintPage += Doc_PrintPage;
                pd.Document = doc;
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    doc.Print();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "There is no Loaded Picture in the Box !.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1ImagePreview.Width, pictureBox1ImagePreview.Height);
            pictureBox1ImagePreview.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1ImagePreview.Width, pictureBox1ImagePreview.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();

        }


        private void OpenFileStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPEG(*.JPG)BMP(*.BMP)PNG(*.PNG)|*.jpg;*.PNG;*.png;*.BMP;*.bmp";
            if (f.ShowDialog() == DialogResult.OK)
            {
                imgFile = Image.FromFile(f.FileName);
                filenameforsave = f.FileName;
                pictureBox1ImagePreview.Image = imgFile;
                copyimgFile = (Bitmap)pictureBox1ImagePreview.Image;

                pictureBox1ImagePreview.Width = imgFile.Width;
                pictureBox1ImagePreview.Height = imgFile.Height;
                zoomvalheight = imgFile.Height / zoomfactor;
                zoomvalwidth = imgFile.Width / zoomfactor;
                pictureBox1ImagePreview.SizeMode = PictureBoxSizeMode.StretchImage;
                int scale1 = pictureBox1ImagePreview.Image.Width * pictureBox1ImagePreview.Image.Height;
                int scale2 = flowLayoutPanel1.Width * flowLayoutPanel1.Height;
                if (scale1 > scale2)
                {
                    pictureBox1ImagePreview.Width = flowLayoutPanel1.Width - 10;
                    pictureBox1ImagePreview.Height = flowLayoutPanel1.Height - 10;
                }

            }
        }

      

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            pictureBox1ImagePreview.Image.Save(filenameforsave);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = filenameforsave;
           if (sf.ShowDialog() == DialogResult.OK)
            {
                imgFile.Save(sf.FileName);
            }
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            printToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            RotateStripMenuItem1_Click(sender, e);
        }


        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            GrayscaleBT709 gray = new GrayscaleBT709();
            try
            {
                pictureBox1ImagePreview.Image = gray.Apply((Bitmap)pictureBox1ImagePreview.Image);
                imgFile = pictureBox1ImagePreview.Image;
            }
            catch (Exception ex)
            { }
        }

        private void waterWaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            WaveFilterControl FilterWindow = new WaveFilterControl();
            FilterWindow.ShowDialog();
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            Blur filter = new Blur();
            filter.ApplyInPlace((Bitmap)pictureBox1ImagePreview.Image);
            pictureBox1ImagePreview.Refresh();
            pictureBox1ImagePreview.Update();
        }

        private void colorChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            ChannelFilterControl sh = new ChannelFilterControl();
            sh.ShowDialog();

        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            Invert filter = new Invert();
            try
            {
                pictureBox1ImagePreview.Image = filter.Apply((Bitmap)pictureBox1ImagePreview.Image);
                imgFile = pictureBox1ImagePreview.Image;
            }
            catch (Exception ex)
            { }
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            Mirror filter = new Mirror(false, true);
            try
            {
                pictureBox1ImagePreview.Image = filter.Apply((Bitmap)pictureBox1ImagePreview.Image);
                imgFile = pictureBox1ImagePreview.Image;
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
       // Begining of Corp Section
        /// </summary>
      
        private void pictureBox1ImagePreview_Paint(object sender, PaintEventArgs e)
        {
            if (cropagree != true)
                return;
            Pen drawLine = new Pen(Color.Red);
            drawLine.DashStyle = DashStyle.Dash;
            e.Graphics.DrawRectangle(drawLine, rectCropArea);
        }
  
        private void pictureBox1ImagePreview_MouseDown(object sender, MouseEventArgs e)
        {

            if (cropagree != true)
                return;
            mouseClicked = true;
      
            startPoint.X = e.X;
            startPoint.Y = e.Y;
            endPoint.X = -1;
            endPoint.Y = -1;

            rectCropArea = new Rectangle(new Point(e.X, e.Y), new Size());
        }
     

        private void pictureBox1ImagePreview_Click(object sender, EventArgs e)
        {
            if (cropagree != true)
                return;
            pictureBox1ImagePreview.Refresh();
        }
        /// <summary>
        // End of Corp Section
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.I)
            {
                AboutForm ab = new AboutForm();
                ab.ShowDialog();
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
           try
            {
                int scale1 = pictureBox1ImagePreview.Image.Width * pictureBox1ImagePreview.Image.Height;
                int scale2 = flowLayoutPanel1.Width * flowLayoutPanel1.Height;
                if (scale1 > scale2)
                {
                    pictureBox1ImagePreview.Width = flowLayoutPanel1.Width - 10;
                    pictureBox1ImagePreview.Height = flowLayoutPanel1.Height - 10;
                }
            }
            catch(Exception ex)
            { }
        }

   

        private void zoomInToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            pictureBox1ImagePreview.Width += zoomvalwidth;
            pictureBox1ImagePreview.Height += zoomvalheight;
        }

        private void cropToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            cropagree = true;
        }

        private void resetOriginalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            pictureBox1ImagePreview.Image = null;
            pictureBox1ImagePreview.Image = copyimgFile;
            int scale1 = pictureBox1ImagePreview.Image.Width * pictureBox1ImagePreview.Image.Height;
            int scale2 = flowLayoutPanel1.Width * flowLayoutPanel1.Height;
            if (scale1 > scale2)
            {
                pictureBox1ImagePreview.Width = flowLayoutPanel1.Width - 10;
                pictureBox1ImagePreview.Height = flowLayoutPanel1.Height - 10;
            }
            pictureBox1ImagePreview.Refresh();
            pictureBox1ImagePreview.Update();
        }

        private void slideShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            SlideShowForm s = new SlideShowForm();
            s.ShowDialog();
        }

        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ImageViewer.com");
        }

      

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseWheel(e);
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkifthereisimage() != 1)
                return;
            ResizeForm w = new ResizeForm();
            w.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void zoomOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1ImagePreview.Width -= zoomvalwidth;
            pictureBox1ImagePreview.Height -= zoomvalheight;
        }

        private void pictureBox1ImagePreview_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (cropagree != true)
                return;
            mouseClicked = false;
            cropagree = false;
            if (endPoint.X != -1)
            {
                Point currentPoint = new System.Drawing.Point(e.X, e.Y);
               
            }
            endPoint.X = -1;
            endPoint.Y = -1;
            startPoint.X = -1;
            startPoint.Y = -1;


            pictureBox1ImagePreview.Refresh();
            
            Bitmap sourceBitmap = new Bitmap(pictureBox1ImagePreview.Image,
                pictureBox1ImagePreview.Width, pictureBox1ImagePreview.Height);
            Crop filter = new Crop(rectCropArea);
            // apply the filter
            Bitmap newImage = filter.Apply(sourceBitmap);
            pictureBox1ImagePreview.Image = newImage;
            imgFile = pictureBox1ImagePreview.Image;

        }

        private void pictureBox1ImagePreview_MouseMove(object sender, MouseEventArgs e)
        {

            OnMouseWheel(e);
            if (cropagree != true)
                return;
            Point ptCurrent = new System.Drawing.Point(e.X, e.Y);

            if (mouseClicked)
            {
              

                endPoint = ptCurrent;

                if (e.X > startPoint.X && e.Y > startPoint.Y)
                {
                    rectCropArea.Width = e.X - startPoint.X;
                    rectCropArea.Height = e.Y - startPoint.Y;
                }
                else if (e.X < startPoint.X && e.Y > startPoint.Y)
                {
                    rectCropArea.Width = startPoint.X - e.X;
                    rectCropArea.Height = e.Y - startPoint.Y;
                    rectCropArea.X = e.X;
                    rectCropArea.Y = startPoint.Y;
                }
                else if (e.X > startPoint.X && e.Y < startPoint.Y)
                {
                    rectCropArea.Width = e.X - startPoint.X;
                    rectCropArea.Height = startPoint.Y - e.Y;
                    rectCropArea.X = startPoint.X;
                    rectCropArea.Y = e.Y;
                }
                else
                {
                    rectCropArea.Width = startPoint.X - e.X;
                    rectCropArea.Height = startPoint.Y - e.Y;
                    rectCropArea.X = e.X;
                    rectCropArea.Y = e.Y;
                }
                pictureBox1ImagePreview.Refresh();
            }
        }
    }
}
