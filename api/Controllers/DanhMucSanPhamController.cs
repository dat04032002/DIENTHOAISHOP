using Common.Entities;
using api.Soure_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucSanPhamController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IComparable<DanhMucSanPhammodel>> GetDanhMucs()
        {
            List<DanhMucSanPhammodel> danhMucSanPhammodels = new List<DanhMucSanPhammodel>();
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    danhMucSanPhammodels = con.GetAll_DanhMucSanPham();
                }
            }

            return Ok(danhMucSanPhammodels);
        }
        [HttpGet("{id}")]
        public ActionResult<DanhMucSanPhammodel> GetDanhMuc(int id)
        {
            DanhMucSanPhammodel danhMucSanPhammodels = new DanhMucSanPhammodel();
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    danhMucSanPhammodels = con.Get_DanhMucSanPham(id);
                }
            }

            return Ok(danhMucSanPhammodels);
        }
        [HttpPut]
        public ActionResult<DanhMucSanPhammodel> Sua(DanhMucSanPhammodel danhMucSanPhammodel)
        {
            bool a;
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    a = con.Update_DanhMucSanPham(danhMucSanPhammodel);
                    if (a == false)
                    {
                        return BadRequest("sửa không thành công");
                    }
                }
            }

            return Ok(danhMucSanPhammodel);
        }
        [HttpPost]
        public ActionResult<DanhMucSanPhammodel> Them(DanhMucSanPhammodel danhMucSanPhammodel)
        {
            bool a;
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    a = con.Insert_DanhMucSanPham(danhMucSanPhammodel);
                    if (a == false)
                    {
                        return BadRequest("sửa không thành công");
                    }
                }
            }

            return Ok(danhMucSanPhammodel);
        }
    }
}
