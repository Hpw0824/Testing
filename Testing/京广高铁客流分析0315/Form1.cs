using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using PublicClassLib;
using System.IO;

namespace 京广高铁客流分析0315
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        List<SectionFlow> SecFlowList = new List<SectionFlow>();
        List<PassengerFlow> PassFlowList = new List<PassengerFlow>();
        List<StationInfo> StaList = new List<StationInfo>();

        //指定单元格，读取数据，两种方法
        //之二： 
        string[] a = { "北京西", "涿州东", "高碑店东", "保定东", "定州东", "石家庄机场", "新石家庄", "高邑西", "邢台东", "邯郸东", "安阳东", "鹤壁东", "新乡东", "郑州东", "许昌东", "漯河西", "驻马店西", "明港东", "信阳东", "孝感北", "武汉", "咸宁北", "赤壁北", "岳阳东", "汨罗东", "长沙南", "株洲西", "衡山西", "衡阳东", "耒阳西", "郴州西", "韶关", "英德西", "清远", "广州北", "广州南" };
        string[] b = { "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00", "24:00" };

        private void 区段客流_Click(object sender, EventArgs e)//填充SecFlowList
        {
            for (int m = 0; m < a.Length; m++)
            {
                for (int n = 0; n < a.Length; n++)
                {
                    if (n == m)
                    {
                        continue;
                    }
                    else
                    for (int p = 0; p < b.Length-1; p++)
                    {
                            SectionFlow Section = new SectionFlow();
                            foreach (StationInfo sta3 in StaList)
                            {
                                if (sta3.Station == a[m])
                                {
                                    Section.StartStation = sta3;
                                }
                            }
                            //Section.StartStation = a[m];
                            foreach (StationInfo sta4 in StaList)
                            {
                                if (sta4.Station == a[m])
                                {
                                    Section.StartStation = sta4;
                                }
                            }
                            //Section.EndStation = a[n];
                            Section.StartTime = b[p];
                            Section.EndTime = b[p+1];
                            Section.Num = 0;
                            SecFlowList.Add(Section);
                    }
                }
            }         
        }

        private void 旅客OD客流_Click(object sender, EventArgs e)//填充PassFlowList
        {
            //  PassFlowList.Clear();

            Excel.Application excel = new Excel.Application(); //引用Excel对象   
            Excel.Workbook book = excel.Application.Workbooks.Add(@"C:\Documents and Settings\童佳楠\桌面\汇总.xlsx");   //引用Excel工作簿   
            excel.Visible = true; //使Excel可视

            //指定要操作的Sheet，两种方式
            //之一：
            Excel.Worksheet xlsSheet = (Excel.Worksheet)book.Sheets[1];

            StreamWriter sw = Log.OpenFile(@"C:\Documents and Settings\童佳楠\桌面\汇总（终版）");
            if (sw == null)
                return;

            sw.Write("车次编号\t车次\t停站\t到达时刻\t到达编号\t运行时间\t发车时刻\t发车编号\t停站时间");
            sw.Write("\n");

            string a1, a2, a3, a4, a5, a6, a12;
            int b = 0;

            for (int i = 2; i <= 942; i=i+b)//1.外循环：总表行循环
            {
                if (i >= 3)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        Excel.Range d1 = (Excel.Range)xlsSheet.Cells[i, 1];
                        Excel.Range d12 = (Excel.Range)xlsSheet.Cells[i + j, 1];

                        if (d1.Value2 == null)
                            break;
                        else
                        {
                            a1 = d1.Value2.ToString();
                        }

                        if (d12.Value2 == null)
                            break;
                        else
                        {
                            a12 = d12.Value2.ToString();
                        }

                        if (a12 == a1)
                            continue;
                        else
                        {
                            b = j;
                            break;
                        }
                    }


                    for (int k = 1; k <= b; k++)
                    {
                        if (b == 1)
                        {
                            Excel.Range d1 = (Excel.Range)xlsSheet.Cells[i+k-1, 1];
                            Excel.Range d2 = (Excel.Range)xlsSheet.Cells[i + k - 1, 2];
                            Excel.Range d3 = (Excel.Range)xlsSheet.Cells[i + k - 1, 3];
                            Excel.Range d4 = (Excel.Range)xlsSheet.Cells[i + k - 1, 4];
                            Excel.Range d5 = (Excel.Range)xlsSheet.Cells[i + k - 1, 5];
                            Excel.Range d6 = (Excel.Range)xlsSheet.Cells[i + k - 1, 6];

                            if (d1.Value2 == null)
                                break;
                            else
                            {
                                a1 = d1.Value2.ToString();
                            }

                            if (d2.Value2 == null)
                                break;
                            else
                            {
                                a2 = d2.Value2.ToString();
                            }

                            if (d3.Value2 == null)
                                break;
                            else
                            {
                                a3 = d3.Value2.ToString();
                            }

                            if (d4.Value2 == null)
                                break;
                            else
                            {
                                a4 = d4.Value2.ToString();
                            }

                            if (d5.Value2 == null)
                            {
                                break;
                            }
                            else
                                a5 = d5.Value2.ToString();

                            if (d6.Value2 == null)
                            {
                                break;
                            }
                            else
                                a6 = d6.Value2.ToString();

                            sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\n", null, a1, a2, null, null, null, a3, 2*k-1, null);

                            sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\n", null, a1, a4, a5, 2*k, a6, null, null, null);
                        }
                        else if (k == 1)
                        {
                            Excel.Range d1 = (Excel.Range)xlsSheet.Cells[i + k - 1, 1];
                            Excel.Range d2 = (Excel.Range)xlsSheet.Cells[i + k - 1, 2];
                            Excel.Range d3 = (Excel.Range)xlsSheet.Cells[i + k - 1, 3];
                            Excel.Range d4 = (Excel.Range)xlsSheet.Cells[i + k - 1, 4];
                            Excel.Range d5 = (Excel.Range)xlsSheet.Cells[i + k - 1, 5];
                            Excel.Range d6 = (Excel.Range)xlsSheet.Cells[i + k - 1, 6];

                            if (d1.Value2 == null)
                                break;
                            else
                            {
                                a1 = d1.Value2.ToString();
                            }

                            if (d2.Value2 == null)
                                break;
                            else
                            {
                                a2 = d2.Value2.ToString();
                            }

                            if (d3.Value2 == null)
                                break;
                            else
                            {
                                a3 = d3.Value2.ToString();
                            }

                            if (d4.Value2 == null)
                                break;
                            else
                            {
                                a4 = d4.Value2.ToString();
                            }

                            if (d5.Value2 == null)
                            {
                                break;
                            }
                            else
                                a5 = d5.Value2.ToString();

                            if (d6.Value2 == null)
                            {
                                break;
                            }
                            else
                                a6 = d6.Value2.ToString();

                            sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\n", null, a1, a2, null, null, null, a3, 2*k-1, null);

                            sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t", null, a1, a4, a5, 2*k, a6);
                        }
                        else if (k == b)
                        {
                            Excel.Range d1 = (Excel.Range)xlsSheet.Cells[i + k - 1, 1];
                            Excel.Range d2 = (Excel.Range)xlsSheet.Cells[i + k - 1, 2];
                            Excel.Range d3 = (Excel.Range)xlsSheet.Cells[i + k - 1, 3];
                            Excel.Range d4 = (Excel.Range)xlsSheet.Cells[i + k - 1, 4];
                            Excel.Range d5 = (Excel.Range)xlsSheet.Cells[i + k - 1, 5];
                            Excel.Range d6 = (Excel.Range)xlsSheet.Cells[i + k - 1, 6];

                            if (d1.Value2 == null)
                                break;
                            else
                            {
                                a1 = d1.Value2.ToString();
                            }

                            if (d2.Value2 == null)
                                break;
                            else
                            {
                                a2 = d2.Value2.ToString();
                            }

                            if (d3.Value2 == null)
                                break;
                            else
                            {
                                a3 = d3.Value2.ToString();
                            }

                            if (d4.Value2 == null)
                                break;
                            else
                            {
                                a4 = d4.Value2.ToString();
                            }

                            if (d5.Value2 == null)
                            {
                                break;
                            }
                            else
                                a5 = d5.Value2.ToString();

                            if (d6.Value2 == null)
                            {
                                break;
                            }
                            else
                                a6 = d6.Value2.ToString();

                            sw.Write("{0}\t{1}\t{2}\n", a3, 2*k-1, null);

                            sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\n", null, a1, a4, a5, 2*k, a6, null, null, null);
                        }
                        else
                        {
                            Excel.Range d1 = (Excel.Range)xlsSheet.Cells[i + k - 1, 1];
                            Excel.Range d2 = (Excel.Range)xlsSheet.Cells[i + k - 1, 2];
                            Excel.Range d3 = (Excel.Range)xlsSheet.Cells[i + k - 1, 3];
                            Excel.Range d4 = (Excel.Range)xlsSheet.Cells[i + k - 1, 4];
                            Excel.Range d5 = (Excel.Range)xlsSheet.Cells[i + k - 1, 5];
                            Excel.Range d6 = (Excel.Range)xlsSheet.Cells[i + k - 1, 6];

                            if (d1.Value2 == null)
                                break;
                            else
                            {
                                a1 = d1.Value2.ToString();
                            }

                            if (d2.Value2 == null)
                                break;
                            else
                            {
                                a2 = d2.Value2.ToString();
                            }

                            if (d3.Value2 == null)
                                break;
                            else
                            {
                                a3 = d3.Value2.ToString();
                            }

                            if (d4.Value2 == null)
                                break;
                            else
                            {
                                a4 = d4.Value2.ToString();
                            }

                            if (d5.Value2 == null)
                            {
                                break;
                            }
                            else
                                a5 = d5.Value2.ToString();

                            if (d6.Value2 == null)
                            {
                                break;
                            }
                            else
                                a6 = d6.Value2.ToString();

                            sw.Write("{0}\t{1}\t{2}\n", a3, 2*k-1, null);

                            sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t", null, a1, a4, a5, 2*k,a6);
                        }
                    }
                }
                else
                {
                    b = 2;
                    Excel.Range d1 = (Excel.Range)xlsSheet.Cells[i, 1];
                    Excel.Range d2 = (Excel.Range)xlsSheet.Cells[i, 2];
                    Excel.Range d3 = (Excel.Range)xlsSheet.Cells[i, 3];
                    Excel.Range d4 = (Excel.Range)xlsSheet.Cells[i, 4];
                    Excel.Range d5 = (Excel.Range)xlsSheet.Cells[i, 5];
                    Excel.Range d6 = (Excel.Range)xlsSheet.Cells[i, 6];

                    if (d1.Value2 == null)
                        break;
                    else
                    {
                        a1 = d1.Value2.ToString();
                    }

                    if (d2.Value2 == null)
                        break;
                    else
                    {
                        a2 = d2.Value2.ToString();
                    }

                    if (d3.Value2 == null)
                        break;
                    else
                    {
                        a3 = d3.Value2.ToString();
                    }

                    if (d4.Value2 == null)
                        break;
                    else
                    {
                        a4 = d4.Value2.ToString();
                    }

                    if (d5.Value2 == null)
                    {
                        break;
                    }
                    else
                        a5 = d5.Value2.ToString();

                    if (d6.Value2 == null)
                    {
                        break;
                    }
                    else
                        a6 = d6.Value2.ToString();

                        sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\n",null, a1, a2, null, null,a6, a3, 1, null);

                        sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\n", null, a1, a4, a5, 2, a6, null, null, null);
                }
            }

            sw.Close();
        }

        private void Cal_Click(object sender, EventArgs e)//统计区段客流密度
        {
            foreach (PassengerFlow flow1 in PassFlowList)
            {
                foreach (SectionFlow flow2 in SecFlowList)
                {

                  /*  if (flow2.StartStation.StaCode >= flow1.StartStation.StaCode && flow2.EndStation.StaCode <= flow1.EndStation.StaCode)
                    {
                        DateTime dt1 = Convert.ToDateTime(flow1.StartTime);
                        DateTime dt2 = Convert.ToDateTime(flow2.StartTime);
                        DateTime dt3 = Convert.ToDateTime(flow1.EndTime);
                        DateTime dt4 = Convert.ToDateTime(flow2.EndTime);
                        if (DateTime.Compare(dt1, dt2) >= 0 && DateTime.Compare(dt4, dt3) >= 0)
                        {
                            flow2.Num += flow1.Num;
                        }
                    }*/
                }
            }
        }
        
        private void Sta_Click(object sender, EventArgs e)//填充车站信息
        {
            for (int h = 0; h < a.Length; h++)
            {
                ////////////////////////////////////////////////////
                ////////////////
                ///////////
                /////////////////////
                StationInfo Station = new StationInfo();
                Station.Station = a[h];
                Station.StaCode = Convert.ToInt16(h+1);
                StaList.Add(Station);
            }
        }
       
       /* public bool ExportDataGridview(DataGridView gridView, bool isShowExcele)
        {
            if (gridView.Rows.Count == 0)
            {
                return false;
            }

            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcele;

            for (int i = 0; i < gridView.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = gridView.Columns[i].HeaderText;
            }

            for (int i = 0; i < gridView.RowCount - 1; i++)
            {
                for (int j = 0; j < gridView.ColumnCount; j++)
                {
                    if (gridView[j, i].Value == typeof(string))
                    {
                        excel.Cells[i + 2, j + 1] = "" + gridView[i, j].Value.ToString();
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] = gridView[j, i].Value.ToString();
                    }
                }
            }
            return true;
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = Log.OpenFile(@"C:\Users\hpw\Desktop\20121226");
           if (sw == null)
                return;

            sw.Write("车次\t起始站\t上车时间\t终到站\t下车时间\t人数");
            sw.Write("\n");
            //sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",1,2,3,4,5,6);
                
            foreach (PassengerFlow Pass in PassFlowList)
            {
                sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", Pass.TrainNo,Pass.StartStation,Pass.StartTime,Pass.EndStation,Pass.EndTime,Pass.Num);
            }

            sw.Close();

           /* List<PassengerFlow> PassList = PassFlowList;
           for (int i = 0; i < PassList.Count; i++)
            {
                sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", PassList[i].TrainNo, PassList[i].StartStation, PassList[i].StartTime, PassList[i].EndStation, PassList[i].EndTime, PassList[i].Num.ToString("F3"));
                sw.Write("\n");
            }

            sw.Close();*/
        }

        private void 车次统计_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application(); //引用Excel对象   
            Excel.Workbook book = excel.Application.Workbooks.Add(@"F:\实验室\大四\京广高铁夜行车项目\夜行车项目\运行图部分\20130312夜行车项目京广高铁客流分析\客流密度表\京广三角密度表1\京广三角密度表1\20121229.xls");   //引用Excel工作簿   
            excel.Visible = true; //使Excel可视

            //指定要操作的Sheet，两种方式
            //之一：
            Excel.Worksheet xlsSheet = (Excel.Worksheet)book.Sheets[1];

            StreamWriter sw = Log.OpenFile(@"C:\Users\hpw\Desktop\20121229");
            if (sw == null)
                return;
        }
    }
}