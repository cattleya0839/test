using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace StreamReaderTest
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

            Response.Clear();

            // ファイル読み込みの下準備
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(currentDirectory, "App_Data", "json1.json");

            var task = Task.Run(() => { FileRead(1, filePath); });
            var task2 = Task.Run(() => { FileRead(2, filePath); });
            var task3 = Task.Run(() => { FileRead(3, filePath); });
            var task4 = Task.Run(() => { FileRead(4, filePath); });
            var task5 = Task.Run(() => { FileRead(5, filePath); });
            var task6 = Task.Run(() => { FileRead(6, filePath); });
            var task7 = Task.Run(() => { FileRead(7, filePath); });
            var task8 = Task.Run(() => { FileRead(8, filePath); });
            var task9 = Task.Run(() => { FileRead(9, filePath); });
            var task10 = await Task.Run(() =>
            {
                FileRead(10, filePath);
                return 1;
            });

            Response.Write("success");
            Response.Close();
        }

        private void FileRead(int num, string filePath)
        {

            for (var i = 0; i < 100; ++i)
            {
                using (var sr = new StreamReader(filePath))
                {
                    Response.Write($"file{num}:{i+1}<br />");
                }
            }
        }
    }
}