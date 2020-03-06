using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace adodatabase
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static SqlConnection con= new SqlConnection(ConfigurationManager.ConnectionStrings["connstring"].ConnectionString);
        public static SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label4.Visible = false;
            DropDownList1.Visible = false;
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Label1.Text = "Enter the Id:";
                Label2.Visible = true;
                TextBox2.Visible = true;
                Label3.Visible = true;
                TextBox3.Visible = true;
                con.Open();
                if ((TextBox1.Text != " " || Convert.ToInt32(TextBox1.Text) != 0)&&(TextBox2.Text!=" ")&&(TextBox3.Text!=" "))
                {
                    cmd = new SqlCommand("Insert into student(stud_id,stud_name,stud_address)values(@stud_id,@stud_name,@stud_address)", con);
                    cmd.Parameters.AddWithValue("@stud_id", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@stud_name", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@stud_address", TextBox3.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    ShowMessage("records inserted");

                }
                else
                {
                    ShowMessage("No records Inserted");
                }
            }
            catch(Exception v)
            {
                ShowMessage(v.Message);
            }
            finally
            {
                con.Close();
                clear();
            }
        }
        void ShowMessage(string msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation",
                "<script type=\"text/javascript\"> alert('" + msg + "');</ script > ");  
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            TextBox2.Visible = true;
            Label3.Visible = true;
            TextBox3.Visible = true;
            Label1.Text = "Enter the Id:";
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd = new SqlCommand("Select * from student;", con);
                    SqlDataAdapter sad = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sad.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    clear();
                }

            }
            catch(Exception e1)
            {
                ShowMessage(e1.Message);
            }
            finally
            {
                con.Close();
            }
            
        }
        void clear()
        {
            TextBox1.Text = " ";
            TextBox2.Text = " ";
            TextBox3.Text = " ";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = "Enter The Id of the element to update:";
            Label4.Visible = true;
            DropDownList1.Visible = true;
            try
            {
                Label2.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;
                Label3.Visible = false;
                
                con.Open();
                if (DropDownList1.SelectedValue=="Name")
                {

                    Label2.Visible = true;
                    TextBox2.Visible = true;

                    cmd = new SqlCommand("Update student set stud_name=@stud_name where stud_id=@stud_id", con);
                    cmd.Parameters.AddWithValue("@stud_name", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@stud_id", TextBox1.Text);
                    int v=cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    GridView1.EditIndex = -1;
                    ShowMessage("Updated"+v.ToString()+"no of records");
                    
                }
                else if (DropDownList1.SelectedValue== "Address")
                {
                    Label2.Visible = false;
                    TextBox2.Visible = false;
                    Label3.Visible = true;
                    TextBox3.Visible = true;
                    cmd = new SqlCommand("Update student set stud_address=@stud_address where stud_id=@stud_id", con);
                    cmd.Parameters.AddWithValue("@stud_address", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@stud_id", TextBox1.Text);
                    int v = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    GridView1.EditIndex = -1;
                    ShowMessage("Updated" + v.ToString() + "no of records");
                }
            }
            catch(Exception e1)
            {
                ShowMessage(e1.Message);
                Response.Write(e1.ToString());
            }
            finally
            {
                con.Close();
                clear();

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label1.Text="Enter the id to delete:";
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from student where stud_id="+Convert.ToInt32(TextBox1.Text),con);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                GridView1.EditIndex = -1;
                ShowMessage("Deleted record"+ Convert.ToInt32(TextBox1.Text));
            }
            catch(Exception e1)
            {
                ShowMessage(e1.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}