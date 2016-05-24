using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var twclient = TeamworkProjects.Client.GetTeamworkClient(new Uri(textBox1.Text),textBox2.Text);
            var prjlist = twclient.Projects.GetAllProjectsAsync();
        }
    }
}
