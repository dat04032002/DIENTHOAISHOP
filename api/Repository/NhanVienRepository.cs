using api.RepositoryInterface;
using api.Soure_Data;
using Common.Entities;
using Microsoft.AspNetCore.Hosting.Server;

namespace api.Repository
{
    public class NhanVienRepository : INhanVienRepository
    {
       private string connstr = "Server=DESKTOP-2U2U7UV\\SQLEXPRESS; Database=doAn; User ID=sa;Password=04032002;";

        public List<NhanVienmodel> Fill(NhanVienmodel nhanVienmodel)
        {
            Connext conn = new Connext(connstr);
            List<NhanVienmodel> nhanVienmodels = new List<NhanVienmodel>();
            if (conn._OpenConnection())
            {
                nhanVienmodels = conn.Fill_NhanVien(nhanVienmodel);
            }
            return nhanVienmodels;
        }

        public NhanVienmodel GetNhanVien(int id)
        {
            Connext  conn = new Connext(connstr);
            NhanVienmodel nhanVienmodel=new NhanVienmodel();
            if (conn._OpenConnection()){
                nhanVienmodel = conn.Get_NhanVien(id);
            }
            
            
            return nhanVienmodel;
        }

        public List<NhanVienmodel> GetNhanViens()
        {
            Connext conn = new Connext(connstr);
            List<NhanVienmodel> nhanVienmodels=new List<NhanVienmodel>();
            if (conn._OpenConnection())
            {
                nhanVienmodels = conn.GetAll_NhanViens();
            }
            return nhanVienmodels;
        }

        public bool InsertNhanVIen(NhanVienmodel nhanVien)
        {
            Connext connext = new Connext(connstr);
            bool revalue = false;
            if (connext._OpenConnection())
            {
                revalue = connext.Them_NhanVien(nhanVien);
            }
            return revalue;
        }

        public bool UpdateNhanVien(NhanVienmodel nhanVien)
        {
            Connext connext = new Connext(connstr);
            bool revalue = false;
            if (connext._OpenConnection())
            {
                revalue = connext.Sua_NhanVien(nhanVien);
            }
            return revalue;
        }
    }
}
