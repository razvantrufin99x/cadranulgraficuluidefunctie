using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cadranulgraficuluidefunctie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Graphics g;
        public Pen pen0 = new Pen(Color.Black);
        public float cx, cy, px, py;
        public float step = (360 / 30);
        public float ctrad = (float)(180 / Math.PI);
        public float dimx, dimy, posx, posy;
        public int mx, my;
        public int rotatx = 2;
        public int rotaty = 2;
        public int cadran = -1;
        public int ismd = 0;

        public int getpositionInCadran(int x,int y)
        { 
            
            if (y < posy && x > posx) { return 1; }
            else if (y < posy && x < posx) { return 2; }
            else if (y > posy && x < posx) { return 3; }
            else if (y > posy && x > posx) { return 4; }
            else if (y == posy && x > posx) { return 14; }
            else if (y == posy && x < posx) { return 23; }
            else if (y > posy && x == posx) { return 34; }
            else if (y < posy && x == posx) { return 12; }
            else { return -1; }
             
        }
        public void drawcadranegrafic()
        { 
            g.DrawLine(pen0,   0 , posy , Width , posy);
            g.DrawLine(pen0, posx, 0, posx, Height);

        }
        public void drawacircle1()
        {


            for (float i = 0; i < 360 + step; i += step)
            {
                px = cx;
                py = cy;

                cx = (float)Math.Cos((i + mx) / ctrad) * dimx + posx;
                cy = (float)Math.Sin((i + my) / ctrad) * dimy + posy;

                g.DrawLine(pen0, cx, cy, px, py);
            }
        }

        


        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            cx = cy = px = py = 0;
            dimx = 200;
            dimy = 200;
            posx = 400;
            posy = 400;
            centrugrafic1.Left = (int)posx;
            centrugrafic1.Top = (int)posy;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismd == 1)
            {
                g.Clear(BackColor);
                posx = centrugrafic1.Left;
                posy = centrugrafic1.Top;
                mx = e.X / rotatx;
                my = e.Y / rotaty;
                drawcadranegrafic();
                drawacircle1();
                Text = "";
                Text += e.X.ToString() + " : " + e.Y.ToString() + " : " + getpositionInCadran(e.X, e.Y).ToString();
                cadran = getpositionInCadran(e.X, e.Y);
                Text += " : ";
                if (cadran == 1) { Text += (e.X - posx).ToString() + " : " + (posy - e.Y).ToString(); }
                else if (cadran == 2) { Text += (posx - e.X).ToString() + " : " + (posy - e.Y).ToString(); }
                else if (cadran == 3) { Text += (posx - e.X).ToString() + " : " + (e.Y - posy).ToString(); }
                else if (cadran == 4) { Text += (e.X - posx).ToString() + " : " + (e.Y - posy).ToString(); }
                else if (cadran == 12) { Text += (0).ToString() + " : " + (posy - e.Y).ToString(); }
                else if (cadran == 23) { Text += (e.X - posx).ToString() + " : " + (0).ToString(); }
                else if (cadran == 34) { Text += (0).ToString() + " : " + (posy - e.Y).ToString(); }
                else if (cadran == 14) { Text += (e.X - posx).ToString() + " : " + (0).ToString(); }
                else { Text += "  -1"; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = 1;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = 0;
        }

       
    }
}
