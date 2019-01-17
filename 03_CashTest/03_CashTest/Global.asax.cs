using System;
using System.IO;
using _03_CashTest.App_Code;
namespace _03_CashTest
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Jsonファイルの位置を指定
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var filePath1 = Path.Combine(currentDirectory, "App_Data", "json1.json");
            var filePath2 = Path.Combine(currentDirectory, "App_Data", "json2.json");

            //Jsonファイル読み込み
            Application["json1"] = ReadJson.CreateObjectFromJsonFile(filePath1);
            Application["json2"] = ReadJson.CreateObjectFromJsonFile(filePath2);
        }
    }
}