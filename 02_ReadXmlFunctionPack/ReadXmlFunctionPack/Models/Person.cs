using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace ReadXmlFunctionPack.Models
{
    [XmlRoot("person")]
    public class Person
    {
        [Required]
        [XmlAttribute("id")]
        public string Id { get; set; }

        [RegularExpression("[^\n]*", ErrorMessage = "名前に改行は使用できません。")]
        [XmlElement("name")]
        public string Name { get; set; }

        [RegularExpression("[^\n]*", ErrorMessage = "性別に改行は使用できません。")]
        [XmlElement("sex")]
        public string Sex { get; set; }

        [RegularExpression("[^\n]*", ErrorMessage = "年齢に改行は使用できません。")]
        [XmlElement("age")]
        public string Age { get; set; }

        public bool TryValidate(out string returnMessage)
        {
            StringBuilder message = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Id))
            {
                message.Append("id\n");
            }
            if (Name.Contains("\n"))
            {
                message.Append("name\n");
            }
            if (Sex.Contains("\n"))
            {
                message.Append("sex\n");
            }
            if (Age.Contains("\n"))
            {
                message.Append("age\n");
            }

            returnMessage = message.ToString();
            return string.IsNullOrWhiteSpace(returnMessage);
        }
    }
}