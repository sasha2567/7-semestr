using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace IAD
{
    public partial class IAD : Form
    {
        GraphBuilder graphBuilder;
        AR AutoR = new AR();
        MA MovA = new MA();
        int Model = 0;
        int lenghtData = 35;
        Pen pen = new Pen(Color.Black);

        void CreateGraphicAR()
        {
            //Исходный график
            float[] tempy = new float[lenghtData];
            float[] tempx = new float[lenghtData];
            Random rand = new Random();
            for (int i = 0; i < tempy.Length; i++)
            {
                tempy[i] = rand.Next(-5, 15);
            }
            for (int i = 0; i < tempx.Length; i++)
            {
                tempx[i] = i + 1;
            }
            pen = new Pen(Color.Red, 2);
            graphBuilder.DrawPlot(pen, tempx, tempy);
            
            //Тренд
            float[] temp = AutoR.GetTrend(tempx, tempy);
            pen = new Pen(Color.SteelBlue, 2);
            graphBuilder.DrawPlot(pen, tempx, temp);
            AutoR.GetRegression(tempx, tempy);
            
            //прогноз по AR
            int steps = Convert.ToInt32(stepsT.Text);
            float[] tmp = AutoR.Forecast(tempx, tempy, steps);

            float[] tmpx = new float[steps + 1];
            float[] tmpy = new float[steps + 1];
            float step = 0;
            for (int i = 1; i < tempx.Length; i++)
                step += tempx[i] - tempx[i - 1];
            step /= (tempx.Length - 1);
            tmpx[0] = tempx[tempx.Length - 1];
            tmpy[0] = tempy[tempy.Length - 1];
            for (int i = 1; i < tmpx.Length; i++)
            {
                tmpx[i] = tmpx[i - 1] + step;
                tmpy[i] = tmp[tempy.Length + i - 1];
            }
            pen = new Pen(Color.Green, 2);
            graphBuilder.DrawPlot(pen, tmpx, tmpy);
            dataDGV.Rows.Clear();
            for (int i = 0; i < tempx.Length + steps + 1; i++)
            {
                if (i < tempx.Length)
                {
                    dataDGV.Rows.Add(tempx[i], tempy[i]);
                }
                else
                {
                    dataDGV.Rows.Add(tmpx[i - tempx.Length], tmpy[i - tempx.Length]);
                }
            }
        }

        void CreateGraphicMA()
        {
            //Исходный график
            float[] tempy = new float[lenghtData];
            float[] tempx = new float[lenghtData];
            Random rand = new Random();
            for (int i = 0; i < tempy.Length; i++)
            {
                tempy[i] = rand.Next(-5, 15);
            }
            for (int i = 0; i < tempx.Length; i++)
            {
                tempx[i] = i + 1;
            }
            pen = new Pen(Color.Red, 2);
            graphBuilder.DrawPlot(pen, tempx, tempy);
            
            //прогноз по MA
            int steps = Convert.ToInt32(stepsT.Text);
            int q = Convert.ToInt32(qscaleNmr.Value);
            float[] resy = MovA.Solve(tempy,q,steps);

            float[] tmpx = new float[steps + 1];
            float[] tmpy = new float[steps + 1];
            float step = 0;
            for (int i = 1; i < tempx.Length; i++)
                step += tempx[i] - tempx[i - 1];
            step /= (tempx.Length - 1);
            tmpx[0] = tempx[tempx.Length - 1];
            tmpy[0] = tempy[tempy.Length - 1];
            for (int i = 1; i <= steps; i++)
            {
                tmpx[i] = tmpx[i - 1] + step;
                tmpy[i] = resy[i - 1];
            }
            pen = new Pen(Color.Fuchsia, 2);
            graphBuilder.DrawPlot(pen, tmpx, tmpy);
            dataDGV.Rows.Clear();
            for (int i = 0; i < tempx.Length + steps + 1; i++)
            {
                if (i < tempx.Length)
                {
                    dataDGV.Rows.Add(tempx[i], tempy[i]);
                }
                else
                {
                    dataDGV.Rows.Add(tmpx[i - tempx.Length], tmpy[i - tempx.Length]);
                }
            }
        }

        void GraphicsInitial(int flag)
        {
            if (flag == 0)
            {
                graphBuilder.SetGraphics(scene, graphBuilder.center);
            }
            else
            {
                graphBuilder.SetGraphics(scene, new Point(
                -XScrBr.Value * scaleXTrcBr.Value + scene.Width / 2,
                -YScrBr.Value * scaleYTrcBr.Value + scene.Height / 2));
            }
            graphBuilder.DrawGrid(new Pen(Color.LightGray));
        }
        
        public IAD()
        {
            InitializeComponent();
            graphBuilder = new GraphBuilder(scene, new Point(scene.Width / 2, scene.Height / 2), new Point(5, 5));
            GraphicsInitial(0);
            scaleXTrcBr.Value = 5;
            scaleYTrcBr.Value = 5;
            qscaleNmr.Maximum = lenghtData - 1;
            scaleValX.Text = scaleXTrcBr.Value.ToString();
            scaleValY.Text = scaleYTrcBr.Value.ToString();
        }

        private void dataLoadBtn_Click(object sender, EventArgs e)
        {
            GraphicsInitial(0);
            if (Model == 1)
                CreateGraphicAR();
            if (Model == 2)
                CreateGraphicMA();
        }

        private void scalexTrcBr_Scroll(object sender, EventArgs e)
        {
            graphBuilder.scale.X = scaleXTrcBr.Value;
            scaleYTrcBr.Value = scaleXTrcBr.Value;
            graphBuilder.scale.Y = scaleYTrcBr.Value;
            scaleValX.Text = scaleXTrcBr.Value.ToString();
            scaleValY.Text = scaleYTrcBr.Value.ToString();
            GraphicsInitial(0);
            CreateGraphicAR();
        }

        private void scaleyTrcBr_Scroll(object sender, EventArgs e)
        {
            graphBuilder.scale.Y = scaleYTrcBr.Value;
            scaleXTrcBr.Value = scaleYTrcBr.Value;
            graphBuilder.scale.X = scaleXTrcBr.Value;
            scaleValX.Text = scaleXTrcBr.Value.ToString();
            scaleValY.Text = scaleYTrcBr.Value.ToString();
            GraphicsInitial(0);
            CreateGraphicAR();
        }

        private void gridBtn_Click(object sender, EventArgs e)
        {
            GraphicsInitial(0);
        }

        private void модельАвторегрессииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataLoadBtn.Enabled = true;
            modelLbl.Enabled = true;
            modelNmr.Enabled = true;
            stepsL.Enabled = true;
            stepsT.Enabled = true;
            dataDGV.Enabled = true;
            dataLbl.Enabled = true;

            dataLoadBtn.Visible = true;
            modelLbl.Visible = true;
            modelNmr.Visible = true;
            stepsL.Visible = true;
            stepsT.Visible = true;
            dataDGV.Visible = true;
            dataLbl.Visible = true;
            Model = 1;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            GraphicsInitial(1);
            if (Model == 1)
                CreateGraphicAR();
            if (Model == 2)
                CreateGraphicMA();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            GraphicsInitial(1);
            if (Model == 1)
                CreateGraphicAR();
            if (Model == 2)
                CreateGraphicMA();
        }

        private void модельСкользящегоСреднегоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataLoadBtn.Enabled = true;
            modelLbl.Enabled = true;
            modelNmr.Enabled = true;
            stepsL.Enabled = true;
            stepsT.Enabled = true;
            dataDGV.Enabled = true;
            dataLbl.Enabled = true;
            qscaleNmr.Enabled = true;
            qLbl.Enabled = true;

            dataLoadBtn.Visible = true;
            modelLbl.Visible = true;
            modelNmr.Visible = true;
            stepsL.Visible = true;
            stepsT.Visible = true;
            dataDGV.Visible = true;
            dataLbl.Visible = true;
            qscaleNmr.Visible = true;
            qLbl.Visible = true;
            Model = 2;
        }
    }
}
