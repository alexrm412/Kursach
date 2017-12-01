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

namespace WindowsFormsApp11
{
    public partial class Menu : Form
    {
        public int count = File.ReadAllLines("result.txt").Length;
        public string nm;
        public Menu()
        {
            InitializeComponent();
        }
        TextBox txt = new TextBox();
        private void button1_Click(object sender, EventArgs e)
        {
           
            this.AutoSize = true;
                this.Controls.Add(txt);
            txt.Size = button1.Size;
            txt.Location = new Point(button1.Location.X, button1.Location.Y + 50);
            Button baton = new Button();
            baton.Site = button1.Site;
            baton.Text = "hi pipl";
            baton.Location = new Point(txt.Location.X + 200, txt.Location.Y);
            this.Controls.Add(baton);
            baton.Click += new EventHandler(baton_Click);
            txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
            txt.TextChanged += new EventHandler(txt_TextChanged);
        }
        protected void baton_Click(object sender,EventArgs e)
        {
            Button baton = sender as Button;
            //Close();

            nm = txt.Text;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void txt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
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
        }

        private void Menu_Load(object sender, EventArgs e)
        {
           

        }
    }
}
