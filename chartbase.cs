using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Subsecsum.CHARTS
{
    public partial class chartbase : Form
    {
        private Series s1,s2,s3,s4;
        private int[] count;
        public chartbase()
        {
            InitializeComponent();
            this.generar();            
            this.label2.Text = "T\ni\ne\nm\np\no\n\nT";
            //this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Text = "Resultados";
            this.MaximizeBox = false;
            this.FormClosing += (s, a) => { msg.danger("Is a listener Process!"); a.Cancel = true; };

            this.lblnota.Text = "Nota... Tiempo 'T' expresado en segundos.";
            this.count = new int[4];
        }

        private void chartbase_Load(object sender, EventArgs e)
        {}

        private void generar()
        {            
            this.chart.Series.Clear();
            this.s1 = this.chart.Series.Add("Algoritmo 1");
            this.s1.ChartType = SeriesChartType.Line;
            this.s1.Points.AddXY(0, 0);

            this.s2 = this.chart.Series.Add("Algoritmo 2");
            this.s2.ChartType = SeriesChartType.Line;
            this.s2.Points.AddXY(0, 0);

            this.s3 = this.chart.Series.Add("Algoritmo 3");
            this.s3.ChartType = SeriesChartType.Line;
            this.s3.Points.AddXY(0, 0);

            this.s4 = this.chart.Series.Add("Algoritmo 4");
            this.s4.ChartType = SeriesChartType.Line;
            this.s4.Points.AddXY(0, 0);

        }

        public void one(double x, double y)
        {
            this.s1.Points.AddXY(x, y);
            ++this.count[0];
            this.rtb.Text += "Serie 1("+x.ToString()+","+y.ToString()+")\n>>>"+count[0].ToString()+"\n";          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart.Series.Clear();
            this.rtb.Clear();
            this.count = new int[4];
            this.generar();
        }

        public void two(double x, double y)
        {
            this.s2.Points.AddXY(x, y);
            ++this.count[1];
            this.rtb.Text += "Serie 2(" + x.ToString() + "," + y.ToString() + ")\n>>>" + count[1].ToString()+"\n";
        }

        public void three(double x, double y)
        {
            this.s3.Points.AddXY(x, y);
            ++this.count[2];
            this.rtb.Text += "Serie 3(" + x.ToString() + "," + y.ToString() + ")\n>>>" + count[2].ToString()+"\n";
        }
        public void four(double x, double y)
        {
            this.s4.Points.AddXY(x, y);
            ++this.count[3];
            this.rtb.Text += "Serie 4(" + x.ToString() + "," + y.ToString() + ")\n>>>" + count[3].ToString()+"\n";
        }

    }
}
