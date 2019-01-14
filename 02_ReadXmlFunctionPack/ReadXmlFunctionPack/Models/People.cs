using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace ReadXmlFunctionPack.Models
{
    [XmlRoot("people")]
    public class People
    {
        [XmlArray("persons")]
        [XmlArrayItem("person")]
        public List<Person> PersonList { get; set; }

        /// <summary>
        /// 生成されたオブジェクトが正しいかを確認します。
        /// </summary>
        public void validate()
        {
            // エラー用文字列生成(連結がたくさんある可能性を考えてStringBuilderを採用)
            StringBuilder errorMessage = new StringBuilder();
            foreach (var person in PersonList)
            {
                if (!person.TryValidate(out string message))
                {
                    // 生成されたオブジェクトに問題があるときはどこに問題があるかを通知するメッセージを作成する。
                    errorMessage.Append(CreateErrorMessage(person, message));
                };
            }

            //問題がないかを確認する。
            var stringConvertedErrorMessage = errorMessage.ToString();
            if (string.IsNullOrWhiteSpace(stringConvertedErrorMessage))
            {
                // 問題がなければその時点で処理終了
                return;
            }

            //問題がある場合の処理
            throw  new Exception(stringConvertedErrorMessage);
        }

        /// <summary>
        /// バリデーション用のエラーメッセージを生成します。
        /// </summary>
        /// <param name="uncorrectPersonObject"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private string CreateErrorMessage (Person uncorrectPersonObject, string errorMessage)
        {
            var indexUncorrectObject = PersonList.IndexOf(uncorrectPersonObject)+1;
            return $"{indexUncorrectObject}番目のPerson\n" + errorMessage;
        }
    }
}