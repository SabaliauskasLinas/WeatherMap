using Model.Entities;
using Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZomatoParser
{
    public partial class Form1 : Form
    {
        private static ITestService _testService;
        public Form1(ITestService testService)
        {
            _testService = testService;
            InitializeComponent();
        }

        private void btnRestaurants_Click(object sender, EventArgs e)
        {
            var entities = _testService.GetEntities();
            PopulateList(entities);
        }

        private void btnCuisines_Click(object sender, EventArgs e)
        {
            var entities = _testService.GetNewEntities();
            PopulateList(entities);
        }

        private void PopulateList<T>(List<T> objects)
        {
            //listView.Clear();
            //var properties = objects[0].GetType().GetProperties();
            //var colWidth = listView.Width / properties.Length;
            //foreach (var prop in properties)
            //{
            //    listView.Columns.Add(prop.Name, colWidth);
            //}
            //foreach (var entity in objects)
            //{
            //    List<string> row = new List<string>();
            //    foreach (var prop in properties)
            //    {
            //        row.Add(prop.GetValue(entity).ToString());
            //    }
            //    var listViewItem = new ListViewItem(row.ToArray());
            //    listView.Items.Add(listViewItem);
            //}
        }

        private void mapControl1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            Console.Write("a");
        }

        private void mapControl1_MapItemClick(object sender, DevExpress.XtraMap.MapItemClickEventArgs e)
        {
            Console.Write("a");
        }

        private void mapControl1_Click(object sender, EventArgs e)
        {
            Console.Write("a");
        }

        private void mapControl1_ObjectSelected(object sender, DevExpress.XtraMap.ObjectSelectedEventArgs e)
        {
            Console.Write("a");
        }

        private void mapControl1_SelectionChanged(object sender, DevExpress.XtraMap.MapSelectionChangedEventArgs e)
        {
            Console.Write("a");
        }
    }
}
