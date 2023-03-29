

namespace Common.Entities
{
  
    public class DonHangmodel
    {
       
        public string ID { get; set; }
    
        public string KhachHangSDT { get; set; }
        public DateTime NgayBan { get; set; }
        public double TongTien { get; set; }
        public int TrangThai { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string TrangThaiGetName
        {
            get
            {
                if (TrangThai == 0)
                {
                    return "Đang Giao";
                }
                else if(TrangThai==1)
                {
                    return "Đã giao";
                }
                else if (TrangThai == 2)
                {
                    return "Đã Thanh Toán";
                }
                else
                {
                    return "Bị Hủy";
                }
            } 
        }

    }
}
