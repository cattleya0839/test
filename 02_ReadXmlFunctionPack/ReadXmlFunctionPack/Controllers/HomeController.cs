using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadXmlFunctionPack.Models;
using System.Reflection;


namespace ReadXmlFunctionPack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ReadXmlFunctionTest()
        {
            ViewBag.Msg = "Success";
            People people = ReadXml.CreateObjectFromXml<People>("People");
            people.validate();
            return View();
        }

    }
}