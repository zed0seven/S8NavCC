using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S8NavCC
{
    public partial class UpdateNotes : Form
    {
        public UpdateNotes()
        {
            InitializeComponent();
        }

        private void UpdateNotes_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            versionlbl.Text = Form1.GlobalVar.currentversion;

        }
    }
}
