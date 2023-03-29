using System.Data.SqlClient;
using System.Data;

using api.Log;
using Common.Entities;
namespace api.Soure_Data
{
    public class Connext
    {
        private string m_ConnectionString;
        private SqlCommand _sqlCommand = new SqlCommand();
        private SqlConnection conn;
        public Connext(string strConnectionString)
        {
            this.m_ConnectionString = strConnectionString;

        }
        public bool _OpenConnection()
        {
            bool functionReturnValue = false;

            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    // CHUA OPEN roi thi tao new connection
                    conn = new SqlConnection(this.m_ConnectionString);
                    conn.Open();
                    functionReturnValue = true;
                }
                else
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        // OPEN roi thi ko tao connection nua
                        functionReturnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                functionReturnValue = false;

            }
            return functionReturnValue;
        }
        public void _CloseConnection()
        {
            try
            {
                if ((conn.State == ConnectionState.Open))
                {
                    conn.Close();
                    conn.Dispose();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }
        #region SanPham
        public List<SanPhammodel> GetAll_SanPham()
        {
            List<SanPhammodel> SanPhammodels = new List<SanPhammodel>();
            _sqlCommand.CommandText = "GetAll_SanPham";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
                    SanPhammodel sanPhammodel = new SanPhammodel();
                    sanPhammodel.Id = int.Parse(item["IdSanPham"].ToString());
                    sanPhammodel.TenSanPham = item["TenSanPham"].ToString();
                    sanPhammodel.DonGia = double.Parse(item["DonGia"].ToString());
                    sanPhammodel.KhuyenMai = float.Parse(item["KhuyenMai"].ToString());
                    sanPhammodel.GiaBan = double.Parse(item["GiaBan"].ToString());
                    sanPhammodel.MoTa = item["MoTa"].ToString();
                    sanPhammodel.Anh = item["Anh"].ToString();
                    sanPhammodel.TrangThai = int.Parse(item["TrangThai"].ToString());
                    sanPhammodel.Hang = item["HangSx"].ToString();
                    sanPhammodel.LoaiSp = item["Loai"].ToString();
                    sanPhammodel.Kho = item["TenKho"].ToString();
                    sanPhammodel.SoLuong = int.Parse(item["SoLuong"].ToString());
                    sanPhammodel.IdKho = int.Parse(item["KhoId"].ToString());
                    SanPhammodels.Add(sanPhammodel);
                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return SanPhammodels;

        }
        public List<SanPhammodel> GetAll_SanPhams()
        {
            List<SanPhammodel> SanPhammodels = new List<SanPhammodel>();
            _sqlCommand.CommandText = "GetAll_SanPhamS";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
                    SanPhammodel sanPhammodel = new SanPhammodel();
                    sanPhammodel.Id = int.Parse(item["IdSanPham"].ToString());
                    sanPhammodel.TenSanPham = item["TenSanPham"].ToString();
                    sanPhammodel.DonGia = double.Parse(item["DonGia"].ToString());
                    sanPhammodel.KhuyenMai = float.Parse(item["KhuyenMai"].ToString());
                    sanPhammodel.GiaBan = double.Parse(item["GiaBan"].ToString());
                    sanPhammodel.MoTa = item["MoTa"].ToString();
                    sanPhammodel.Anh = item["Anh"].ToString();
                    sanPhammodel.TrangThai = int.Parse(item["TrangThai"].ToString());
                    sanPhammodel.Hang = item["HangSx"].ToString();
                    sanPhammodel.LoaiSp = item["Loai"].ToString();
                    sanPhammodel.Kho = item["TenKho"].ToString();
                    sanPhammodel.SoLuong = int.Parse(item["SoLuong"].ToString());
                    sanPhammodel.IdKho = int.Parse(item["KhoId"].ToString());
                    SanPhammodels.Add(sanPhammodel);
                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return SanPhammodels;

        }
        public SanPhammodel GetAll_SanPham_ByID(int Id)
        {
            SanPhammodel sanPhammodel = new SanPhammodel();
            _sqlCommand.CommandText = "Get_SanPham";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@id", Id);
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
           
                    sanPhammodel.Id = int.Parse(item["IdSanPham"].ToString());
                    sanPhammodel.TenSanPham = item["TenSanPham"].ToString();
                    sanPhammodel.DonGia = double.Parse(item["DonGia"].ToString());
                    sanPhammodel.KhuyenMai = float.Parse(item["KhuyenMai"].ToString());
                    sanPhammodel.GiaBan = double.Parse(item["GiaBan"].ToString());
                    sanPhammodel.MoTa = item["MoTa"].ToString();
                    sanPhammodel.Anh = item["Anh"].ToString();
                    sanPhammodel.TrangThai = int.Parse(item["TrangThai"].ToString());
                    sanPhammodel.Hang = item["HangSx"].ToString();
                    sanPhammodel.LoaiSp = item["Loai"].ToString();
                    sanPhammodel.Kho = item["TenKho"].ToString();
                    sanPhammodel.SoLuong = int.Parse(item["SoLuong"].ToString());
                    sanPhammodel.IdKho = int.Parse(item["KhoId"].ToString());

                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return sanPhammodel;

        }
        //  _sqlCommand.CommandText = "Get_SanPham_ByHang";

        public List<SanPhammodel> GetAll_SanPham_ByHang(String hang)
        {
            List<SanPhammodel> SanPhammodels = new List<SanPhammodel>();
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@hang", hang);
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
                    SanPhammodel sanPhammodel = new SanPhammodel();
                    sanPhammodel.Id = int.Parse(item["IdSanPham"].ToString());
                    sanPhammodel.TenSanPham = item["TenSanPham"].ToString();
                    sanPhammodel.DonGia = double.Parse(item["DonGia"].ToString());
                    sanPhammodel.KhuyenMai = float.Parse(item["KhuyenMai"].ToString());
                    sanPhammodel.GiaBan = double.Parse(item["GiaBan"].ToString());
                    sanPhammodel.MoTa = item["MoTa"].ToString();
                    sanPhammodel.Anh = item["Anh"].ToString();
                    sanPhammodel.TrangThai = int.Parse(item["TrangThai"].ToString());
                    sanPhammodel.Hang = item["HangSx"].ToString();
                    sanPhammodel.LoaiSp = item["Loai"].ToString();
                    sanPhammodel.Kho = item["TenKho"].ToString();
                    sanPhammodel.SoLuong = int.Parse(item["SoLuong"].ToString());
                    SanPhammodels.Add(sanPhammodel);
                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return SanPhammodels;

        }
        public bool Them_SanPham(SanPhammodel sanPhammodel)
        {
          bool returnvalue=false;
            _sqlCommand.CommandText = "Insert_SanPham";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@TenSanPham", sanPhammodel.TenSanPham);
            _sqlCommand.Parameters.AddWithValue("@KhuyenMai", sanPhammodel.KhuyenMai);
            _sqlCommand.Parameters.AddWithValue("@dongia", sanPhammodel.DonGia);
            _sqlCommand.Parameters.AddWithValue("@GiaBan", sanPhammodel.GiaBan);
            _sqlCommand.Parameters.AddWithValue("@MoTa", sanPhammodel.MoTa);
            _sqlCommand.Parameters.AddWithValue("@hangsx", sanPhammodel.Hang);
            _sqlCommand.Parameters.AddWithValue("@loai", sanPhammodel.LoaiSp);
            _sqlCommand.Parameters.AddWithValue("@KhoId", sanPhammodel.IdKho);
            _sqlCommand.Parameters.AddWithValue("@Anh", sanPhammodel.Anh);
            _sqlCommand.Parameters.AddWithValue("@TrangThai", sanPhammodel.TrangThai);
            _sqlCommand.Parameters.AddWithValue("@soluong", sanPhammodel.SoLuong);
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();

                _sqlCommand.ExecuteNonQuery();
                /*this.m_dblDuration = DateTime.Now.Subtract(dtBegin).TotalMilliseconds; // duration*/
                _sqlCommand.Parameters.Clear();
                returnvalue = true;


            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return returnvalue;

        }
        public bool Sua_SanPham(SanPhammodel sanPhammodel)
        {
            bool returnvalue = false;
            _sqlCommand.CommandText = "Update_SanPham";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@idsanpham", sanPhammodel.Id);
            _sqlCommand.Parameters.AddWithValue("@TenSanPham", sanPhammodel.TenSanPham);
            _sqlCommand.Parameters.AddWithValue("@KhuyenMai", sanPhammodel.KhuyenMai);
            _sqlCommand.Parameters.AddWithValue("@dongia", sanPhammodel.DonGia);
            _sqlCommand.Parameters.AddWithValue("@GiaBan", sanPhammodel.GiaBan);
            _sqlCommand.Parameters.AddWithValue("@MoTa", sanPhammodel.MoTa);
            _sqlCommand.Parameters.AddWithValue("@hangsx", sanPhammodel.Hang);
            _sqlCommand.Parameters.AddWithValue("@loai", sanPhammodel.LoaiSp);
            _sqlCommand.Parameters.AddWithValue("@KhoId", sanPhammodel.IdKho);
            _sqlCommand.Parameters.AddWithValue("@Anh", sanPhammodel.Anh);
            _sqlCommand.Parameters.AddWithValue("@TrangThai", sanPhammodel.TrangThai);
            _sqlCommand.Parameters.AddWithValue("@soluong", sanPhammodel.SoLuong);
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();

                _sqlCommand.ExecuteNonQuery();
                /*this.m_dblDuration = DateTime.Now.Subtract(dtBegin).TotalMilliseconds; // duration*/
                _sqlCommand.Parameters.Clear();
                returnvalue = true;


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return returnvalue;

        }
        public bool Xoa_SanPham(int id, int trangthai)
        {
            bool returnvalue = false;
            _sqlCommand.CommandText = "Xoa_SanPham";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@idsanpham", id);
            _sqlCommand.Parameters.AddWithValue("@TrangThai", trangthai);
       
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();

                _sqlCommand.ExecuteNonQuery();
                /*this.m_dblDuration = DateTime.Now.Subtract(dtBegin).TotalMilliseconds; // duration*/
                _sqlCommand.Parameters.Clear();
                returnvalue = true;


            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return returnvalue;

        }
        public List<SanPhammodel> Fill_SanPham(SanPhammodel sanPhammodel)
        {
            List<SanPhammodel> SanPhammodels = new List<SanPhammodel>();
            _sqlCommand.CommandText = "Fill_SanPham";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;

            _sqlCommand.Parameters.AddWithValue("@ten", sanPhammodel.TenSanPham);
            _sqlCommand.Parameters.AddWithValue("@gia", sanPhammodel.GiaBan);
            _sqlCommand.Parameters.AddWithValue("@hang", sanPhammodel.Hang);
            _sqlCommand.Parameters.AddWithValue("@loai", sanPhammodel.LoaiSp);        
            _sqlCommand.Parameters.AddWithValue("@trangthai", sanPhammodel.TrangThai);

            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
                    SanPhammodel Add = new SanPhammodel();
                    Add.Id = int.Parse(item["IdSanPham"].ToString());
                    Add.TenSanPham = item["TenSanPham"].ToString();
                    Add.DonGia = double.Parse(item["DonGia"].ToString());
                    Add.KhuyenMai = float.Parse(item["KhuyenMai"].ToString());
                    Add.GiaBan = double.Parse(item["GiaBan"].ToString());
                    Add.MoTa = item["MoTa"].ToString();
                    Add.Anh = item["Anh"].ToString();
                    Add.TrangThai = int.Parse(item["TrangThai"].ToString());
                    Add.Hang = item["HangSx"].ToString();
                    Add.LoaiSp = item["Loai"].ToString();
                    Add.Kho = item["TenKho"].ToString();
                    Add.SoLuong = int.Parse(item["SoLuong"].ToString());
                    Add.IdKho = int.Parse(item["KhoId"].ToString());
                    SanPhammodels.Add(Add);
                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return SanPhammodels;

        }
        #endregion
        #region Nhân Viên
        public List<NhanVienmodel> GetAll_NhanViens()
        {
            List<NhanVienmodel> nhanVienmodel = new List<NhanVienmodel>();
            _sqlCommand.CommandText = "GetAll_NhanViens";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
                   NhanVienmodel add=new NhanVienmodel();
                    add.Id = int.Parse(item["IdNhanVien"].ToString());
                    add.TenNHanVien = item["TenNHanVien"].ToString();
                    add.CCCD= item["CCCD"].ToString();
                    add.SDT= item["SDT"].ToString();
                    add.DiaChi= item["DiaChi"].ToString();
                    add.ChucVu= int.Parse(item["ChucVu"].ToString());
                    add.GioiTinh= int.Parse(item["GioiTinh"].ToString());
                    add.TinhTrang= int.Parse(item["TinhTrang"].ToString());
                   add.NgaySinh= DateTime.Parse(item["NgaySinh"].ToString());
                    nhanVienmodel.Add(add);
                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return nhanVienmodel;

        }
        public NhanVienmodel Get_NhanVien(int id)
        {
         NhanVienmodel nhanVienmodel = new NhanVienmodel();
            _sqlCommand.CommandText = "Get_NhanVien";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@id", id);
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {

                    nhanVienmodel.Id = int.Parse(item["IdNhanVien"].ToString());
                    nhanVienmodel.TenNHanVien = item["TenNHanVien"].ToString();
                    nhanVienmodel.CCCD = item["CCCD"].ToString();
                    nhanVienmodel.SDT = item["SDT"].ToString();
                    nhanVienmodel.DiaChi = item["DiaChi"].ToString();
                    nhanVienmodel.ChucVu = int.Parse(item["ChucVu"].ToString());
                    nhanVienmodel.GioiTinh = int.Parse(item["GioiTinh"].ToString());
                    nhanVienmodel.TinhTrang = int.Parse(item["TinhTrang"].ToString());
                    nhanVienmodel.NgaySinh = DateTime.Parse(item["NgaySinh"].ToString());
           
                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return nhanVienmodel;

        }
        public bool Sua_NhanVien(NhanVienmodel nhanVienmodel)
        {
            bool returnvalue = false;
            _sqlCommand.CommandText = "Update_NhanVIen";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@idnhanvien", nhanVienmodel.Id);
            _sqlCommand.Parameters.AddWithValue("@ten", nhanVienmodel.TenNHanVien);
            _sqlCommand.Parameters.AddWithValue("@cccd", nhanVienmodel.CCCD);
            _sqlCommand.Parameters.AddWithValue("@sdt", nhanVienmodel.SDT);
            _sqlCommand.Parameters.AddWithValue("@diachi", nhanVienmodel.DiaChi);
            _sqlCommand.Parameters.AddWithValue("@chucvu", nhanVienmodel.ChucVu);
            _sqlCommand.Parameters.AddWithValue("@gioitinh", nhanVienmodel.GioiTinh);
            _sqlCommand.Parameters.AddWithValue("@tinhtrang", nhanVienmodel.TinhTrang);
            _sqlCommand.Parameters.AddWithValue("@ngaysinh", nhanVienmodel.NgaySinh);
           
           
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();

                _sqlCommand.ExecuteNonQuery();
                /*this.m_dblDuration = DateTime.Now.Subtract(dtBegin).TotalMilliseconds; // duration*/
                _sqlCommand.Parameters.Clear();
                returnvalue = true;


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return returnvalue;

        }
        public bool Them_NhanVien(NhanVienmodel nhanVienmodel)
        {
            bool returnvalue = false;
            _sqlCommand.CommandText = "Insert_NhanVien";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
          
            _sqlCommand.Parameters.AddWithValue("@ten", nhanVienmodel.TenNHanVien);
            _sqlCommand.Parameters.AddWithValue("@cccd", nhanVienmodel.CCCD);
            _sqlCommand.Parameters.AddWithValue("@sdt", nhanVienmodel.SDT);
            _sqlCommand.Parameters.AddWithValue("@diachi", nhanVienmodel.DiaChi);
            _sqlCommand.Parameters.AddWithValue("@chucvu", nhanVienmodel.ChucVu);
            _sqlCommand.Parameters.AddWithValue("@gioitinh", nhanVienmodel.GioiTinh);
            _sqlCommand.Parameters.AddWithValue("@tinhtrang", nhanVienmodel.TinhTrang);
            _sqlCommand.Parameters.AddWithValue("@ngaysinh", nhanVienmodel.NgaySinh);


            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();

                _sqlCommand.ExecuteNonQuery();
                /*this.m_dblDuration = DateTime.Now.Subtract(dtBegin).TotalMilliseconds; // duration*/
                _sqlCommand.Parameters.Clear();
                returnvalue = true;


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return returnvalue;

        }
        public List<NhanVienmodel> Fill_NhanVien(NhanVienmodel nhanVienmodel)
        {
            List<NhanVienmodel> nhanVienmodels = new List<NhanVienmodel>();
            _sqlCommand.CommandText = "Fill_NhanVien";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;

            _sqlCommand.Parameters.AddWithValue("@ten", nhanVienmodel.TenNHanVien);
            _sqlCommand.Parameters.AddWithValue("@cccd", nhanVienmodel.CCCD);
            
            _sqlCommand.Parameters.AddWithValue("@diachi", nhanVienmodel.DiaChi);
            _sqlCommand.Parameters.AddWithValue("@chucvu", nhanVienmodel.ChucVu);
            _sqlCommand.Parameters.AddWithValue("@gioitinh", nhanVienmodel.GioiTinh);
            _sqlCommand.Parameters.AddWithValue("@tinhtrang", nhanVienmodel.TinhTrang);
          
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
                    NhanVienmodel add = new NhanVienmodel();
                    add.Id = int.Parse(item["IdNhanVien"].ToString());
                    add.TenNHanVien = item["TenNHanVien"].ToString();
                    add.CCCD = item["CCCD"].ToString();
                    add.SDT = item["SDT"].ToString();
                    add.DiaChi = item["DiaChi"].ToString();
                    add.ChucVu = int.Parse(item["ChucVu"].ToString());
                    add.GioiTinh = int.Parse(item["GioiTinh"].ToString());
                    add.TinhTrang = int.Parse(item["TinhTrang"].ToString());
                    add.NgaySinh = DateTime.Parse(item["NgaySinh"].ToString());
                    nhanVienmodels.Add(add);
                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return nhanVienmodels;

        }
        #endregion
        #region Danh Muc San Pham
        public List<DanhMucSanPhammodel> GetAll_DanhMucSanPham()
        {
            List<DanhMucSanPhammodel> danhMucSanPhammodels = new List<DanhMucSanPhammodel>();
            _sqlCommand.CommandText = "GetAll_DanhMucSanPham";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
                    DanhMucSanPhammodel add = new DanhMucSanPhammodel();
                    add.Id = int.Parse(item["IdDanhMuc"].ToString());
                    add.HangSx = item["HangSx"].ToString();
                    add.Loai= item["Loai"].ToString();
                    danhMucSanPhammodels.Add(add);
                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return danhMucSanPhammodels;
        }
        public DanhMucSanPhammodel Get_DanhMucSanPham(int id)
        {
            DanhMucSanPhammodel danhMucSanPhammodels = new DanhMucSanPhammodel();
            _sqlCommand.CommandText = "Get_Danhmuc";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@id", id);
            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow item in dataTable.Rows)
                {
              
                    danhMucSanPhammodels.Id = int.Parse(item["IdDanhMuc"].ToString());
                    danhMucSanPhammodels.HangSx = item["HangSx"].ToString();
                    danhMucSanPhammodels.Loai = item["Loai"].ToString();
                   
                }

            }
            catch (Exception ex)
            {
                /*  Logerr log = new Logerr();
                  log.LogError(ex);*/
            }
            return danhMucSanPhammodels;
        }
        public bool Insert_DanhMucSanPham(DanhMucSanPhammodel danhMucSanPhammodel)
        {
            bool revalue = false;
            _sqlCommand.CommandText = "Insert_DanhMucSanPham";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;

            _sqlCommand.Parameters.AddWithValue("@loai", danhMucSanPhammodel.Loai);
            _sqlCommand.Parameters.AddWithValue("@hangsx", danhMucSanPhammodel.HangSx);
          


            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();

                _sqlCommand.ExecuteNonQuery();
                /*this.m_dblDuration = DateTime.Now.Subtract(dtBegin).TotalMilliseconds; // duration*/
                _sqlCommand.Parameters.Clear();
                revalue = true;


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return revalue;
        }
        public bool Update_DanhMucSanPham(DanhMucSanPhammodel danhMucSanPhammodel)
        {
            bool revalue = false;
            _sqlCommand.CommandText = "Update_DanhMucSanPham";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@iddanhmuc", danhMucSanPhammodel.Id);
            _sqlCommand.Parameters.AddWithValue("@loai", danhMucSanPhammodel.Loai);
            _sqlCommand.Parameters.AddWithValue("@hangsx", danhMucSanPhammodel.HangSx);



            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();

                _sqlCommand.ExecuteNonQuery();
                /*this.m_dblDuration = DateTime.Now.Subtract(dtBegin).TotalMilliseconds; // duration*/
                _sqlCommand.Parameters.Clear();
                revalue = true;


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return revalue;
        }
        #endregion
        #region Don Hang
        public List<DonHangmodel> GetAll_DonHang()
        {
            List<DonHangmodel> donHangmodels = new List<DonHangmodel>();
            _sqlCommand.CommandText = "GetAll_DonHang";
            _sqlCommand.CommandType= CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            try {
                SqlDataAdapter adapter = new SqlDataAdapter(_sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    DonHangmodel add=new DonHangmodel();
                    add.ID = item["IdDonHang"].ToString();
                    add.KhachHangSDT = item["KhachHangSDT"].ToString();
                    add.TenKH = item["TenKH"].ToString();
                    add.DiaChi = item["DiaChi"].ToString();
                    add.NgayBan = DateTime.Parse(item["NgayBan"].ToString());
                    add.TrangThai = int.Parse(item["TrangThai"].ToString());
                    add.TongTien = double.Parse(item["TongTien"].ToString());
                    donHangmodels.Add(add); 
                }
            } 
            catch(Exception)
            {
                return null;
            }
            return donHangmodels;
        }
        public DonHangmodel Get_DonHang(string id)
            {
            DonHangmodel donHangmodels = new DonHangmodel();
            _sqlCommand.CommandText = "Get_DonHang";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@id", id);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(_sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {

                    donHangmodels.ID = item["IdDonHang"].ToString();
                    donHangmodels.KhachHangSDT = item["KhachHangSDT"].ToString();
                    donHangmodels.TenKH = item["TenKH"].ToString();
                    donHangmodels.DiaChi = item["DiaChi"].ToString();
                    donHangmodels.NgayBan = DateTime.Parse(item["NgayBan"].ToString());
                    donHangmodels.TrangThai = int.Parse(item["TrangThai"].ToString());
                    donHangmodels.TongTien = double.Parse(item["TongTien"].ToString());
             
                }
            }
            catch (Exception)
            {
                return null;
            }
            return donHangmodels;
        }
        public List<ChiTietDonHangmodels> Get_DonHangChiTiet(string id)
        {
            List<ChiTietDonHangmodels> donHangmodels = new List<ChiTietDonHangmodels>();
            _sqlCommand.CommandText = "Get_DonHangChiTiet";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;
            _sqlCommand.Parameters.AddWithValue("@id", id);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(_sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    ChiTietDonHangmodels add = new ChiTietDonHangmodels();
                    add.Id = int.Parse(item["IdChiTietDH"].ToString());
                    add.SanPhamId = int.Parse(item["SanPhamId"].ToString());
                    add.GiaGoc = double.Parse(item["GiaGoc"].ToString());
                    add.GiamGia = float.Parse(item["GiamGia"].ToString());
                    add.GiaBan = double.Parse(item["GiaBan"].ToString());
                    add.DonHangID = item["DonHangID"].ToString();
                    add.BaoHanh = DateTime.Parse(item["BaoHanh"].ToString());
                    add.TenSP= item["TenSP"].ToString();
                    donHangmodels.Add(add);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return donHangmodels;
        }
        public bool Insert_DonHang(DonHangmodel donHangmodel)
        {
            bool returnvl=false;
            _sqlCommand.CommandText = "Insert_DonHang";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;

            _sqlCommand.Parameters.AddWithValue("@IdDonHang", donHangmodel.ID);
            _sqlCommand.Parameters.AddWithValue("@KhachHangSDT",donHangmodel.KhachHangSDT);
            _sqlCommand.Parameters.AddWithValue("@trangthai", donHangmodel.TrangThai);
            _sqlCommand.Parameters.AddWithValue("@TongTien", donHangmodel.TongTien);
            _sqlCommand.Parameters.AddWithValue("@NgayBan", donHangmodel.NgayBan);
            _sqlCommand.Parameters.AddWithValue("@tenkh", donHangmodel.TenKH);
            _sqlCommand.Parameters.AddWithValue("@diachi", donHangmodel.DiaChi);

            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();

                _sqlCommand.ExecuteNonQuery();
                /*this.m_dblDuration = DateTime.Now.Subtract(dtBegin).TotalMilliseconds; // duration*/
                _sqlCommand.Parameters.Clear();
                returnvl = true;


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return returnvl;
        }
        public bool Insert_ChiTietDonHang(ChiTietDonHangmodels chiTietDon)
        {
            bool returnvl = false;
            _sqlCommand.CommandText = "Insert_ChiTietDonHang";
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.Connection = conn;

            _sqlCommand.Parameters.AddWithValue("@DonHangID", chiTietDon.DonHangID);
            _sqlCommand.Parameters.AddWithValue("@BaoHanh", chiTietDon.BaoHanh);
            _sqlCommand.Parameters.AddWithValue("@tensp", chiTietDon.TenSP);
            _sqlCommand.Parameters.AddWithValue("@GiaGoc", chiTietDon.GiaGoc);
            _sqlCommand.Parameters.AddWithValue("@GiamGia", chiTietDon.GiamGia);
            _sqlCommand.Parameters.AddWithValue("@SanPhamId", chiTietDon.SanPhamId);
            _sqlCommand.Parameters.AddWithValue("@GiaBan", chiTietDon.GiaBan);


            try
            {
                //SanPhammodels=conn.Query<SanPhammodel>("GetAll_SanPhamS",commandType: CommandType.StoredProcedure).ToList();

                _sqlCommand.ExecuteNonQuery();
                /*this.m_dblDuration = DateTime.Now.Subtract(dtBegin).TotalMilliseconds; // duration*/
                _sqlCommand.Parameters.Clear();
                returnvl = true;


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return returnvl;
        }
        #endregion

        #region Khach Hang
        #endregion
    }
}
