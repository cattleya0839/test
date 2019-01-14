using System;
using System.Xml.Serialization;
using System.IO;

namespace ReadXmlFunctionPack.Models
{
    // Xmlを読み込み、そこからオブジェクトを生成するためのクラス
    public static class ReadXml
    {
        // ~/App_Data/Xml/からファイルを読み込むことを前提とする。
        private static readonly string DirectoryOfXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Xml");

        public static T CreateObjectFromXml<T>(string fileName)
        {
            // Exception処理が必要となる場合があるので入れておく。
            try
            {
                string filePath = GetFilePath(fileName);
                return CreateObject<T>(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ファイルパスを取得するメソッド
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>ファイルパス</returns>
        private static string GetFilePath(string fileName)
        {
            // 拡張子が記入されていないとき拡張子を追加しておく。
            if (!fileName.ToLower().EndsWith(".xml"))
            {
                fileName += ".xml";
            }

            // 拡張子の大文字小文字については後で検証が必要

            // ファイルパスを作成
            return Path.Combine(DirectoryOfXml, fileName);
        }

        /// <summary>
        /// ファイルを読み込みオブジェクトを作成する関数
        /// </summary>
        /// <typeparam name="T">返却するオブジェクトのクラス</typeparam>
        /// <param name="filePath">読み込むファイルのパス</param>
        /// <returns>読み込んだファイルをもとに生成されたオブジェクト</returns>
        private static T CreateObject<T>(string filePath)
        {
            // ファイル読みこみ
            using (var fileStreamOfXml = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                // シリアライザーを作成し、それを用いてデシリアライズを行う
                return (T)new XmlSerializer(typeof(T))
                    .Deserialize(fileStreamOfXml);
            }
        }
    }
}
