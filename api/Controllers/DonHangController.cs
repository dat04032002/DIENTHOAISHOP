using Common.Entities;
using api.Soure_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers       
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<DonHangmodel>> Get() {
            List<DonHangmodel> donHangmodels = new List<DonHangmodel>();
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    donHangmodels = con.GetAll_DonHang();
                }
            }

            return Ok(donHangmodels);
        }
        [HttpGet("{id}")]
        public ActionResult<DonHangmodel> Get(string id)
        {
            DonHangmodel donHangmodels = new DonHangmodel();
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    donHangmodels = con.Get_DonHang(id);
                }
            }

            return Ok(donHangmodels);
        }
        [HttpGet("ChiTietDonHang/{id}")]
        public ActionResult<IEnumerable<ChiTietDonHangmodels>> GetChiTiet(string id)
        {
            List<ChiTietDonHangmodels> donHangmodels = new List<ChiTietDonHangmodels>();
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    donHangmodels = con.Get_DonHangChiTiet(id);
                }
            }

            return Ok(donHangmodels);
        }
        [HttpPost]
        public ActionResult<string> Insert(DonHangmodel donHangmodels)
        {
          
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    bool kt;
                 
                        kt= con.Insert_DonHang(donHangmodels);
                        if (kt == false)
                        {
                        return Ok("Thêm Thất bại");
                        }
                    
                }
            }

            return Ok("thanhcong");
        }
        [HttpPost("Themchitiet")]
        public ActionResult<string> Insertchitiet(List<ChiTietDonHangmodels?> donHangmodels)
        {
            string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";
            Connext con = new Connext(connstr);
            if (con != null)
            {
                if (con._OpenConnection())
                {
                    bool kt;
                    foreach(var item in donHangmodels)
                    {
                        kt = con.Insert_ChiTietDonHang(item);
                        if (kt == false)
                        {
                            return Ok("Thêm Thất bại");
                          
                        }

                    }


                }
            }

            return Ok("thêm thành công");
        }
        
    }
}
