using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lucky.Service;
using Microsoft.AspNetCore.Mvc;
using Lucky.Web.Models;

namespace Lucky.Web.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            int accountId = 1;
            LuckyAccountService service = new LuckyAccountService();
            bool isAllow = await service.GetAllowLuckyByAccount(accountId);
            ViewBag.IsAllow = isAllow;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetLuckyResult(int accountId)
        {
            LuckyProductService service = new LuckyProductService();
            var res = await service.GetLuckyAction(accountId);
            if (!string.IsNullOrWhiteSpace(res?.LuckyIndex))
            {
                var indexs = res?.LuckyIndex.Split(',');
                if (indexs.Length > 1)
                {
                    Random r=new Random();
                    int ran = r.Next(0, indexs.Length);
                    res.LuckyIndex = indexs[ran];
                }
            }
            return Json(new { code = res == null ? 0 : 1, msg = "", data = res });
        }

    }
}
