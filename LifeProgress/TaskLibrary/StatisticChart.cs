using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Model2;
using Manager;

namespace TaskLibrary
{
    public partial class StatisticChart : UserControl
    {
        const string SERIE_NAME = "Progress";

        ModelEntities _model;

        public StatisticChart()
        {
            InitializeComponent();
        }

        private void StatisticChart_Load(object sender, EventArgs e)
        {
            initChart();
            initDropDownList();            
            //fillChart();
        }

        public void setModel(ModelEntities model)
        {
            _model = model;
        }

        private void fillChart()
        {
            if (_model == null)
            {
                LogManager.Instance.logEvent("Statistic chart is not initialized!");
                return;
            }

            chartMain.Series[SERIE_NAME].Points.Clear();
            int length = ((ListItem)ddlPeriod.SelectedItem).Value;
            Week cur = WeekWorker.getCurrentWeek(_model);

            for (int i = 0; i < length; i++)
            {
                chartMain.Series[SERIE_NAME].Points.AddXY(cur.Number, cur.getProgress());
                cur = WeekWorker.getPrevCalendarWeek(cur, _model);
            }

            chartMain.Series[SERIE_NAME].Points.Reverse();
        }

        private void initChart()
        {
            chartMain.Series.Add (SERIE_NAME);
            chartMain.Series[SERIE_NAME].ChartType = SeriesChartType.Column;
            chartMain.Series[SERIE_NAME].IsXValueIndexed = true;
            chartMain.Series[SERIE_NAME].XAxisType = AxisType.Primary;
            chartMain.Series[SERIE_NAME].XValueType = ChartValueType.Auto;
            chartMain.Series[SERIE_NAME].YValuesPerPoint = 2;
            chartMain.Series[SERIE_NAME].YValueType = ChartValueType.Auto;
            chartMain.Series[SERIE_NAME].SmartLabelStyle.Enabled = true;
            chartMain.Series[SERIE_NAME].IsValueShownAsLabel = true;
            //chartMain.Series[SERIE_NAME].SmartLabelStyle.
        }

        private void initDropDownList()
        {
            ddlPeriod.Items.Clear();
            ddlPeriod.Items.Add(new ListItem(13, "Последние 3 месяца"));
            ddlPeriod.Items.Add(new ListItem(26, "Последние полгода"));
            ddlPeriod.Items.Add(new ListItem(52, "Последний год"));

            ddlPeriod.SelectedIndex = 0;
        }

        private void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPeriod.SelectedIndex >= 0)
                fillChart();
        }
    }
}
