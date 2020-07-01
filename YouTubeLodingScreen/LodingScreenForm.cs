using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTubeLodingScreen
{
    public partial class LodingScreenForm : Form
    {
        Hook BindKey_Space;
        bool Active;
        int Progress   = 0, 
            LoadingSol = 0;
        float Speed    = 100;
        string[] A     = { ".", "..", "..." };


        private void SetValueLoding( int i , int MinInt = 0 , int max = 100)
        {
            loding.Size = new Size(panel2.Width * i / (max - MinInt), 15);
            label1.Text = i.ToString() + "%";
        }

        public LodingScreenForm()
        {
            InitializeComponent();
            if(BindKey_Space != null)
            {
                BindKey_Space.Dispose();
            }
            BindKey_Space = new Hook((int)Keys.Space);
            BindKey_Space.KeyPressed += new KeyPressEventHandler(_hook_key);
            BindKey_Space.SetHook();
        }
        void _hook_key(object sender, KeyPressEventArgs e)
        {          
            timer1.Enabled = Active = !Active;             
            if (!Active)
            {                
                SetValueLoding(Progress = 0);
                label2.Text = "Loading";
            }
            else
            {
                timer1.Interval = (int)(Speed);              
            }
        }
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1920, 1080);
            this.Location = new Point(0, 0);
            panel1.Location = new Point(
                1920/2 - panel1.Size.Width / 2,
                1080/2 - panel1.Size.Height / 2 + 200
            );
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Progress < 100)
            {
                Progress++;
                SetValueLoding(Progress);
                label2.Text = "Loading" + A[LoadingSol];
                LoadingSol++;
                if (LoadingSol > A.Length - 1)
                {
                    LoadingSol = 0;
                }
            }
            else
            {
                label2.Text = "Loading";
            }
        }
    }
}
