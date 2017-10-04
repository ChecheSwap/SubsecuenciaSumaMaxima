using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Subsecsum.ROUTINES;
using System.Threading;
using System.Diagnostics;
using Subsecsum.CHARTS;

namespace Subsecsum
{
    public partial class shadow : Form
    {
        private int [] arr;

        private  int [] sums;

        private Thread thone;
        private Thread thtwo;
        private Thread ththree;
        private Thread thfour;

        private Stopwatch sw1;
        private Stopwatch sw2;
        private Stopwatch sw3;
        private Stopwatch sw4;

        private int bandera = 0;
        private int opd;

        private central mibase;

        public shadow()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        public shadow(ref int [] arr, int opd, central mibase)
        {
            InitializeComponent();
            this.label4.Text = "Numero de elementos: " + arr.Length;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.arr = arr;
            this.opd = opd;

            this.sums = new int[4];
            this.sw1 = new Stopwatch();
            this.sw2 = new Stopwatch();
            this.sw3 = new Stopwatch();
            this.sw4 = new Stopwatch();

            this.mibase = mibase;

            switch (opd)
            {
                case (1):
                    {
                        this.uno();
                        break;
                    }
                case (2):
                    {
                        this.bandera += 1;
                        this.dos();
                        break;
                    }
                case (3):
                    {
                        this.bandera += 2;
                        this.tres();
                        break;
                    }
                case (4):
                    {                        
                        this.cuatro();
                        break;
                    }
                case (5):
                    {
                        this.bandera+=4;
                        this.cinco();
                        break;

                    }
            }
        }

        private void shadow_Load(object sender, EventArgs e)
        {}

        private void checkstop()
        {
            if(this.bandera == this.opd)
            {
                if (this.calculando.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.calculando.Text = "Finalizado con exito!";
                        this.calculando.Location = new Point(this.Width / 2 - this.calculando.Width / 2, this.calculando.Location.Y);
                        this.progressBar1.Style = ProgressBarStyle.Continuous;
                        this.progressBar1.Value = 100;
                    }));
                }
                else
                {
                    this.calculando.Text = "Finalizado con exito!";
                    this.calculando.Location = new Point(this.Width / 2 - this.calculando.Width / 2, this.calculando.Location.Y);
                    this.progressBar1.Style = ProgressBarStyle.Continuous;
                    this.progressBar1.Value = 100;
                }

                if (this.bandera == 4)
                {
                    this.bandera = 50;                    
                    int mejorcaso = 1;
                    TimeSpan[] valfinals = new TimeSpan[4];
                    valfinals[0] = this.sw1.Elapsed;
                    valfinals[1] = this.sw2.Elapsed;
                    valfinals[2] = this.sw3.Elapsed;
                    valfinals[3] = this.sw4.Elapsed;

                    TimeSpan min = valfinals[0];

                    if (valfinals[1] < min)
                    {
                        min = valfinals[1];
                        mejorcaso = 2;
                    }
                    if (valfinals[2] < min)
                    {
                        mejorcaso = 3;
                        min = valfinals[2];
                    }
                    if (valfinals[3] < min)
                    {
                        mejorcaso = 4;
                        min = valfinals[3];
                    }

                    msg.ok(">>Mejor caso = "+mejorcaso.ToString()+"\n>>Tiempo = " + min.ToString());
                }
            }

        }

        private void uno()
        {           
            this.thone = new Thread(this.oneinternal) { IsBackground = true};            
            this.thone.Start();
        }

        private void oneinternal()
        {
            this.sw1.Reset();
            this.sw1.Start();
            this.sums[0] = rutinasX.xprotoOne(ref this.arr);
            this.sw1.Stop();
            this.bandera++;

            if (this.mibase.grafica.InvokeRequired)
            {
                this.mibase.Invoke(new MethodInvoker(delegate () { this.mibase.grafica.one(this.arr.Length, this.sw1.Elapsed.TotalSeconds); }));
            }
            else
            {
                this.mibase.grafica.one(this.arr.Length, this.sw1.Elapsed.TotalSeconds);
            }

            

            if (this.label1.InvokeRequired || this.calculando.InvokeRequired || this.progressBar1.InvokeRequired || this.labelsuma1.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.label1.Text = this.sw1.Elapsed.ToString();
                    this.labelsuma1.Text = "Suma:" + sums[0].ToString();
                    this.checkstop();
                }));
            }
            else
            {
                this.label1.Text = this.sw1.Elapsed.ToString();
                this.labelsuma1.Text = "Suma:" + sums[0].ToString();
                this.checkstop();
            }
        }



        private void dos()
        {            
            this.thtwo = new Thread(this.twointernal) { IsBackground = true};            
            this.thtwo.Start();

        }

        private void twointernal()
        {
            this.sw2.Reset();
            this.sw2.Start();
            this.sums[1] = rutinasX.xprotoTwo(ref this.arr);
            this.sw2.Stop();
            this.bandera++;

            if (this.mibase.grafica.InvokeRequired)
            {
                this.mibase.Invoke(new MethodInvoker(delegate () { this.mibase.grafica.two(this.arr.Length, this.sw2.Elapsed.TotalSeconds); }));
            }
            else
            {
                this.mibase.grafica.two(this.arr.Length, this.sw2.Elapsed.TotalSeconds);
            }

            if (this.label1.InvokeRequired || this.calculando.InvokeRequired || this.progressBar1.InvokeRequired || this.labelsuma2.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.label2.Text = this.sw2.Elapsed.ToString();
                    this.labelsuma2.Text = "Suma:" + sums[1].ToString();
                    this.checkstop();
                }));
            }
            else
            {
                this.label2.Text = this.sw2.Elapsed.ToString();
                this.labelsuma2.Text = "Suma:" + sums[1].ToString();
                this.checkstop();
            }
        }

        private void tres()
        {
            this.ththree = new Thread(this.threeinternal) { IsBackground = true};
            this.ththree.Start();
        }

        private void threeinternal()
        {
            this.sw3.Reset();
            this.sw3.Start();
            this.sums[2]=rutinasX.xprotoThree(ref this.arr);
            this.sw3.Stop();
            this.bandera++;

            if (this.mibase.grafica.InvokeRequired)
            {
                this.mibase.Invoke(new MethodInvoker(delegate () { this.mibase.grafica.three(this.arr.Length, this.sw3.Elapsed.TotalSeconds); }));
            }
            else
            {
                this.mibase.grafica.three(this.arr.Length, this.sw3.Elapsed.TotalSeconds);
            }

            if (this.label1.InvokeRequired || this.calculando.InvokeRequired || this.progressBar1.InvokeRequired || this.labelsuma3.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.label3.Text = this.sw3.Elapsed.ToString();
                    this.labelsuma3.Text = "Suma:" + sums[2].ToString();
                    this.checkstop();
                }));
            }
            else
            {
                this.label3.Text = this.sw3.Elapsed.ToString();
                this.labelsuma3.Text = "Suma:" + sums[2].ToString();
                this.checkstop();
            }
        }

        private void cuatro()
        {
            this.uno();
            this.dos();
            this.tres();
            this.cinco();          
        }

        private void cinco()
        {
            this.thfour = new Thread(new ThreadStart(this.cincointernal));
            this.thfour.Start();
        }

        private void cincointernal()
        {
            this.sw4.Reset();
            this.sw4.Start();
            this.sums[3] = rutinasX.xprotofour(ref this.arr);
            this.sw4.Stop();
            this.bandera++;

            if (this.mibase.grafica.InvokeRequired)
            {
                this.mibase.Invoke(new MethodInvoker(delegate () { this.mibase.grafica.four(this.arr.Length, this.sw4.Elapsed.TotalSeconds); }));
            }
            else
            {
                this.mibase.grafica.four(this.arr.Length, this.sw4.Elapsed.TotalSeconds);
            }

            if (this.lblnuevo.InvokeRequired || this.calculando.InvokeRequired || this.progressBar1.InvokeRequired || this.lblnuevosuma.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.lblnuevo.Text = this.sw4.Elapsed.ToString();
                    this.lblnuevosuma.Text = "Suma:" + sums[3].ToString();
                    this.checkstop();
                }));
            }
            else
            {
                this.lblnuevo.Text = this.sw4.Elapsed.ToString();
                this.lblnuevosuma.Text = "Suma:" + sums[3].ToString();
                this.checkstop();
            }
        }
    }
}
