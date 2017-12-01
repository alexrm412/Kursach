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
        Menu mn = new Menu();
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public int  count = File.ReadAllLines("result.txt").Length;
        private Sprite sprite;
      //  public int CursorX = Cursor.Position.X;
       // public int CursorY = Cursor.Position.Y;
        SoundPlayer sndPlayerp = new SoundPlayer(@"C:\gun2.wav");
        SoundPlayer sndPlayerpt = new SoundPlayer(@"D:\tank.wav");
        SoundPlayer sndPlayerg = new SoundPlayer(@"D:\miss.wav");
        SoundPlayer empty = new SoundPlayer(@"d:\mix.wav");
        public int shot=0;
        public int shotp = 0;
        public int shotg = 0;
        public int pause = 0;
        public int forest = 0;
        public int wheel = 0;
        public Form1()
        {
            
            InitializeComponent();
           
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            var img = (Bitmap)Image.FromFile(@"d:\runer.png");
            sprite = new Sprite { FrameSize = new Size(280, 385), Image = img, FrameCount = 10 };
            //new Timer() { Interval = 700, Enabled = true }.Tick += delegate { sprite.GotoNextFrame(); sprite.Gogogo(); Invalidate(); };
            myTimer.Interval = 70; myTimer.Start(); myTimer.Tick += delegate { sprite.GotoNextFrame(); sprite.Gogogo(); Invalidate(); };
            this.MouseWheel += new MouseEventHandler(this_MouseWheel);
        }

        void this_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                wheel++;
           
            else
                wheel--;
            if (wheel == 3) wheel = 0;
            if (wheel == -1) wheel = 2;
            

        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
           

            int i = 0;
            int il = 0;
            int ii = 0;
            int k = 68;
            switch (shot)// пистолет1
            {
                case 1:i = k;break;
                case 2:i = 2*k;break;
                case 3:i = 3*k;break;
                case 4: i = 4 * k; break;
                case 5: i = 5 * k; break;
                case 6: i = 6 * k; break;               
            }
            switch (shotp)// пистолет 2
            {
                case 1: il = k; break;
                case 2: il = 2 * k; break;
                case 3: il = 3 * k; break;
                case 4: il = 4 * k; break;
                case 5: il = 5 * k; break;
                case 6: il = 6 * k; break;                
            }
            switch (shotg)// дробовик
            {
                case 1: ii = k; break;
                case 2: ii = 2 * k; break;
                case 3: ii = 3 * k; break;
                case 4: ii = 4 * k; break;
                case 5: ii = 5 * k; break;
                case 6: ii = 6 * k; break;                   
            }

            switch (wheel)
            {
                case 0: e.Graphics.DrawImage(Properties.Resources.pushechka, 20, 380, 100, 100);
                    e.Graphics.DrawImage(Properties.Resources.fon, 410, 337);
                    for (int j = i; i <= 340; i += 68)
                    {
                        if (shot <= 6) e.Graphics.DrawImage(Properties.Resources.патрон, 416 + i, 339);

                    }; break;
                case 1: e.Graphics.DrawImage(Properties.Resources.push, 20, 380, 100, 100);
                    e.Graphics.DrawImage(Properties.Resources.fono, 410, 337);
                    for (int jl = il; il <= 340; il += 68)
                    {
                        if (shotp <= 6) e.Graphics.DrawImage(Properties.Resources.патронус, 416 + il, 339);

                    }; break;
                case 2: e.Graphics.DrawImage(Properties.Resources.ruzzho, 20, 380, 100, 100);
                    e.Graphics.DrawImage(Properties.Resources.font, 410, 337);
                    for (int ji = ii; ii <= 340; ii += 68)
                    {
                        if (shotg <= 6) e.Graphics.DrawImage(Properties.Resources.патронсо, 416 + ii, 339);

                    }; break;
                   
            }
                    
             if(forest==0) e.Graphics.DrawImage(sprite.Image, new Rectangle(sprite.XPosition, sprite.FrameSize), new Rectangle(sprite.CurrentFrameLocation, sprite.FrameSize), GraphicsUnit.Pixel);
           if (shot == 1)
              e.Graphics.DrawImage(Properties.Resources.hole, Cursor.Position.X, Cursor.Position.Y,20,20);
           
            e.Graphics.DrawImage(Properties.Resources.menub, 0, 0);
            e.Graphics.DrawImage(Properties.Resources.points, 617, 0);
            if (pause == 1)//пауза
            {
                myTimer.Stop();
                e.Graphics.DrawImage(Properties.Resources.white, 0, 0);
                e.Graphics.DrawImage(Properties.Resources.pause, 320, 100);
                e.Graphics.DrawImage(Properties.Resources._continue, 300, 200, 220, 57);
                e.Graphics.DrawImage(Properties.Resources.exit, 300, 290, 220, 57);

            }
        }
                   
              
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        int n=0 ;//очки

        private void Form1_MouseDown(object sender, MouseEventArgs e)  //onclick
        {
            
            int x1 = e.X;
            int y1 = e.Y;
            if (pause != 1)
            {


                if ((x1 > 146) && (y1 > 46))
                {
                    switch (wheel)
                    {
                        case 0:
                            shot++;
                            if (shot <= 6) { sndPlayerp.Play(); }
                            else
                            {
                                empty.Play();
                            }break;
                        case 1:shotp++;
                            if (shotp <= 6) { sndPlayerpt.Play(); }
                            else
                            {
                                empty.Play();
                            }break;
                        case 2:shotg++;
                            if (shotg <= 6) { sndPlayerg.Play(); }
                            else
                            {
                                empty.Play();
                            }
                            break;
                    }
                        
                   
                }
                
                int step = sprite.Nextpos;

                if (((y1 >= 45) && (y1 <= 343)) && ((x1 >= 76 + step) && (x1 <= 246 + step)))//мишень форест
                {

                    forest = 1;
                    n = 150;
                    x1 = 999;
                    y1 = 999;
                    label1.Text = "Количество очков: " + n;
                    

                }
               
            }
            else
            {
                if (((y1 >= 290) && (y1 <= 347)) && ((x1 >= 300) && (x1 <= 521)))//выход
                {
                    try
                    {
                        using (var writer = new StreamWriter("result.txt", true))
                        {
                            writer.WriteLine(n + " игрок " + count);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }

                    List<string> lst = new List<string>();
                    using (StreamReader sr = new StreamReader("result.txt"))
                    {
                        while (sr.Peek() > -1)
                        {
                            lst.Add(sr.ReadLine());
                        }
                    }

                    var lstOut = lst.Take(count+1).OrderByDescending(x => int.Parse(x.Split(' ')[0])).Concat(lst.Skip(count+1));
                    using (StreamWriter sw = new StreamWriter("result.txt", append: false))
                    {
                        foreach (string str in lstOut)
                        {
                            sw.WriteLine(str);
                        }
                    }
                    Close();
                }
            }
            if ((x1 <= 146) && (y1 <= 46))//пауза
            {
                pause = 1;
               
                Cursor = Cursors.Hand;
            }
            if(((y1 >= 200) && (y1 <= 257)) && ((x1 >= 300) && (x1 <= 521)))//продолжить игру
            {
                pause = 0;
                myTimer.Start();
                Cursor = Cursors.Cross;
                
            }
           

        }        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {            
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           // textBox1.Text = Convert.ToString(CursorY);// e.X.ToString();
            textBox2.Text = e.Y.ToString();
        }                       
             
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
/*try вывод топ 10
           {
               StreamReader sr = new StreamReader("result.txt");
               string str = "";
               int c = 0;
               while ((str = sr.ReadLine()) != null)
               {
                   c += 1;
                   label1.Text += str;
                   if (c ==10) break;
               }
               sr.Close();
           }
           catch (Exception exc)
           {
               MessageBox.Show(exc.Message);
           }*/
