using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.IO;


namespace _03_CashTest.App_Code
{
    public static class ReadJson
    {
        public static JObject CreateObjectFromJsonFile(string filePath)
        {
            // ファイル読み込み
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var fileString = new StreamReader(fileStream).ReadToEnd();

            // オブジェクトに変更して返却
            return JObject.Parse(fileString);
        }
    }
}