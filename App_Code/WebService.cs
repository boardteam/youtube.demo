﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ServiceCS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    public WebService()
    {
    }

    [WebMethod]
    public DataTable Get()
    {  string constr = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(constr))
        //SqlConnection con = new SqlConnection(@"data sourse=.\SQLEXPRESS; INTEGRATE SECURITY=TRUE;"+ @"AttachDbFilename=C:\\PROJECTS\\2015_02_01 BROADX\\CRUDExample\\App_Data\\Registration.mdf; Initial Catalog=Costomers1" );
            {
            //    con.open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "Customers";
                            sda.Fill(dt);
                           return dt;
                        }
                    }
                }
            }
       
    }

    [WebMethod]
    public void Insert(string name, string country)
    {
        string constr = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Name, Country) VALUES (@Name, @Country)"))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    [WebMethod]
    public void Update(int customerId, string name, string country)
    {
        string constr = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Customers SET Name = @Name, Country = @Country WHERE CustomerId = @CustomerId"))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    [WebMethod]
    public void Delete(int customerId)
    {
        string constr = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId = @CustomerId"))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }





}