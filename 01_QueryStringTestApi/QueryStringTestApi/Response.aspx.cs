using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace QueryStringTestApi
{
    public partial class Response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var requestMethod = Request.HttpMethod;

            var responseObj = new { msg = "this Api accept GET only " };
            var responseMsg = JsonConvert.SerializeObject(responseObj);
            if (requestMethod.Equals("GET"))
            {
                responseMsg = GetResponseByRequest();
            }

            Response.Clear();
            Response.Write(responseMsg);
            Response.End();
        }

        private string GetResponseByRequest()
        {
            Dictionary<string, string> returnObj = new Dictionary<string, string>();
            try
            {
                var queryAndValue = Request.QueryString;
                var queryString = queryAndValue.ToString();
                var queryKeyAndValue = queryAndValue.AllKeys.ToDictionary(key => key, key => queryAndValue[key]);
                foreach (var key in queryAndValue.AllKeys)
                {
                    if (queryString.Contains(queryAndValue[key]))
                    {
                        returnObj[key] = "Ok";
                        continue;
                    }
                    else
                    {
                        returnObj[key] = "NG";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                returnObj["msg"] = ex.Message;
            }
            return JsonConvert.SerializeObject(returnObj);

        }
    }
}
