using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cadranulgraficuluidefunctie
{
    public partial class centrugrafic : UserControl
    {
        public centrugrafic()
        {
            InitializeComponent();
        }
        public int ismd=0;
        private void centrugrafic_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = 0;
        }

        private void centrugrafic_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = 1;
        }

        private void centrugrafic_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismd == 1)
            {
                Left += e.X;
                Top += e.Y;
            }
        }
    }
}
