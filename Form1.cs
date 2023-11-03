using System;
using RtfPipe;
using System.Windows.Forms;

namespace ConvertRTF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var btn = this.htmlEditControl1.ToolStripItems.Add("Import RTF");
            btn.Padding = new Padding(3);
            btn.Click += Btn_Click;

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
            DialogResult oResult = openDialog.ShowDialog();

            if (oResult == DialogResult.OK)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                string RTFString = System.IO.File.ReadAllText(openDialog.FileName);
                var HTML = Rtf.ToHtml(RTFString);

                this.htmlEditControl1.DocumentHTML = HTML;
                Cursor.Current = currentCursor;
            }
        }
    }
}
