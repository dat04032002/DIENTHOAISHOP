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
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
            return View();
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }


       
        // GET: NhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return View();
        }


        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NhanVien/Delete/5
        #region Hàm Xử LÝ
        public async Task<ActionResult> GetNhanVien()
        {
            try
            {

                var obj = await CallApi.Get("api/NhanVien"); // link api sang project API tương ứng với route 

                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }
        public async Task<ActionResult> GetNhanVienByID(int id)
        {
            try
            {

                var obj = await CallApi.GetByID("api/NhanVien/"+id); // link api sang project API tương ứng với route 

                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }
   
        public async Task<ActionResult> Updatenv(NhanVienmodel obj)
        {

       
            try
            {
                var objre = await CallApi.Update("api/NhanVien", obj);
                var jsoncode = JsonConvert.SerializeObject(objre);

                return Json(jsoncode);
            }
            catch { }
            return Json("");
        }
        public async Task<ActionResult> Fill(NhanVienmodel objl)
        {
            try
            {

                var obj = await CallApi.Get("api/NhanVien/Loc/nhanvien?" + "TenNHanVien"+"="+objl.TenNHanVien+"&DiaChi="+objl.DiaChi+"&GioiTinh="+objl.GioiTinh+"&ChucVu="+objl.ChucVu+"&TinhTrang="+objl.TinhTrang); // link api sang project API tương ứng với route 

                var jsonCode = JsonConvert.SerializeObject(obj);

                return Json(jsonCode);
            }
            catch (Exception ex)
            {

            }
            return Json("");
        }
        public async Task<ActionResult> Themnv(NhanVienmodel obj)
        {

          
            try
            {
                var objre = await CallApi.Insert("api/NhanVien", obj);
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
