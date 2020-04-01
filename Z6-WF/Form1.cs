using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z6_WF
{
    public partial class Form1 : Form
    {

        BindingList<Number> numbers = new BindingList<Number>();
        public Form1()
        {
            InitializeComponent();
        }


        public void button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        public void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog2)sender;
            var path = dialog.FileName;
            var fileContent = File.ReadAllText(path);
            label1.Visible = true;     

            foreach (var item in fileContent.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
            {
                flowLayoutPanel1.Controls.Add(GenerateNumberTextBox(Convert.ToInt32(item)));
            }

        }

        private TextBox GenerateNumberTextBox(int Number)
        {
            return new TextBox()
            {
                Text = Number.ToString(),
                ReadOnly = true,
                Width = 25
            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                var randomNumber = rand.Next(100).ToString();
                textBox2.Text = rand.Next(100).ToString();
                flowLayoutPanel2.Controls.Add(GenerateNumberTextBox(randomNumber));
                Application.DoEvents();
            }
        }

        private Control GenerateNumberTextBox(string randomNumber)
        {
            throw new NotImplementedException();
        }

        private class OpenFileDialog2
        {
            public object FileName { get; internal set; }
        }
    }
    }

