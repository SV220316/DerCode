using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Runtime;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private bool mouseDown;
        private Point lastLocation;
        private void windowdrag(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // this app cant be maximized <a href="#">Due to none</a>
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Any Source code|*.html|*.htm|*.xml|*.js|*.java|*.php|*.css|*.cpp|*.c|*.cs|*.swift|*.py|*.pascal|*.DCD|*.DS|*.ruby|*.F#|*.Script|*.asm|*.APP|*.Sys|*.DerSys|";
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Any Source code|*.html|*.htm|*.xml|*.js|*.java|*.php|*.css|*.cpp|*.c|*.cs|*.swift|*.py|*.pascal|*.DCD|*.DS|*.ruby|*.F#|*.Script|*.asm|*.APP|*.Sys|*.DerSys|";
            saveFileDialog1.ShowDialog();
            saveFileDialog1.FileName = saveFileDialog1.FileName;
            SaveFie();
        }

        private void SaveFie()
        {
            if (saveFileDialog1.FileName == "")
            {
                saveFileDialog1.Filter = "Any Source code|*.html|*.htm|*.xml|*.js|*.java|*.php|*.css|*.cpp|*.c|*.cs|*.swift|*.py|*.pascal|*.DCD|*.DS|*.ruby|*.F#|*.Script|*.asm|*.APP|*.Sys|*.DerSys|";
                DialogResult res = saveFileDialog1.ShowDialog();
                if (res == DialogResult.Cancel)
                {
                    return;
                }
                saveFileDialog1.FileName = saveFileDialog1.FileName;
                MessageBox.Show(saveFileDialog1.FileName);
            }
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            sw.WriteLine(richTextBox1.Text);
            sw.Flush();
            sw.Close();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd1 = new PrintDocument();
            pd1.DocumentName = openFileDialog1.FileName;
            pageSetupDialog1.Document = pd1;
            pageSetupDialog1.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintDocument pd1 = new PrintDocument();
            pd1.DocumentName = openFileDialog1.FileName;
            printDialog1.Document = pd1;
            printDialog1.AllowPrintToFile = true;
            printDialog1.ShowDialog();
        }

        private void tsichg(object sender, EventArgs e)
        {
            
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFie();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select Your Folder" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    webBrowser1.Url = new Uri(fbd.SelectedPath);
            }
        }

        private void WD(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void WM(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void WU(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
