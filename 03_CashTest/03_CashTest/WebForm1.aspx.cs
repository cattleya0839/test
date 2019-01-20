using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace _03_CashTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fileJObj = (JObject) Application["json1"];
            Response.Clear();
            Response.Write(fileJObj);
            Response.Write("\nthis is first project aspx");
            Response.End();
        }
    }
}