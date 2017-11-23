using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Media;
namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private Sprite sprite;
        SoundPlayer sndPlayer = new SoundPlayer(@"C:\gun2.wav");
     
        public Form1()
        {
            InitializeComponent();
            
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            var img = (Bitmap)Image.FromFile(@"d:\runer.png");
            sprite = new Sprite { FrameSize = new Size(280, 385), Image = img, FrameCount = 10 };
            
            new Timer() { Interval = 70, Enabled = true }.Tick += delegate { sprite.GotoNextFrame(); sprite.Gogogo(); Invalidate(); };
            
        }
        //Point Point1 = new Point(100, 100);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(sprite.Image, new Rectangle(sprite.XPosition, sprite.FrameSize), new Rectangle(sprite.CurrentFrameLocation, sprite.FrameSize), GraphicsUnit.Pixel);
        }
        
        class Sprite
        {
            public Size FrameSize;
            public Image Image;
            public int CurrentFrame = -1;
            public int FrameCount;
            public int Nextpos;
            
            public Point CurrentFrameLocation
            {
                get
                {
                    var framesPerRow = Image.Width / FrameSize.Width;
                    var x = CurrentFrame % framesPerRow;
                    var y = CurrentFrame / framesPerRow;

                    return new Point(x * FrameSize.Width, y * FrameSize.Height);
                    
                }
            }
            
            public Point XPosition
            {
                get
                {
                    var y = 0;
                    var x = 0;
                    
                 
                    return new Point(x+Nextpos, y);
                }
            }

            public void GotoNextFrame()
            {
                CurrentFrame = (CurrentFrame + 1) % FrameCount;
            }
            public void Gogogo()
            {
                Nextpos +=  50;
            }
        }

       
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        int n=0 ;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int step = sprite.Nextpos;
            int x1 = e.X;
            int y1 = e.Y;
            if (((y1 >= 45) && (y1 <= 343)) && ((x1 >= 76+step) && (x1 <= 246+step)))
            {
                n += 1;
                label1.Text = " " + n;
                sndPlayer.Play();
                
            }

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
               
            textBox1.Text = e.X.ToString();
            textBox2.Text = e.Y.ToString();

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (var writer = new StreamWriter("result.txt", true))
                {

                    writer.WriteLine(n);
                    writer.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }

}


/* Чтение файла
 * try
            {
                StreamReader sr = new StreamReader("result.txt");
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    label1.Text += str;
                }
                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }*/
