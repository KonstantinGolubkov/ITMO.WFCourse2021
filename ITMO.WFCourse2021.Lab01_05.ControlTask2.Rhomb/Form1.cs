using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.WFCourse2021.Lab01_05.ControlTask2.Rhomb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddLines(new[]
                                    {
                                        new Point(0, Height / 2),
                                        new Point(Width / 2, 0),
                                        new Point(Width, Height / 2),
                                        new Point(Width / 2, Height)
                                    }
                            );
            //myPath.AddEllipse(0, 0, this.Width, this.Height);
            //myPath.AddPolygon(new Point[] { new Point(0, 0), new Point(0, this.Height), new Point(this.Width, 0) });
            Region myRegion = new Region(myPath);
            this.Region = myRegion;

        }
    }
}
