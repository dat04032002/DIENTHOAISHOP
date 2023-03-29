
using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using view.CodeCallApi;

namespace view.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        // GET: DanhMucSanPham
        public ActionResult Index()
        {
            return View();
        }

        // GET: DanhMucSanPham/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // GET: DanhMucSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucSanPham/Create
       
        // GET: DanhMucSanPham/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return View();
        }

        #region xử lý 
        public async Task<ActionResult> Get()
        {
            try
            {

                var obj = await CallApi.Get("api/DanhMucSanPham"); // link api sang project API tương ứng với route 

                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }
        public async Task<ActionResult> GetByID(int id)
        {
            try
            {

                var obj = await CallApi.GetByID("api/DanhMucSanPham/" + id); // link api sang project API tương ứng với route 

                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }
        public async Task<ActionResult> Update(DanhMucSanPhammodel obj)
        {

         
            try
            {
                var objre = await CallApi.Update("api/DanhMucSanPham", obj);
                var jsoncode = JsonConvert.SerializeObject(objre);

                return Json(jsoncode);
            }
            catch { }
            return Json("");
        }
        public async Task<ActionResult> Them(DanhMucSanPhammodel obj)
        {

try
            {
                var objre = await CallApi.Insert("api/DanhMucSanPham", obj);
                var jsoncode = JsonConvert.SerializeObject(objre);
                if (objre == null)
                {
                    return Json("");
                }
                return Json(jsoncode);
            }
            catch { }
            return Json("");
        }
        #endregion

    }
}
