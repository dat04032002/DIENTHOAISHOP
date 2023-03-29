using view.CodeCallApi;
using Common.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;


namespace view.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }

        // GET: SanPham/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPham/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return View();
        }




        // GET: SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.id = id;
            return View();
        }


       
        public async Task<ActionResult> GetSanPham()
        {
            try
            {

                var obj = await CallApiSanPham.GetTemplateAsync("api/SanPham"); // link api sang project API tương ứng với route 

                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {
             
            }
            return Json("");
        }
        public async Task<ActionResult> Fill(SanPhammodel objl)
        {
            try
            {

                var obj = await CallApi.Get("api/SanPham/LocSanpham?TenSanPham="+objl.TenSanPham+ "&GiaBan="+objl.GiaBan+ "&Hang="+objl.Hang+ "&LoaiSp="+objl.LoaiSp+ "&TrangThai="+objl.TrangThai); // link api sang project API tương ứng với route 

                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }
        public async Task<ActionResult> GetSanPhamTheoId(int id)
        {
            try
            {

                var obj = await CallApiSanPham.GetTemplateAsync("api/SanPham/"+id); // link api sang project API tương ứng với route 

                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }

        public async Task<ActionResult> NgungBanSP(int id)
        {
           
            
            try {
                var objre = await CallApiSanPham.DeleteSanPham("api/SanPham/Xoa/" +id, id);
                    var jsoncode= JsonConvert.SerializeObject(objre);
                return Json(jsoncode);
            }catch { }
            return Json("");
        }
        public async Task<ActionResult> UpdateSP(SanPhammodel obj)
        {

      
            try
            {
                var objre = await CallApiSanPham.UpdateSanPham("api/SanPham", obj);
                var jsoncode = JsonConvert.SerializeObject(objre);
           
                return Json(jsoncode);
            }
            catch { }
            return Json("");
        }
        public async Task<ActionResult> InsertSP(SanPhammodel obj)
        {

           try
            {
                var objre = await CallApiSanPham.Insert_SanPham("api/SanPham", obj);
               
                var jsoncode = JsonConvert.SerializeObject(objre);
                
                return Json(jsoncode);
            }
            catch { }
            return Json("");
        }
    }
}
