using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(@"Data Source=PREDATOR;Initial Catalog=Db_Sales;Integrated Security=True;TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand("select productName,curtomerNameAndSurname,staffName,preis from TblOperations " +
                "inner join TblCustomer on TblCustomer.curtomerId = TblOperations.customer " +
                "inner join TblProducts on TblProducts.productId = TblOperations.productNo " +
                "inner join TblStaffs on TblStaffs.staffId = TblOperations.staff",sql);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
