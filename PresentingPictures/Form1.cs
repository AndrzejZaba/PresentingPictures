using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace PresentingPictures
{
    public partial class Form1 : Form
    {
        //private OpenFileDialog openFileDialog;
        public string SelectedImagePath { get; set; }
        public bool IsImageVisible { get; set; }
        private readonly string textFilePath = "..\\..\\SavedImagePath.txt";

        public Form1()
        {
            InitializeComponent();
            IsImageVisible = false;
            try
            {
                SelectedImagePath = File.ReadAllText(textFilePath);
            }
            catch (Exception)
            {
                SelectedImagePath = "";
            }

            if (string.IsNullOrEmpty(SelectedImagePath))
                IsImageVisible = false;
            else
                IsImageVisible = true;

            RefreshWindow();
        }

        private void btnSelectPicture_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void RefreshWindow()
        {
            pictureBox1.ImageLocation = SelectedImagePath;
            btnClearPicture.Enabled = IsImageVisible;
        }


        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                SelectedImagePath = openFileDialog.FileName;
                File.WriteAllText(textFilePath, SelectedImagePath);
                IsImageVisible = true;
            }
            RefreshWindow();
        }

        private void btnClearPicture_Click(object sender, EventArgs e)
        {
            SelectedImagePath = "";
            File.WriteAllText(textFilePath, SelectedImagePath);
            IsImageVisible = false;
            RefreshWindow();
        }
    }
}
