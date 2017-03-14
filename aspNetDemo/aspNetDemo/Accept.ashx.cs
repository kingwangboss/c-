using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspNetDemo
{
    /// <summary>
    /// Accept 的摘要说明
    /// </summary>
    public class Accept : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request.Form["UserName"];
            string passWord = context.Request.Form["pwd"];
            if (userName == passWord)
            {
                context.Response.Write("用户名密码相同" );
            }
            else
            {
                context.Response.Write("用户名:" + userName + "密码:" + passWord);
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