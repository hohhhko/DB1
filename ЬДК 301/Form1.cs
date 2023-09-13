using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ЬДК_301
{
    public partial class Form1 : Form
    {
        private SQLiteConnection DB;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnetctionString);
            await DB.OpenAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT * FROM Peapol", DB);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataAdapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];

        }
    }
    
}

