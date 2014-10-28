using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigimarcPIN
{
    public partial class MainForm : Form
    {
        private int[] key = { 0x1F, 0x05, 0x35, 0x07, 0x2B, 0x2F, 0x0D, 0x02, 0x25, 0x13, 0x03, 0x17, 0x11, 0x29 };

        public MainForm()
        {
            InitializeComponent();
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {
            if (idBox.Text.Length == 6) {
                byte[] stringBytes = Encoding.ASCII.GetBytes(idBox.Text);
                int n = 0;
                for (int i = 0; i < idBox.Text.Length; i++) {
                    byte digit = (byte)(stringBytes[i] - 0x30);
                    n += digit * key[idBox.Text.Length - 1 - i];
                }
                n = n % 89 + 10;
                pinBox.Text = n.ToString();
            } else {
                pinBox.Text = "--";
            }
        }
    }
}
