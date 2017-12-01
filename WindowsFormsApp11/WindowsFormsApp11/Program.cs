using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
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

        public Point XPosition  // движение спрайта по x
        {
            get
            {
                var y = 0;
                var x = 0;


                return new Point(x + Nextpos, y);
            }
        }

        public void GotoNextFrame()
        {
            CurrentFrame = (CurrentFrame + 1) % FrameCount;
        }
        public void Gogogo()
        {
            Nextpos += 50;
        }
    }

    
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
