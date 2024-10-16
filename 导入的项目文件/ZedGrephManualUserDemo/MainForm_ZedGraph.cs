using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGrephManualUserDemo
{
    public partial class MainForm_ZedGraph : Form
    {
        public MainForm_ZedGraph()
        {
            InitializeComponent();
            //DrawScatterPlot();
        }

        private void DrawScatterPlot()
        {
            // 创建 ZedGraphControl
            ZedGraphControl zedGraphControl = new ZedGraphControl();
            zedGraphControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(zedGraphControl);

            GraphPane pane = zedGraphControl.GraphPane;

            // 设置图表标题
            pane.Title.Text = "Scatter Plot Example";

            // 设置 X 轴和 Y 轴标题
            pane.XAxis.Title.Text = "X Axis";
            pane.YAxis.Title.Text = "Y Axis";

            // 模拟散点数据
            double[] xValues = { 1.2, 2.5, 3.7, 4.1, 5.3 };
            double[] yValues = { 2.1, 3.4, 4.6, 5.2, 6.8 };

            // 创建散点图
            PointPairList points = new PointPairList(xValues, yValues);
            //var scatter = pane.AddCurve("你好",points, Color.Blue, SymbolType.Circle);
            //var scatter = pane.AddScatter("你好",points, Color.Blue, SymbolType.Circle);
            //var scatter = pane.AddStick("你好", points, Color.Blue);
            //var scatter = pane.AddBar("你好", points, Color.Blue);
            //var scatter = pane.AddBar("你好", points, Color.Blue);
            //var scatter = pane.AddPointList("你好", points, Color.Blue);

            //// 创建曲线对象，但不设置线条，只设置标记
            //LineItem scatterLine = pane.AddCurve("", points, Color.Blue, SymbolType.Circle);
            //scatterLine.Line.IsVisible = false; // 隐藏线条



            // 创建 CurveList
            CurveList curves = pane.CurveList;

            // 创建散点曲线
            //PointPairList points = new PointPairList(xValues, yValues);
            LineItem scatterCurve = new LineItem("Scatter", points, Color.Blue, SymbolType.Circle);
            scatterCurve.Line.IsVisible = false; // 隐藏线条

            // 将散点曲线添加到 CurveList
            curves.Add(scatterCurve);



            // 更新图表
            zedGraphControl.AxisChange();
        }

        private void DrawBoxPlot()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.Title.Text = "箱线图示例";
            pane.XAxis.Title.Text = "数据类别";
            pane.YAxis.Title.Text = "数值";

            double[] values = { 5, 6, 7, 7, 8, 2, 4, 3, 4, 5, 5, };

            BoxObj boxObj = new BoxObj();//这个方法是有问题的
        }
    }
}
