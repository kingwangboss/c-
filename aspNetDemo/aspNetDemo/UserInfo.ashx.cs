using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace aspNetDemo
{
    /// <summary>
    /// UserInfo 的摘要说明
    /// </summary>
    public class UserInfo : IHttpHandler
    {
      
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Student",conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        str.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td><a href='UserInfoDetail.ashx?id={3}'>详细</a></td></tr>", table.Rows[i]["Stu_id"],
                            table.Rows[i]["Stu_name"], table.Rows[i]["Stu_desc"], table.Rows[i]["Stu_id"]);
                    }

                    string filePath = context.Request.MapPath("UserInfo.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$tbody",str.ToString());
                   
                   context.Response.Write(fileContent);
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

    class Studunt
    {
        public string Stu_name { get; set; }

        public string Stu_desc { get; set; }
    }
}

