using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace aspNetDemo
{
    /// <summary>
    /// AddUserInfo 的摘要说明
    /// </summary>
    public class AddUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "json/application";
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand cmdSqlCommand = new SqlCommand())
                {
                    connection.Open();
                    cmdSqlCommand.Connection = connection;
                    cmdSqlCommand.CommandText = "insert into Student(Stu_name,Stu_desc) values(@name,@desc)";
                    var sqlParams = new SqlParameter[]
                    {
                        new SqlParameter("@name", context.Request.Form["name"]),
                         new SqlParameter("@desc", context.Request.Form["desc"]),
                    };
                    //cmdSqlCommand.Parameters.Add("@name", context.Request.Form["name"]);
                    //cmdSqlCommand.Parameters.Add("@desc", context.Request.Form["desc"]);

                    cmdSqlCommand.Parameters.AddRange(sqlParams);
                    
                    if (cmdSqlCommand.ExecuteNonQuery() > 0)
                    {
                        context.Response.Redirect("UserInfo.ashx");
                    }
                    else
                    {
                        context.Response.Write("添加失败");
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}