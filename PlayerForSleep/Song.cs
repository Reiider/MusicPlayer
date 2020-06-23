using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerForSleep
{
    public partial class ListMusic : UserControl
    {
        public int List { get; set; }
        public int Index { get; set; }
        private string n;
        public string NameMusic
        {
            get
            {
                return n;
            }
            set
            {
                lName.Text = value;
                n = value;
            }
        }

        public delegate void song(int list, int index);
        public event song deleteSong;
        public event song playSong;
        
        public ListMusic()
        {
            InitializeComponent();
        }

        public void set(string name, int list, int index)
        {
            NameMusic = name;
            List = list;
            Index = index;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            playSong(List, Index);
        }

        private void bBlackList_Click(object sender, EventArgs e)
        {
            deleteSong(List, Index);
        }

        public void resetColor()
        {
            lName.BackColor = Color.Black;
        }

        public void setColor()
        {
            lName.BackColor = Color.Blue;
        }
    }
}
