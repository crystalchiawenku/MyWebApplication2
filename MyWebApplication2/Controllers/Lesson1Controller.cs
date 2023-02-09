using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApplication2.Controllers
{
    public class Lesson1Controller : Controller
    {
        // GET: Lesson1
        
        //產生一個空白的View
        public ActionResult Index()
        {
            return View();
        }

        //不產生View,到Views資料夾手動新增IndexHello
        public ActionResult Index1A()
        {
            return View("IndexHello");
        }
        //不產生View
        public ActionResult Index1B()
        {
            return View("~/Views/Lesson1/IndexHello.cshtml");
        }

        //ActionResult改為string, 不產生View
        public string Index1C()
        {
            return "ActionResult移除改為string，畫面上傳回: <h3>字串: string</h3>";
        }
        //ActionResult也可以改成DataTime型別
        public DateTime Index1C2()
        {
            return  DateTime.Now;
        }

        //不產生檢View, View改為Content, 自己輸入網址URL來觀看結果。
        public ActionResult Index1D()
        {
            return Content("<h3>用Content傳回文字內容</h3>");
            //return Content("<h3>用Content傳回文字內容</h3>", "text/Plain", System.Text.Encoding.UTF8);//純文字,沒有HTML效果
            //return Content("<h3>用Content傳回文字內容</h3>", "text/html", System.Text.Encoding.UTF8);//有HTML效果
        }
        
        //不產生View，直接轉導另一個網頁
        public ActionResult Index1E()
        {
            return Redirect("https://www.google.com/");
        }

        //HandleUnknownAction()找不到Action或輸入錯誤一律轉到回首頁或特定頁面的方法
        //MSDN: https://msdn.microsoft.com/zh-tw/library/dd492730(v=vs.118).aspx
        //建議不要在開發階段寫不然很難抓錯
        //protected override void HandleUnknownAction(string actionName)
        //{
        //    Response.Redirect("https://www.google.com/");
        //    //Response.Redirect("/", true); //這是另一種轉導回首頁的寫法, 參考: https://blog.miniasp.com/post/2009/07/06/ASPNET-MVC-Developer-Note-Part-7-HandleUnknownAction
        //    base.HandleUnknownAction(actionName);
        //}

        //新增View的時候用版面配置頁
        //版面配置頁檔路徑: ~/Views/Shared/_LayoutPage1.cshtml
        public ActionResult Index2()
        {
            return View();
        }

        //新增view的時候用另一個版面配置頁(_LayoutPage2.cshtml), 範本選Empty(沒有模型)
        public ActionResult Index8()
        {
            return View();
        }

        //--------------------------------------------------------------------------------------------------------
        //---- ViewBag、ViewData
        //--------------------------------------------------------------------------------------------------------
        //新增View不使用版面配置
        public ActionResult Index3()
        {
            ViewData["A"]= "我是ViewData[]";
            ViewBag.B = "我是ViewBag";
            TempData["C"] = "我是TemData[]";            
            
            return View();
        }

        // 如果ViewData & ViewBag 相同命名，會出現什麼情況？？
        // 例如：ViewData["XYZ"] & ViewBag.XYZ  ？
        // 新增View不使用版面配置
        // 補充：https://www.c-sharpcorner.com/UploadFile/db2972/datatable-in-viewdata-sample-in-mvc-day-3/
            // DataTable，透過 ViewBag傳遞給 檢視畫面使用
        public ActionResult Index3A()
        {
            ViewData["XYZ"] = "** 您好：我是ViewData[] **";
            ViewBag.XYZ = "抱歉！改了內容，我是ViewBag。";
            return View();
        }

        //-- 搭配第一個類別檔 (~/Models/Class1.cs) 當作Model，但沒有連結資料庫。
        // 產生檢視（View）的時候，不使用任何「版面配置頁」
        // 請使用「Details」範本。只傳遞「一筆」數據而已。

        public ActionResult Index4()
        {
            //寫法一
            //Models.Class1=new Models.Class1();
            //var username = new Models.Class1();
            //username.UserName = "我躲在Class1類別 的 UserName 屬性。";

            //VS會建議寫法一如下
            //var username = new Models.Class1
            //{
            //    UserName = "我是躲在類別檔的屬性!"
            //};
            //return View(username);

            //寫法二(新寫法)
            //var name = new Models.Class1 { UserName = "我是躲在類別檔的屬性!" };

            //寫法三
            Models.Class1 name = new Models.Class1 { UserName = "我是躲在類別檔的屬性!" };

            return View(name);
        }













     


    }
}