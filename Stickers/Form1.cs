using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Stickers
{
    public partial class Sticker : Form
    {
        static string FilePath = "";
        static string FileName = "";
        public Sticker()
        {
            InitializeComponent();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PinnedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sticker.ActiveForm.TopMost = true;
        }

        private void UnpinnedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sticker.ActiveForm.TopMost = false;
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HandlePin();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Task.Run(() => Application.Run(new Sticker()));
        }

        private void PinToolStripItem_Click(object sender, EventArgs e)
        {
            HandlePin();
        }

        private void HandlePin()
        {
            if (Sticker.ActiveForm.TopMost)
            {
                toolStripMenuItem1.Checked = false;
                Sticker.ActiveForm.TopMost = false;
                PinToolStripItem.Checked = false;
            }
            else
            {
                toolStripMenuItem1.Checked = true;
                Sticker.ActiveForm.TopMost = true;
                PinToolStripItem.Checked = true;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilePath == "")
            {
                SaveAs();
            }
            Save();
        }
        private void SaveAs()
        {
            var SaveDialog = new SaveFileDialog();
            SaveDialog.ShowDialog();
            FileName = SaveDialog.FileName;
            FilePath = Path.GetFullPath(FileName);
            var lines = richTextBox1.Text.Split('\n');
            File.WriteAllLines(FilePath, lines);
        }

        private void Save()
        {
            var lines = richTextBox1.Text.Split('\n');
            File.WriteAllLines(FilePath, lines);
        }

    }
}
