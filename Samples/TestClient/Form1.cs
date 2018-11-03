using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
			try
			{

				var client = new TeamworkProjects.Client(new Uri("https://tcdev.teamwork.com"), "saturn727disk");


				var stopwatch = new Stopwatch();
				stopwatch.Start();
				var project = await client.Projects.GetProject(190465, false, true, true, true);
				stopwatch.Stop();

				textBox1.Text = stopwatch.Elapsed.Minutes + "." + stopwatch.Elapsed.Seconds;
			}
			catch(Exception ex)
			{

			}

        }
    }
}
