

namespace Common.Entities

{

    public class NhanVienmodel
    {
       


        public int Id { get; set; }

        public string TenNHanVien { get; set; }
        public int GioiTinh { get; set; }
        public string GioiTinhGetname
        {
            get
            {
                if (GioiTinh == 0)
                {
                    return "Nam";
                }
                else if (GioiTinh == 1)
                {
                    return "Nữ";
                }
                else
                {
                    return " không xác định";
                }
            }
        }


        public string CCCD { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public int ChucVu { get; set; }
        public int TinhTrang { get; set; }
        public string? TinhTrangGetname
        {
            get
            {
                if (TinhTrang == 0)
                {
                    return "Đang làm việc";
                }
                else if (GioiTinh == 1)
                {
                    return "Đã nghỉ viêc";
                }
                else
                {
                    return " Đã nghỉ hưu";
                }
            }


        }
        public string? ChucVuGetname
        {
            get
            {
                if (TinhTrang == 0)
                {
                    return "Quản Lý";
                }
                else if (GioiTinh == 1)
                {
                    return "Nhân Viên Bán Hàng";
                }
                else
                {
                    return "Nhân Viên Giao Hàng";
                }
            }


        }
        public DateTime NgaySinh { get; set; }
    }
}