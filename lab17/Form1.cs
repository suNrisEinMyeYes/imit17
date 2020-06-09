using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace lab17
{
    public partial class Form1 : Form
    {
        Flow flow1;
        Flow flow2;
        Flow flow3;
        int T1, T2, T3;
        int N1, N2, N3, CountOfExps;
        List<int> freqA;
        List<int> freqB;
        

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in chart1.Series)
            {
                item.Points.Clear();
            }
            
            CountOfExps = Int32.Parse(textBox5.Text, CultureInfo.InvariantCulture.NumberFormat);
            N1 = Int32.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
            T1 = Int32.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
            N2 = Int32.Parse(textBox3.Text, CultureInfo.InvariantCulture.NumberFormat);
            T2 = Int32.Parse(textBox4.Text, CultureInfo.InvariantCulture.NumberFormat);
            
            N3 = Math.Max(N1, N2);
            T3 = Math.Max(T1, T2);
            freqA = new List<int>(new int[T3]);
            freqB = new List<int>(new int[T3]);
            flow1 = new Flow((float)N1 / (float)T1);
            flow2 = new Flow((float)N2 / (float)T2);
            flow3 = new Flow((float)N1 / (float)T1 + (float)N2 / (float)T2);

            if (N1>T1 || N2>T2)
            {
                ErrorLbl.Visible = true;
            }
            else
            {
                ErrorLbl.Visible = false;
                Counter();
            }
            

            
              
        }

        

        void Counter()
        {
            for (int i = 0; i < CountOfExps; i++)
            {
                var Temp = flow1.MoveForward();
                if (flow1.GetCount() < N1 && flow1.GetTime() < T1)
                {
                    freqA[(int)flow1.GetTime()]++;
                    flow1.CountPlus();

                }

                var Temp2 = flow2.MoveForward();
                if (flow2.GetCount() < N2 && flow2.GetTime() < T2)
                {
                    freqA[(int)flow2.GetTime()]++;
                    flow2.CountPlus();
                }

                var Temp3 = flow3.MoveForward();
                if (flow3.GetCount() < N3 && flow3.GetTime() < T3)
                {
                    freqB[(int)flow3.GetTime()]++;
                    flow3.CountPlus();
                }
            }
            for (int i = 0; i < freqA.Count; i++)
            {
                chart1.Series[0].Points.AddXY(i, (float)freqA[i] / (float)T3);
                chart1.Series[1].Points.AddXY(i, (float)freqB[i] / (float)T3);
            }

        }
    }
}
