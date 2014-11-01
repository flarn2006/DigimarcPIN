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
        private int[] key = { 0x1F, 0x05, 0x35, 0x07, 0x2B, 0x2F };
        // For some reason there's 8 more bytes in the key, after the 6 above.
        // If anyone has seen an ID with more than 6 digits, please let me know!
        // Complete key: 1F 05 35 07 2B 2F 0D 02 25 13 03 17 11 29

        public MainForm()
        {
            InitializeComponent();
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {
            if (idBox.Text.Length == 6) {
                byte[] stringBytes = Encoding.ASCII.GetBytes(idBox.Text);
                int n = 0;
                for (int i = 0; i < 6; i++) {
                    byte digit = (byte)(stringBytes[i] - 0x30);
                    n += digit * key[5 - i];
                }
                n = n % 89 + 10;
                pinBox.Text = n.ToString();
            } else {
                pinBox.Text = "--";
            }
        }
    }
}
