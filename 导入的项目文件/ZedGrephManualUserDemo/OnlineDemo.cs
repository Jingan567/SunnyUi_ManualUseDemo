using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGrephManualUserDemo
{
    internal class OnlineDemo
    {
    }

    public partial class Form1 : Form
    {
        //定时器刷新曲线
        Timer ChartTimer;

        //时间
        int time = 30;

        //记录曲线值
        PointPairList vlist = new PointPairList();
        private ZedGraphControl myZedGraph;

        public Form1()
        {
            //初始化ZedGraph
            InitZedGraph();

            ChartTimer = new Timer()
            {
                Interval = 300,
            };
            ChartTimer.Tick += ChartTimer_Tick;
            ChartTimer.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello world!");
        }

        #region 初始化图表控件
        private void InitZedGraph()
        {
            GraphPane myPane = myZedGraph.GraphPane;
            myPane.IsAlignGrids = true;
            myPane.Title.Text = "测试速度";
            myPane.XAxis.Title.Text = "时间";
            myPane.YAxis.Title.Text = "速度";


            for (int i = 0; i < 30; i++)
            {
                double time = (double)i;
                double acceleration = 2.0;
                double velocity = acceleration * time;
                vlist.Add(time, velocity);
            }

            //生成一条红色的菱形样式曲线，将曲线和值vlist绑定
            //生成速度图例
            LineItem myCurve = myPane.AddCurve("速度", vlist, Color.Red, SymbolType.Diamond);
            //填充白色
            myCurve.Symbol.Fill = new Fill(Color.White);


            //显示X的网格线
            myPane.XAxis.MajorGrid.IsVisible = true;

            //设置Y轴刻度为红色
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;

            //隐藏Y轴对面的刻度显示
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;

            // 不显示Y轴的0刻度线
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.Color = Color.Red;

            //设置刻度范围
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.Max = 100;
            myPane.YAxis.Scale.MaxAuto = true;


            //设置chart的背景颜色
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);

            //刷新轴
            myZedGraph.AxisChange();
        }
        #endregion


        /// <summary>
        /// 刷新曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartTimer_Tick(object sender, EventArgs e)
        {
            //随机数据模拟
            Random random = new Random();
            double v = random.Next(30, 60);

            //添加新的数据
            vlist.Add(time, v);
            time += 2;

            //曲线刷新
            myZedGraph.AxisChange();
            myZedGraph.Refresh();

        }
    }

}
