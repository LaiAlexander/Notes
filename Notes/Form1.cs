using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
    public partial class Form1 : Form
    {
        DataTable notesTable;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notesTable = new DataTable();
            notesTable.Columns.Add("Title", typeof(String));
            notesTable.Columns.Add("Body", typeof(String));

            dataGridView1.DataSource = notesTable;
            dataGridView1.Columns["Body"].Visible = false;
            dataGridView1.Columns["Title"].Width = 175;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            TitleTextBox.Clear();
            BodyTextBox.Clear();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            notesTable.Rows.Add(TitleTextBox.Text, BodyTextBox.Text);

            TitleTextBox.Clear();
            BodyTextBox.Clear();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                return;
            }
            
            int index = dataGridView1.CurrentCell.RowIndex;

            if (index >= 0)
            {
                TitleTextBox.Text = notesTable.Rows[index]["Title"].ToString();
                BodyTextBox.Text = notesTable.Rows[index]["Body"].ToString();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                return;
            }

            int index = dataGridView1.CurrentCell.RowIndex;

            notesTable.Rows[index].Delete();
        }
    }
}
