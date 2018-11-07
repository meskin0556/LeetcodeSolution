using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeetCodeSolution
{
    public partial class TestForm : Form
    {
        private Solution sol = new Solution();
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int[] num1 = textBox1.Text.Split(',').Select(x => int.Parse(x)).ToArray();
            int[] num1 =new int[] { };
            int[] num2 = textBox2.Text.Split(',').Select(x => int.Parse(x)).ToArray();
            label1.Text = sol.FindMedianSortedArrays(num1, num2).ToString();
        }
    }
}
