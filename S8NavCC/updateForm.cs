using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S8NavCC
{
    public partial class updateForm : Form
    {
        public updateForm()
        {
            InitializeComponent();
        }

        private void updateForm_Load(object sender, EventArgs e)
        {
            string file = File.ReadLines(Path.GetTempPath() + "/uptodate").Skip(1).Take(1).First();
            //MessageBox.Show(file);

            WebClient wcup = new WebClient();
            wcup.DownloadFileAsync(new Uri(file), Path.GetTempPath() + "/S8NavCC.exe");
            wcup.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wcup_DownloadProgressChanged);
            wcup.DownloadFileCompleted += new AsyncCompletedEventHandler(wcup_DownloadFileCompleted);
        }

        bool done = false;
        private void wcup_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs f)
        {
            updatepb.Maximum = (int)(f.TotalBytesToReceive / 100);
            updatepb.Value = (int)(f.BytesReceived/ 100);

            if (f.BytesReceived == (int)f.TotalBytesToReceive)
            {
                done = true;
            }
        }

        private void wcup_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Exception ex = e.Error;
            //MessageBox.Show(ex.ToString());
            if (done == true)
            {
                const string REGISTRY_KEY = @"HKEY_CURRENT_USER\Software\S8NavCC";
                const string REGISTY_VALUE = "FirstRun";
                Microsoft.Win32.Registry.SetValue(REGISTRY_KEY, REGISTY_VALUE, 0, Microsoft.Win32.RegistryValueKind.DWord);


                string currentdir = Directory.GetCurrentDirectory();
                using (StreamWriter sw = new StreamWriter(Path.GetTempPath() + "/installupdate.bat"))
                {
                    sw.WriteLine("timeout /t 1 & del \"" + currentdir + "\\S8NavCC.exe\" & move \"" + Path.GetTempPath() + "S8NavCC.exe" + "\" \"" + currentdir + "\"" + " & timeout /t 1 & \"" + currentdir + "\\S8NavCC.exe\"");
                }
                // Start the child process.
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = Path.GetTempPath() + "/installupdate.bat";
                p.Start();
                Application.Exit();
            }
        }

        private void updatepb_Click(object sender, EventArgs e)
        {

        }
    }
}
