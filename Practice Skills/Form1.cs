using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practice_Skills;

namespace Practice_Skills
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public db mydb;
        public DataTable dt;
        BindingSource bs = new BindingSource();
        private void Form1_Load(object sender, EventArgs e)
        {
            mydb = new db("Skills");
            dt = mydb.Get();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            DataGridViewColumn add = new DataGridViewButtonColumn();
            add.Name = "+";
            DataGridViewColumn min = new DataGridViewButtonColumn();
            min.Name = "-";
            dataGridView1.Columns.Add(add);
            dataGridView1.Columns.Add(min);
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                dataGridView1.Rows[i].Cells[3].Value = "-";
                dataGridView1.Rows[i].Cells[2].Value = "+";
            }
            this.FormClosed += MainPage_FormClosed;
        }
        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            mydb.UDT(dt);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex ==2 && e.RowIndex >= 0)
            {
                int x= int.Parse( dt.Rows[e.RowIndex][1].ToString());
                x++;
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = x.ToString();
            }
            else if(e.ColumnIndex==3 && e.RowIndex >= 0)
            {
                int x = int.Parse(dt.Rows[e.RowIndex][1].ToString());
                if(x>0)
                x--;
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = x.ToString();
            }
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "") return;
                DataRow r = dt.NewRow();
                r["Skills"] = textBox1.Text;
                r["Num"] = 0;
                dt.Rows.Add(r);
                int len = dataGridView1.Rows.Count - 1;
                dataGridView1.Rows[len].Cells[3].Value = "-";
                dataGridView1.Rows[len].Cells[2].Value = "+";
                textBox1.Text = "";
            }
        }

        private void addClick(object sender, EventArgs e)
        {

        }
        private void minClick(object sender, EventArgs e)
        {

        }
    }
}
