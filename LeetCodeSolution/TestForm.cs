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
            int[] num1 = new int[] { };
            int[] num2 = textBox2.Text.Split(',').Select(x => int.Parse(x)).ToArray();
            label1.Text = sol.FindMedianSortedArrays(num1, num2).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = sol.IsNumber(textBox3.Text).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Solution.LRUCache cache;

            //test 1
            //cache = new Solution.LRUCache(2);
            //cache.Put(1, 1);
            //cache.Put(2, 2);
            //cache.Get(1);
            //cache.Put(3, 3);
            //cache.Get(2);
            //cache.Put(4, 4);
            //cache.Get(1);
            //cache.Get(3);
            //cache.Get(4);

            //test 2 
            cache = new Solution.LRUCache(2);
            cache.Put(2, 1);
            cache.Put(2, 2);
            cache.Get(2);
            cache.Put(1, 1);
            cache.Put(4, 1);
            cache.Get(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Solution.Point[] points;
            string input = ",[40,-23],[9,138],[429,115],[50,-17],[-3,80],[-10,33],[5,-21],[-3,80],[-6,-65],[-18,26],[-6,-65],[5,72],[0,77],[-9,86],[10,-2],[-8,85],[21,130],[18,-6],[-18,26],[-1,-15],[10,-2],[8,69],[-4,63],[0,3],[-4,40],[-7,84],[-8,7],[30,154],[16,-5],[6,90],[18,-6],[5,77],[-4,77],[7,-13],[-1,-45],[16,-5],[-9,86],[-16,11],[-7,84],[1,76],[3,77],[10,67],[1,-37],[-10,-81],[4,-11],[-20,13],[-10,77],[6,-17],[-27,2],[-10,-81],[10,-1],[-9,1],[-8,43],[2,2],[2,-21],[3,82],[8,-1],[10,-1],[-9,1],[-12,42],[16,-5],[-5,-61],[20,-7],[9,-35],[10,6],[12,106],[5,-21],[-5,82],[6,71],[-15,34],[-10,87],[-14,-12],[12,106],[-5,82],[-46,-45],[-4,63],[16,-5],[4,1],[-3,-53],[0,-17],[9,98],[-18,26],[-9,86],[2,77],[-2,-49],[1,76],[-3,-38],[-8,7],[-17,-37],[5,72],[10,-37],[-4,-57],[-3,-53],[3,74],[-3,-11],[-8,7],[1,88],[-12,42],[1,-37],[2,77],[-6,77],[5,72],[-4,-57],[-18,-33],[-12,42],[-9,86],[2,77],[-8,77],[-3,77],[9,-42],[16,41],[-29,-37],[0,-41],[-21,18],[-27,-34],[0,77],[3,74],[-7,-69],[-21,18],[27,146],[-20,13],[21,130],[-6,-65],[14,-4],[0,3],[9,-5],[6,-29],[-2,73],[-1,-15],[1,76],[-4,77],[6,-29]";
            input = ",[0,0],[94911151,94911150],[94911152,94911151]";
            input = ",[3,1],[12,3],[3,1],[-6,-1]";
            string[] strarray = input.Split(']');
            points = new Solution.Point[strarray.Length - 1];
            for (int i = 0; i < strarray.Length - 1; i++)
            {
                string values = strarray[i].Replace('[', ' ').Trim();
                string[] items = values.Split(',');
                points[i] = new Solution.Point(int.Parse(items[1]), int.Parse(items[2]));
            }
            //points = new Solution.Point[] { new Solution.Point(0, 0), new Solution.Point(2, 2), new Solution.Point(3, 3) };

            //points = new Solution.Point[] { new Solution.Point(1, 1), new Solution.Point(2, 2), new Solution.Point(3, 3) };

            //points = new Solution.Point[] { new Solution.Point(1, 1), new Solution.Point(3, 2), new Solution.Point(5, 3) , new Solution.Point(4, 1), new Solution.Point(2, 3), new Solution.Point(1, 4) };

            points = new Solution.Point[] { new Solution.Point(3, 10), new Solution.Point(0, 2), new Solution.Point(0, 2), new Solution.Point(3, 10) };

            //points = new Solution.Point[] { new Solution.Point(1, 1), new Solution.Point(1, 1), new Solution.Point(1, 1) };
            sol.MaxPoints(points);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string result = sol.NearestPalindromic("1283");
        }
    }
}
