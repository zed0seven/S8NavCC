using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S8NavCC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void usbdbgbtn_Click(object sender, EventArgs e)
        {
            usbdbgForm usbdebugform = new usbdbgForm();
            usbdebugform.Show();
            this.Enabled = false;
            usbdebugform.FormClosed += (s, args) => this.Enabled = true;
        }

        private void driverbtn_Click(object sender, EventArgs e)
        {
            driverForm driverform = new driverForm();
            driverform.Show();
            this.Enabled = false;
            driverform.FormClosed += (s, args) => this.Enabled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void upnotesbtn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            UpdateNotes un = new UpdateNotes();
            un.Show();
            this.FormClosed += (s, args) => un.Close();
            un.FormClosed += (s, args) => this.Enabled = true;
        }
    }
}
