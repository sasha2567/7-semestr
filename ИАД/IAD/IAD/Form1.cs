﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        int steps;
        List<PointF> data = new List<PointF>();
        List<PointF> result = new List<PointF>();
        List<PointF> upBorder;
        List<PointF> bottomBorder;
        Pen pen = new Pen(Color.Black);
        float[] Student = { 12.706f, 4.3027f, 3.1824f, 2.7764f, 2.5706f, 2.4469f, 2.3646f, 2.3060f, 2.2622f, 2.2281f, 
                            2.2010f, 2.1788f, 2.1604f, 2.1448f, 2.1314f, 2.1199f, 2.1098f, 2.1009f, 2.0930f, 2.0860f, 
                            2.0796f, 2.0739f, 2.0687f, 2.0639f, 2.0595f, 2.0555f, 2.0518f, 2.0484f, 2.0452f, 2.0423f,
                            2.0395f, 2.0369f, 2.0345f, 2.0322f, 2.0301f, 2.0281f, 2.0262f, 2.0244f, 2.0227f, 2.0211f, 
                            2.0195f, 2.0181f, 2.0167f, 2.0154f, 2.0141f, 2.0129f, 2.0117f, 2.0106f, 2.0096f, 2.0086f };
        void GenerateData()
        {
            data.Clear();
            /*Random rand = new Random();
            for (int i = 0; i < lenghtData; i++)
            {
                data.Add(new PointF(i + 1, rand.Next(-5 + i, 15 + i)));
            }*/
            data.Add(new PointF(1,0));
            data.Add(new PointF(2,-0.2f));
            data.Add(new PointF(3,0.3f));
            data.Add(new PointF(4,-0.7f));
            data.Add(new PointF(5,-1.6f));
            data.Add(new PointF(6,-0.9f));
            data.Add(new PointF(7,-0.6f));
            data.Add(new PointF(8,-1.6f));
            data.Add(new PointF(9,-0.5f));
            data.Add(new PointF(10,-1.8f));
            data.Add(new PointF(11,-1.8f));
            data.Add(new PointF(12,-0.2f));
            data.Add(new PointF(13,0.4f));
            data.Add(new PointF(14,1));
            data.Add(new PointF(15,1.5f));
            data.Add(new PointF(16,2.1f));
            data.Add(new PointF(17,3.8f));
            data.Add(new PointF(18,6.6f));
            data.Add(new PointF(19,7.2f));
            data.Add(new PointF(20,18.8f));
            data.Add(new PointF(21,16.4f));
            data.Add(new PointF(22,15.4f));
            data.Add(new PointF(23,17.3f));
            data.Add(new PointF(24,17.8f));
            data.Add(new PointF(25,19.4f));
            data.Add(new PointF(26,21.3f));
            data.Add(new PointF(27,21.1f));
            data.Add(new PointF(28,23.4f));
            data.Add(new PointF(29,25.6f));
            data.Add(new PointF(30,28.4f));
            data.Add(new PointF(31,30.3f));
            data.Add(new PointF(32,30.2f));
            data.Add(new PointF(33,36.7f));
            data.Add(new PointF(34,33));
            data.Add(new PointF(35,30.1f));
        }

        void CreateConfidenceLimits(int length)
        {
            upBorder = new List<PointF>();
            bottomBorder = new List<PointF>();
            upBorder.Clear();
            bottomBorder.Clear();
            upBorder.Add(new PointF(data[data.Count - 1].X, data[data.Count - 1].Y));
            bottomBorder.Add(new PointF(data[data.Count - 1].X, data[data.Count - 1].Y));
            for (int k = 0; k < length; k++)
            {
                float Sy, meanY;
                Sy = meanY = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    meanY += data[i].Y;
                }
                for (int i = 0; i < k; i++)
                {
                    meanY += result[i + 1].Y;
                }
                meanY /= data.Count + k + 1;

                for (int i = 0; i < data.Count; i++)
                {
                    Sy += (data[i].Y - meanY) * (data[i].Y - meanY);
                }
                for (int i = 0; i < k; i++)
                {
                    Sy += (result[i + 1].Y - meanY) * (result[i + 1].Y - meanY);
                }
                Sy /= data.Count + k + 1;

                Sy = (float)Math.Sqrt(Sy);
                upBorder.Add(new PointF(result[k + 1].X, result[k + 1].Y + Sy * Student[lenghtData - 1]));
                bottomBorder.Add(new PointF(result[k + 1].X, result[k + 1].Y - Sy * Student[lenghtData - 1]));
            }
            pen = new Pen(Color.Blue, 2);
            pen.DashStyle = DashStyle.Dash;
            graphBuilder.DrawPlot(pen, upBorder);
            graphBuilder.DrawPlot(pen, bottomBorder);
        }

        void CreateGraphicAR()
        {
            //Исходный график
            pen = new Pen(Color.Red, 2);
            graphBuilder.DrawPlot(pen, data);
            
            //Тренд
            List<PointF> trend = AutoR.GetTrend(data);
            pen = new Pen(Color.SteelBlue, 2);
            graphBuilder.DrawPlot(pen, trend);
            AutoR.GetRegression(data);
            dataDGV.Rows.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                dataDGV.Rows.Add(data[i].X, data[i].Y);
            }
            //прогноз по AR
            steps = Convert.ToInt32(stepsT.Text);
            if (steps > 0) 
            { 
                List<PointF> forecast = AutoR.Forecast(data, steps);
                result = forecast;
                CreateConfidenceLimits(steps);
                pen = new Pen(Color.Green, 2);
                graphBuilder.DrawPlot(pen, forecast);
                
                for (int i = 1; i < steps + 1; i++)
                {
                    dataDGV.Rows.Add(forecast[i].X, forecast[i].Y);
                }
            }
        }

        void CreateGraphicMA()
        {
            //Исходный график
            pen = new Pen(Color.Red, 2);
            graphBuilder.DrawPlot(pen, data);
            dataDGV.Rows.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                dataDGV.Rows.Add(data[i].X, data[i].Y);
            }
            //прогноз по MA
            steps = Convert.ToInt32(stepsT.Text);
            int q = Convert.ToInt32(qscaleNmr.Value);
            if (steps > 0)
            {
                List<PointF> forecast = MovA.Solve(data, q, steps);
                result = forecast;
                pen = new Pen(Color.Fuchsia, 2);
                graphBuilder.DrawPlot(pen, forecast);
                
                for (int i = 1; i < steps + 1; i++)
                {
                    dataDGV.Rows.Add(forecast[i].X, forecast[i].Y);
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
            GenerateData();
            GraphicsInitial(0);
            if (Model != 0)
            {
                if (Model == 1) CreateGraphicAR();
                if (Model == 2) CreateGraphicMA();
            }
            qscaleNmr.Maximum = lenghtData - 1;
        }

        private void scalexTrcBr_Scroll(object sender, EventArgs e)
        {
            GraphicsInitial(0);
            graphBuilder.scale.X = scaleXTrcBr.Value;
            scaleYTrcBr.Value = scaleXTrcBr.Value;
            graphBuilder.scale.Y = scaleYTrcBr.Value;
            scaleValX.Text = scaleXTrcBr.Value.ToString();
            scaleValY.Text = scaleYTrcBr.Value.ToString();
            if (Model != 0)
            {
                if (Model == 1) CreateGraphicAR();
                if (Model == 2) CreateGraphicMA();
            }
        }

        private void scaleyTrcBr_Scroll(object sender, EventArgs e)
        {
            GraphicsInitial(0);
            graphBuilder.scale.Y = scaleYTrcBr.Value;
            scaleXTrcBr.Value = scaleYTrcBr.Value;
            graphBuilder.scale.X = scaleXTrcBr.Value;
            scaleValX.Text = scaleXTrcBr.Value.ToString();
            scaleValY.Text = scaleYTrcBr.Value.ToString();
            if (Model != 0)
            {
                if (Model == 1) CreateGraphicAR();
                if (Model == 2) CreateGraphicMA();
            }
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
            graphBuildBtn.Enabled = true;

            dataLoadBtn.Visible = true;
            modelLbl.Visible = true;
            modelNmr.Visible = true;
            stepsL.Visible = true;
            stepsT.Visible = true;
            dataDGV.Visible = true;
            dataLbl.Visible = true;
            graphBuildBtn.Visible = true;
            Model = 1;
            modelNameLbl.Text = "Модель:Авторегрессия";
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
            graphBuildBtn.Enabled = true;

            dataLoadBtn.Visible = true;
            modelLbl.Visible = true;
            modelNmr.Visible = true;
            stepsL.Visible = true;
            stepsT.Visible = true;
            dataDGV.Visible = true;
            dataLbl.Visible = true;
            qscaleNmr.Visible = true;
            qLbl.Visible = true;
            graphBuildBtn.Visible = true;
            Model = 2;
            modelNameLbl.Text = "Модель:Скользящее среднее";
        }

        private void graphBuildBtn_Click(object sender, EventArgs e)
        {
            GraphicsInitial(0);
            if (Model == 1)
                CreateGraphicAR();
            if (Model == 2)
                CreateGraphicMA();
            
        }

        private void stepsT_TextChanged(object sender, EventArgs e)
        {
            string text = stepsT.Text;
            if (text != "")
            {
                try
                {
                    Convert.ToInt32(stepsT.Text);
                }
                catch
                {
                    MessageBox.Show("Введена не цифра");
                    stepsT.Text = "";
                }
            }
        }
    }
}
