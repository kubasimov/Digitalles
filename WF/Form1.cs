using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Documents;
using System.Windows.Forms;
using Core;
using Core.Decode;
using Core.Interface;
using Core.Model;

namespace WF
{
    public partial class Form1 : Form
    {
        readonly IMyImage _image = new MyImage();
        readonly Start _start = new Start();

        const string FileName = @"F:/3.jpg";
        private readonly List<TextLine> _lines;
        private Bitmap t;
        public Form1()
        {
            InitializeComponent();
            
            var filename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(FileName), Path.GetFileName(FileName));

            _image.SetName(filename);
            _start.ReadFile(_image);
            var text = _start.Ocr();

            var page = new DecodeHocr().Decode(text);

            t = new Bitmap(_image.GetName());

            _lines = new List<TextLine>();

            using (Graphics g = Graphics.FromImage(t))
            {
                foreach (var textPage in page)
                {
                    //g.DrawRectangle(new Pen(Color.Blue, 3), textPage.X, textPage.Y, textPage.Width, textPage.Height);

                    panel1.Size=new Size(textPage.Width,textPage.Height);
                    

                    foreach (var paragraph in textPage.Paragraphs)
                    {
                        //g.DrawRectangle(new Pen(Color.Red, 3), paragraph.X, paragraph.Y, paragraph.Width, paragraph.Height);
                        
                        foreach (var line in paragraph.Lines)
                        {
                            _lines.Add(line);
                            var para = new Paragraph();

                            //g.DrawRectangle(new Pen(Color.Chartreuse, 3), line.X, line.Y, line.Width, line.Height);

                            foreach (var word in line.Words)
                            {
                                //g.DrawRectangle(new Pen(Color.DarkGreen, 3), word.X, word.Y, word.Width, word.Height);
                                Label label = new Label();
                                label.Text = word.Word;
                                
                                label.Location = new Point(word.X,word.Y);

                                //label.Size=new Size(word.Width,word.Height);
                                //label.Size = PreferredSize;
                                label.BorderStyle = BorderStyle.FixedSingle;
                                panel1.Controls.Add(label);
                                panel1.Refresh();
                                
                             
                                richTextBox1.AppendText(word.Word);
                            }
                        }

                    }
                }
            }

            numericUpDown1.Maximum = _lines.Count;

            pictureBox1.Image = t;
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            t = new Bitmap(_image.GetName());
            using (Graphics g = Graphics.FromImage(t))
            {
                g.DrawRectangle(new Pen(Color.Chartreuse, 3), _lines[(int)numericUpDown1.Value].X, _lines[(int)numericUpDown1.Value].Y,
                    _lines[(int)numericUpDown1.Value].Width, _lines[(int)numericUpDown1.Value].Height);
            }
            pictureBox1.Image = t;
        }
    }
}
