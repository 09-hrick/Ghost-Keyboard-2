using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ghost_Keyboard_2
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cts;
        private Task sendKeysTask;
        int defaultFontSize = 12;
        float currentFontSize = 12;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();

            string[] sk = richTextBox1.Text.Split('\n');
            try
            {
                int n = Convert.ToInt32(numericUpDown1.Value);
                for (int i = n; i >= 0; i--)
                {
                    if (cts.IsCancellationRequested)
                    {
                        label1.Text = "Terminated";
                        return;
                    }

                    int remainingTime = i;
                    label1.Text = "Initiating writing in: \n" + remainingTime.ToString() + " seconds";
                    await Task.Delay(1000, cts.Token);
                }

                label1.Text = "Writing...";
                sendKeysTask = Task.Run(() => SendKeysFunction(sk), cts.Token);
                await sendKeysTask;
                label1.Text = "Done!";
            }
            catch (OperationCanceledException)
            {
                label1.Text = "Terminated";
            }
        }

        private void SendKeysFunction(string[] sk)
        {
            int n = Convert.ToInt32(numericUpDown1.Value);
            int iterations = 0;
            foreach (string nn in sk)
            {
                if (cts.IsCancellationRequested)
                {
                    return;
                }

                iterations++;
                foreach (char t in nn)
                {
                    string x = "" + t;
                    if (t == '!' || t == '@' || t == '#' || t == '$' || t == '%' || t == '^' || t == '&' || t == '*' || t == '(' || t == ')' || t == '_' || t == '+' || t == '-' || t == '=' || t == '{' || t == '}' || t == '[' || t == ']' || t == '\\' || t == '|' || t == ';' || t == ':' || t == '"' || t == '\'' || t == ',' || t == '.' || t == '/' || t == '?')
                    {
                        x = "{" + x + "}";
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        SendKeys.Send(x);
                    });
                    Thread.Sleep(10);

                    if (cts.IsCancellationRequested)
                    {
                        return;
                    }
                }

                if (iterations != sk.Length)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        SendKeys.Send("{Enter}");
                    });
                    Thread.Sleep(10);

                    if (cts.IsCancellationRequested)
                    {
                        return;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Terminated";
            cts?.Cancel();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog1.Title = "Save file";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        return;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            richTextBox1.Clear();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                undoToolStripMenuItem.Enabled = true;
                undoToolStripMenuItem.ForeColor = Color.Black; // set the color to black when enabled
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.ForeColor = SystemColors.GrayText; // set the color to gray when disabled
            }
            if (richTextBox1.CanRedo)
            {
                redoToolStripMenuItem.Enabled = true;
                redoToolStripMenuItem.ForeColor = Color.Black;
            }
            else
            {
                redoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.ForeColor = SystemColors.GrayText;
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog1.Title = "Save file";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        return;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            this.Close();
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (currentFontSize < defaultFontSize +1 )
            //{
                currentFontSize++;
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, currentFontSize);
            //}
        }

        private void restoreDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentFontSize = defaultFontSize;
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, currentFontSize);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFontSize > defaultFontSize - 1)
            {
                currentFontSize--;
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, currentFontSize);
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanRedo) { richTextBox1.Redo(); };
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(fileName);
                    richTextBox1.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
