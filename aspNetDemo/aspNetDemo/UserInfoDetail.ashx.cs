using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace aspNetDemo
{
    /// <summary>
    /// UserInfoDetail 的摘要说明
    /// </summary>
    public class UserInfoDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Student where Stu_id=@id", conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@id",id);
                        DataTable tabel = new DataTable();
                        adapter.Fill(tabel);
                        if (tabel.Rows.Count > 0)
                        {
                            string filePath = context.Request.MapPath("UserInfoDetail.html");
                            string fileContext = System.IO.File.ReadAllText(filePath);
                            string str = string.Format("姓名：{0}，描述：{1}",tabel.Rows[0]["Stu_name"],tabel.Rows[0]["Stu_desc"]);

                           context.Response.Write(fileContext.Replace("$body", str));
                        }
                        else
                        {
                            context.Response.Write("没有这条数据");
                        }
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