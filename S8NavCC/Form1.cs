using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Drawing.Imaging;

namespace S8NavCC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static class GlobalVar
        {
            public const string currentversion = "0.9.8";
        }
        #region BEGINNING INITIALIZING FUNCTIONS
        private void ToggleForms(int f, int g)
        {

            if (f == 1)         //textBox1 and hexlinkbtn
            {
                if (g == 1)
                {
                    textBox1.Enabled = true;
                    textBoxAlpha.Enabled = true;
                    hexlinkbtn.Enabled = true;
                    blackpb.Enabled = true;
                    whitepb.Enabled = true;
                    transppb.Enabled = true;
                }
                else if (g == 0)
                {
                    textBox1.Enabled = false;
                    textBoxAlpha.Enabled = true;
                    hexlinkbtn.Enabled = false;
                    blackpb.Enabled = false;
                    whitepb.Enabled = false;
                    transppb.Enabled = false;
                }
            }
            else if (f == 2)    //gobtn
            {
                if (g == 1)
                {
                    gobtn.Enabled = true;
                }
                else if (g == 0)
                {
                    gobtn.Enabled = false;
                }
            }
            else if (f == 3)    //hexlinkbtn
            {
                if (g == 1)
                {
                    hexlinkbtn.Enabled = true;
                }
                else if (g == 0)
                {
                    hexlinkbtn.Enabled = false;
                }
            }
            else if (f == 4)    //toolspresentlbl
            {
                if (g == 1)
                {
                    toolspresentlbl.Visible = true;
                }
                else if (g == 0)
                {
                    toolspresentlbl.Visible = false;
                }
            }
            else if (f == 5)    //textBox1, gobtn and hexlinkbtn
            {
                if (g == 0)
                {
                    textBox1.Enabled = false;
                    textBoxAlpha.Enabled = false;
                    gobtn.Enabled = false;
                    hexlinkbtn.Enabled = false;
                    blackpb.Enabled = false;
                    whitepb.Enabled = false;
                    transppb.Enabled = false;
                }
            }
            else if (f == 6)    //checkbtn, textBox1, gobtn, hexlinkbtn and appliedlbl
            {
                if (g == 1)
                {
                    checkbtn.Enabled = true;
                    textBox1.Enabled = true;
                    textBoxAlpha.Enabled = true;
                    gobtn.Enabled = true;
                    hexlinkbtn.Enabled = true;
                    appliedlbl.Visible = true;
                    blackpb.Enabled = true;
                    whitepb.Enabled = true;
                    transppb.Enabled = true;
                    updatechklbl.Visible = true;
                }
                else if (g == 0)
                {
                    checkbtn.Enabled = false;
                    textBox1.Enabled = false;
                    textBoxAlpha.Enabled = false;
                    gobtn.Enabled = false;
                    hexlinkbtn.Enabled = false;
                    appliedlbl.Visible = false;
                    blackpb.Enabled = false;
                    whitepb.Enabled = false;
                    transppb.Enabled = false;
                }
            }
            else if (f == 7)    //checkbtn
            {
                if (g == 1)
                {
                    checkbtn.Enabled = true;
                }
                else if(g == 0)
                {
                    checkbtn.Enabled = false;
                }
            }
            else if (f == 8)    //appliedlbl
            {
                if (g == 1)
                {
                    appliedlbl.Visible = true;
                }
                else if(g == 0)
                {
                    appliedlbl.Visible = false;
                }
            }
        }

        #region AUTOUPDATER
        
        private void CheckUpdateAvailable()
        {
            int isuptodate;
            updatechklbl.Text = "Checking for update...";

            using (WebClient wcu = new WebClient())
            {
                string uptodatefile = "http://bit.ly/isS8NavCCuptodate";
                wcu.DownloadFile(new Uri(uptodatefile), Path.GetTempPath() + "/uptodate");  //Downloads a file that either contains a '1' or a '0' that determins if program should be updated. Also contains updated version link.
            }
            string curv = File.ReadLines(Directory.GetCurrentDirectory() + "/version").Take(1).First();
            string newv = File.ReadLines(Path.GetTempPath() + "/uptodate").Skip(2).Take(1).First();
            if (curv != newv)
            {
                isuptodate = int.Parse(File.ReadLines(Path.GetTempPath() + "/uptodate").Take(1).First());
                //MessageBox.Show(isuptodate.ToString());
                if (isuptodate == 0)
                {
                    updatechklbl.Text = "Update available!";
                    DialogResult result = MessageBox.Show("Update is available! Press Yes to download and install update. (" + newv + "). Current version: (" + curv + ")", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        ShowUpdateForm();
                    }
                }
            }
            else if (curv == newv)
            {
                updatechklbl.Text = "Latest version " + GlobalVar.currentversion;
            }
        }
        private void ShowUpdateForm()
        {
            this.Enabled = false;
            updateForm form = new updateForm();
            form.Show();
        }
        #endregion

        private void mngServer(bool s)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            if (s == true) {
                p.StartInfo.FileName = "sdk/platform-tools/startserver.bat";
                p.Start();
            }
            else if (s == false)
            {
                p.StartInfo.FileName = "sdk/platform-tools/killserver.bat";
                p.Start();
            }
            //p.Kill();
            p.Dispose();
        }

        private void GenerateBats()
        {
            string chkphn = "sdk/platform-tools/chkphn.bat";
            if (!File.Exists(chkphn))
            {
                using (StreamWriter sw = new StreamWriter(chkphn))
                {
                    string command = "cd sdk/platform-tools/ & adb devices";
                    sw.WriteLine(command);
                }
            }
            string startserver = "sdk/platform-tools/startserver.bat";
            if (!File.Exists(startserver))
            {
                using (StreamWriter sw = new StreamWriter(startserver))
                {
                    string command = "cd sdk/platform-tools/ & adb start-server";
                    sw.WriteLine(command);
                }
            }
            string killserver = "sdk/platform-tools/killserver.bat";
            if (!File.Exists(killserver))
            {
                using (StreamWriter sw = new StreamWriter(killserver))
                {
                    string command = "cd sdk/platform-tools/ & adb kill-server";
                    sw.WriteLine(command);
                }
            }
        }

        ///////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            textBox2.Visible = false;   //<-Comment these out
            textBox3.Visible = false;   //<-if debugging
            label4.Visible = false;     //<-is needed

            ToggleForms(6, 0);
            checkphonelbl.Text = string.Empty;
            proglbl.Text = string.Empty;
            if(File.Exists(Directory.GetCurrentDirectory() + "/version")) { File.Delete(Directory.GetCurrentDirectory() + "/version"); }
            using (StreamWriter swv = new StreamWriter(Directory.GetCurrentDirectory() + "/version"))
            {
                swv.WriteLine(GlobalVar.currentversion);
            }

            if (!Directory.Exists("sdk/platform-tools/"))
            {
                ToggleForms(4, 0);
                DialogResult result = MessageBox.Show("Necessary tools will have to be downloaded to change your Galaxy S8's navbar color. Tools will be downloaded if you press Yes.", "Missing necessary tools", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string dllink = "https://dl.google.com/android/repository/platform-tools-latest-windows.zip";
                    WebClient wc = new WebClient();

                    wc.DownloadFileAsync(new Uri(dllink), Path.GetTempPath() + "/tools.zip");
                    proglbl.Text = "Downloading necessary tools. Download has not started yet.";
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                }
                else { this.Close(); }
            }
            else if (Directory.Exists("sdk/platform-tools/"))
            {
                GenerateBats();

                ToggleForms(4, 1);
                ToggleForms(7, 1);

                mngServer(true);
                CheckUpdateAvailable();
            }
            this.FormClosing += Form1_FormClosing;
            
            const string REGISTRY_KEY = @"HKEY_CURRENT_USER\Software\S8NavCC";
            const string REGISTY_VALUE = "FirstRun";
            if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_VALUE, 0)) == 0)
            {
                UpdateNotes un = new UpdateNotes();
                un.Show();
                Microsoft.Win32.Registry.SetValue(REGISTRY_KEY, REGISTY_VALUE, 1, Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                mngServer(false);
                Application.Exit();
            }
            catch (Exception) {
                Process[] proc = Process.GetProcessesByName("adb");
                proc[0].Kill();
                Application.ExitThread();
            }
        }

        private bool done = false;        
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.BytesReceived < e.TotalBytesToReceive)
            {
                proglbl.Text = "Downloading necessary tools. Please wait.  " + Math.Floor(((int)e.BytesReceived) * (Math.Pow(1024, -2))).ToString() + " mb out of ~" + Math.Floor(((int)e.TotalBytesToReceive) * (Math.Pow(1024, -2))).ToString() + " mb";
            }
            else if (e.BytesReceived == e.TotalBytesToReceive)
            {
                proglbl.Text = "Extracting tools... (this can take some time)";
            }
            dlprog.Maximum = (int)(e.TotalBytesToReceive / 100);
            dlprog.Value = (int)(e.BytesReceived / 100);
            if(e.BytesReceived == (int)e.TotalBytesToReceive)
            {
                done = true;
            }
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
            if (done)
            {
                bool exception = false;
                dlprog.Maximum = 100;
                dlprog.Value = 95;
                Task.Delay(100);
                try { ZipFile.ExtractToDirectory(Path.GetTempPath() + "/tools.zip", "sdk/"); }
                catch (Exception ex) { MessageBox.Show("Error extracting tools. Error code: '" + ex + "'", "", MessageBoxButtons.OK, MessageBoxIcon.Error); exception = true; }
                dlprog.Value = dlprog.Maximum;
                if (exception == false)
                {
                    ToggleForms(7, 1);
                    proglbl.Text = "Download successful. Please press 'Check'!";
                    proglbl.ForeColor = Color.Green;

                    GenerateBats();

                    CheckUpdateAvailable();
                } else if (exception)
                {
                    proglbl.Text = "Extraction of tools failed. sdk should not exist in program folder, if it's not, restart.";
                    proglbl.ForeColor = Color.Red;
                }
            }
        }


        
        char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char[] badletters = { '#', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'x', 'y', 'z', 'å', 'ä', 'ö', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'Z', 'O', 'S', 'V', 'N', 'Å', 'Ä', 'Ö' };
        private void ConvertHexToDec ()
        {
            if (textBox1.Text != "")
            {
                if (textBoxAlpha.Text == "")
                {
                    textBoxAlpha.Text = "0";
                }
                if (textBox1.Text.Length > 0)   //Below are is a series of if statements asking if textBox1 contains 'non-Hex-Color-Code' letters
                {
                    bool containsAnyLetter = textBox1.Text.IndexOfAny(letters) >= 0;
                    bool containsAnyBadletter = textBox1.Text.IndexOfAny(badletters) >= 0;
                    string hextodec = textBox1.Text;
                    int alphahexint = Convert.ToInt32(textBoxAlpha.Text);
                    string alphahex = alphahexint.ToString("X");
                    string colorcode = alphahex + hextodec;
                    if (containsAnyLetter)
                    {
                        if (!containsAnyBadletter)
                        {

                            if (textBox1.Text.Length > 6)
                            {
                                string s = textBox1.Text;
                                s = s.Substring(0, s.Length - (s.Length - 6));
                                textBox1.Text = s;
                                MessageBox.Show("Remember to ONLY use hex color values. Press 'Hex colors' to open a website with a hex color selector.", "Color value length exceeded hex color value length");
                            }
                            else
                            {
                                if (!textBox1.Text.Contains(letters.ToString()))
                                {
                                    int decValue = Convert.ToInt32(colorcode, 16);
                                    label4.Text = decValue.ToString();
                                    if (textBox1.Text.Length == 6) {
                                        gobtn.Enabled = true;
                                        Color curclr = ColorTranslator.FromHtml("#" + hextodec);
                                        currentclr.BackColor = curclr;
                                    }
                                    else { gobtn.Enabled = false; currentclr.BackColor = Color.Transparent; }
                                }
                            }
                        }
                        else
                        {
                            string s = textBox1.Text;
                            MessageBox.Show("Please only use hex color values!", "Unknown value(s) " + s[s.IndexOfAny(badletters)] + " in color code");
                        }
                    }
                    else if (!containsAnyLetter)
                    {
                        string s = textBox1.Text;
                        if (s.Length > 1 && !s.Contains(" ") && s == s.IndexOfAny(badletters).ToString())
                        {
                            MessageBox.Show("Please only use hex color values!", "Unknown value(s) " + s[s.IndexOfAny(badletters) + (s.Length - 1)] + " in color code");
                        }
                        else if (s.Length == 1 && !s.Contains(" ") && s == s.IndexOfAny(badletters).ToString())
                        {
                            MessageBox.Show("Please only use hex color values!", "Unknown value(s) " + s[s.IndexOfAny(badletters)] + " in color code");
                        }
                    }
                }
            } 
        }
        
        private void ApplyColor (string color)
        {
            appliedlbl.ForeColor = DefaultForeColor;
            ToggleForms(8, 0);
            ToggleForms(8, 1);
            appliedlbl.Text = "Applying...";

            using (StreamWriter sw = new StreamWriter("sdk/platform-tools/apc.bat"))    //Creates or updates apc.bat with chosen "color"
            {
                                  //       change color to "color" \/                                           change navigationbar current color to "color" \/
                string command = "cd sdk/platform-tools/ & adb shell settings put global navigationbar_color " + color + " & " + "adb shell settings put global navigationbar_current_color " + color;
                sw.WriteLine(command);
            }

            Process p = new Process();
            
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "sdk/platform-tools/apc.bat";
            p.Start();
            //Opens the file apc.bat without opening-/\
            //a window. Waits for apc.bat to close 
            //before proceeding-\/
            p.WaitForExit();

            appliedlbl.Text = "Your chosen navigationbar color has been applied!";
            appliedlbl.ForeColor = Color.LimeGreen;
        }

        #endregion
        //END INITIALIZING FUNCTIONS


        #region BUTTON CLICK AND OTHER EVENTS
        private void checkbtn_Click(object sender, EventArgs e)
        {
            checkphonelbl.Text = string.Empty;
            checkphonelbl.ForeColor = DefaultForeColor;
            checkphonelbl.BackColor = Color.Gray;
            checkphonelbl.Text = "Checking for device...";
            checkphonelbl.Update();     //Updates label because otherwise it wont change to "Checking for device..." >:(

            // Start the child process.
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "sdk/platform-tools/chkphn.bat";
            p.Start();
            //Opens the file chkphn.bat without opening-/\
            //a window. Then redirects the output to
            //textBox2 and textBox3-\/
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            textBox2.Text = output;
            textBox3.Text = textBox2.Lines[3];//Places textBox2's 5th line of text in textBox3.


            //If statements that ask if textBox3's text contains "device", "unauthorized" or none of the above.
            if (textBox3.Text.Contains("unauthorized") == false && textBox3.Text.Contains("device") == true)
            {
                checkphonelbl.Text = "Device found!";
                checkphonelbl.ForeColor = Color.LimeGreen;
                ToggleForms(1, 1);
            }
            else if (textBox3.Text.Contains("unauthorized") == true)
            {
                checkphonelbl.Text = "Device is connected but it is unauthorized. Press 'Help'";
                checkphonelbl.ForeColor = Color.Yellow;
                ToggleForms(5, 0);
            }
            else
            {
                checkphonelbl.Text = "Device not found. Press 'Help'";
                checkphonelbl.ForeColor = Color.Red;
                ToggleForms(5, 0);
            }
        }


        private void hexlinkbtn_Click(object sender, EventArgs e)
        {
            Process.Start("http://htmlcolorcodes.com/color-picker/");   //Hex color selector website.
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {   ///// THIS ONE DOESNT MATTER CAUSE IM STUPID /////

        }   ///// THIS ONE DOESNT MATTER CAUSE IM STUPID /////


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            ConvertHexToDec();  //Converts the hexademical color code to decimal.
        }

        private void gobtn_Click(object sender, EventArgs e)
        {
            string color = label4.Text;
            ApplyColor(color);  //Applies the decimal color stored in label4 to your device.
        }

        private void unauthorizedlbl_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAlpha_ValueChanged(object sender, EventArgs e)
        {
            if (textBoxAlpha.Text == "")
            {
                textBoxAlpha.Text = "0";
            }
            ConvertHexToDec();
        }

        private void textBoxAlpha_Leave(object sender, EventArgs e)
        {
            if (textBoxAlpha.Text == "")
            {
                textBoxAlpha.Text = "0";
            }
            ConvertHexToDec();
        }

        private void chkupdatebtn_Click(object sender, EventArgs e)
        {
            CheckUpdateAvailable();
        }

        private void helpbtn_Click(object sender, EventArgs e)
        {
            Form2 helpForm = new Form2();
            helpForm.Show();
            helpbtn.Enabled = false;
            helpForm.FormClosed += (s, args) => helpbtn.Enabled = true;
        }
        #endregion

        private void Preset(string color)
        {
            textBox1.Text = color;  //gives textBox1 the code for the selected Preset color shown below-\/
        }
        private void blackpb_Click(object sender, EventArgs e)
        {
            curslctpb.Visible = true;
            curslctpb.Top = blackpb.Location.Y - 2;
            curslctpb.Left = blackpb.Location.X - 2;
            Preset("000000");   //black

            FadeFX();
        }
        private void whitepb_Click(object sender, EventArgs e)
        {
            curslctpb.Visible = true;
            curslctpb.Top = whitepb.Location.Y - 2;
            curslctpb.Left = whitepb.Location.X - 2;
            Preset("ffffff");   //white

            FadeFX();
        }
        private void transppb_Click(object sender, EventArgs e)
        {
            curslctpb.Visible = true;
            curslctpb.Top = transppb.Location.Y - 2;
            curslctpb.Left = transppb.Location.X - 2;
            Preset("f");
            Preset("");
            label4.Text = "16777216";   //transparent / dynamic  decimal color
            gobtn.Enabled = true;

            FadeFX();
        }
        bool fadefxloop = false;
        private void FadeFX()
        {
            Thread t = new Thread(() =>
            {
                if (fadefxloop == false)
                {
                    fadefxloop = true;

                    FadeOut fade = new FadeOut();
                    for (int i = 100; i >= 0; i--)
                    {
                        Thread.Sleep(5);

                        float opacityvalue = float.Parse(i.ToString()) / 100;   //This runs the fade function
                        Image cur = fade.start(opacityvalue);                   //from FadeOut.cs and applies
                        curslctpb.Image = cur;                                  //opacity to curslctpb.Image.

                        if (i == 0) { fadefxloop = false; }
                    }
                }
            })
            { IsBackground = true };
            if (!t.IsAlive)
            {
                t.Start();
            }
        }

    }
}
