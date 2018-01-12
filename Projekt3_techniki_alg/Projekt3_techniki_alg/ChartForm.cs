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
        private int jarvisAndGraham = 0;
        public ChartForm()
        {
            InitializeComponent();
            chart1.Series[0].Name = "MetodaSortujaca";
            chart1.Series.Add("MetodaKubelkowa");
           
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].MarkerBorderWidth = 500;
            chart1.Series[0].MarkerSize = 1000;

            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].MarkerBorderWidth = 500;
            chart1.Series[1].MarkerSize = 1000;

        }

        public void RenameToJarvisAndGraham()
        {
            chart1.Series[0].Name = "Graham";
            chart1.Series[1].Name = "Jarvis";
            jarvisAndGraham = 1;
        }

        public void AddBasicMetodChart(List<int> points, List<long> values)
        {
            for (int i = 0; i < points.Count();i++)
            {
                if(jarvisAndGraham == 1 && i==0)
                {
                    continue;
                }
                Point p = new Point((int)values[i], (int)points[i]);
                chart1.Series[0].Points.Add(p.X, p.Y);
            }
            
        }

        public void AddBoxMetodChart(List<int> points, List<long> values)
        {
            for (int i = 0; i < points.Count(); i++)
            {
                if (jarvisAndGraham == 1 && i == 0)
                {
                    continue;
                }
                Point p = new Point((int)values[i], (int)points[i]);
                chart1.Series[1].Points.Add(p.X, p.Y);
            }
        }

        public void RefreshChart()
        {
            //chart1.
            chart1.ResetAutoValues();
        }
    }
}
