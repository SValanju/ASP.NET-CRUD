using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Table
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-J3PUE9B;database=DcodeTech;integrated security=SSPI");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button2.Enabled = false;
                fillGridView();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pname = TextBox1.Text;
            string pdesc = TextBox2.Text;
            string pval = TextBox3.Text;

            string sql = "insert into Products(ProductName, ProductDescription, ProductValue) values('"+ pname +"', '"+ pdesc +"', '"+ pval +"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int status = cmd.ExecuteNonQuery();
            con.Close();
            clear();
            if (status > 0)
            {
                Label4.Text = "Submitted Successfully!";
            }
            else
            {
                Label5.Text = "Insertion Failed!";
            }
            fillGridView();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int pid = int.Parse(HiddenField1.Value);
            string pname = TextBox1.Text;
            string pdesc = TextBox2.Text;
            string pval = TextBox3.Text;

            string sql = "update Products set ProductName='"+ pname +"', ProductDescription='"+ pdesc +"', ProductValue='"+ pval +"' where ID='"+ pid +"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int status = cmd.ExecuteNonQuery();
            con.Close();
            clear();
            if (status > 0)
            {
                Label4.Text = "Updated Successfully!";
            }
            else
            {
                Label5.Text = "Updation Failed!";
            }
            fillGridView();
            Button1.Enabled = true;
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("viewData", con);
            sqlda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", id);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            con.Close();
            HiddenField1.Value = id.ToString();
            TextBox1.Text = dtbl.Rows[0]["ProductName"].ToString();
            TextBox2.Text = dtbl.Rows[0]["ProductDescription"].ToString();
            TextBox3.Text = dtbl.Rows[0]["ProductValue"].ToString();
            Button1.Enabled = false;
            Button2.Enabled = true;
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            con.Open();
            SqlCommand sql = new SqlCommand("deleteData", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@ID", id);
            sql.ExecuteReader();
            con.Close();
            clear();
            fillGridView();
            Label6.Text = "Record Deleted Successfully!";
        }

        public void clear()
        {
            HiddenField1.Value = "";
            TextBox1.Text = TextBox2.Text = TextBox3.Text = "";
            Label4.Text = Label5.Text = Label6.Text = "";
            Button2.Enabled = false;
        }

        void fillGridView()
        {
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("viewAllData", con);
            sqlda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            con.Close();
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
        }
    }
}