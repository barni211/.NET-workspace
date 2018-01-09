using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt3_techniki_alg
{
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
            chart1.Series.Add("MetodaSortujaca");
            chart1.Series.Add("MetodaKubelkowa");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].MarkerBorderWidth = 500;
            chart1.Series[1].MarkerSize = 1000;

            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[2].MarkerBorderWidth = 500;
            chart1.Series[2].MarkerSize = 1000;

           


        }

        public void AddBasicMetodChart(List<int> points, List<long> values)
        {
            for (int i = 0; i < points.Count();i++)
            {
                Point p = new Point((int)values[i], (int)points[i]);
                chart1.Series[1].Points.Add(p.X, p.Y);
            }
            
        }

        public void AddBoxMetodChart(List<int> points, List<long> values)
        {
            for (int i = 0; i < points.Count(); i++)
            {
                Point p = new Point((int)values[i], (int)points[i]);
                chart1.Series[2].Points.Add(p.X, p.Y);
            }
        }

        public void RefreshChart()
        {
            //chart1.
            chart1.ResetAutoValues();
        }
    }
}
