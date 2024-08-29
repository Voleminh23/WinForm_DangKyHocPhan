using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DBKhoa
    {
        DAL db = null;
        public DBKhoa()
        {
            db = new DAL();
        }

        public void SinhVienConnect()
        {
            db.changeStrConnectToSinhVien();
        }

        public void GiangVienConnect()
        {
            db.changeStrConnectToGiangVien();
        }

        public int TongSVKhoa(String khoa)
        {
            string query = string.Format("SELECT dbo.RNO_TongSVKhoa(N'{0}')", khoa);
            return db.MyExecuteScalarFunction(query);
        }

        public DataSet DanhSachSVKhoa(String khoa)
        {
            string query = string.Format("SELECT * FROM dbo.RTM_DSSVKhoa(N'{0}')", khoa);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public DataSet DanhSachKhoa()
        {
            string query = "SELECT * FROM dbo.RTO_DanhSachKhoa()";
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public DataSet TimKiemKhoa(String khoa)
        {
            string query = string.Format("SELECT * FROM dbo.RTO_TimKiemKhoa(N'{0}')", khoa);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public bool ThemKhoa(ref string err, string MaKhoa, string TenKhoa)
        {
            return db.MyExecuteNonQuery("Re_ThemKhoa", CommandType.StoredProcedure,
                ref err, new SqlParameter("@MaKhoa", MaKhoa),
                new SqlParameter("@TenKhoa", TenKhoa));
        }

        public bool XoaKhoa(ref string err, string MaKhoa)
        {
            return db.MyExecuteNonQuery("Re_XoaKhoa", CommandType.StoredProcedure,
                ref err, new SqlParameter("@MaKhoa", MaKhoa));
        }
    }
}
