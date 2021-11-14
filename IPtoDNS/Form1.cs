using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace IPtoDNS
{
    public partial class Form1 : Form
    {
        int mov;
        int movX;
        int movY;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var _process = Process.GetCurrentProcess();
            _process.Kill();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] ipaddress = Dns.GetHostAddresses(textBox1.Text);
                foreach (IPAddress ipaddr in ipaddress)
                {
                    textBox2.Text = Convert.ToString(ipaddr);
                }
            } 
            catch
            {
                MessageBox.Show("Please Enter a Valid DNS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://instagram.com/hereioz");
        }
    }
}