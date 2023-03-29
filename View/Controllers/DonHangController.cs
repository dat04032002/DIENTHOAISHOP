using view.CodeCallApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Microsoft.AspNetCore.Mvc;

namespace view.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        public ActionResult Index()
        {
            return View();
        }

        // GET: DonHang/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.id = id;
            return View();
        }

        // GET: DonHang/Create
        public ActionResult Create()
        {
            return View();
        }

      
        // GET: DonHang/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.id = id;
            return View();
        }

        #region xử lý
        public async Task<ActionResult> Get()
        {
            try
            {

                var obj = await CallApi.Get("api/DonHang"); // link api sang project API tương ứng với route 
                if (obj == null)
                {
                    return Json("");
                }
                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }
        public async Task<ActionResult> GetById(string id)
        {
            try
            {

                var obj = await CallApi.GetByID("api/DonHang/"+id); // link api sang project API tương ứng với route 
                if (obj == null)
                {
                    return Json("");
                }
                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }
        public async Task<ActionResult> GetChiTiet(string id)
        {
            try
            {

                var obj = await CallApi.GetByID("api/DonHang/ChiTietDonHang/" + id); // link api sang project API tương ứng với route 
                if (obj == null)
                {
                    return Json("");
                }
                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }
        #endregion


    }
}
