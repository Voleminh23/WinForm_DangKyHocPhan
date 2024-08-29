using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class DBNganh
    {
        DAL db = null;
        public DBNganh()
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

        public int TongSVNganh(string nganh)
        {
            string query = string.Format("SELECT dbo.RNO_TongSVNganh(N'{0}')", nganh);
            return Convert.ToInt32(db.MyExecuteScalarFunction(query));
        }

        public DataSet DanhSachSVNganh(string nganh)
        {
            string query = string.Format("SELECT * FROM dbo.RTM_DSSVNganh(N'{0}')", nganh);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public DataSet TimKiemNganh(string nganh)
        {
            string query = string.Format("SELECT * FROM dbo.RTO_TimKiemNganh(N'{0}')", nganh);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public DataSet DanhSachNganh()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM dbo.RTO_DanhSachNganh()", CommandType.Text);
        }

        public bool ThemNganh(ref string err, string MaNganh, string TenNganh, string MaKhoa)
        {
            return db.MyExecuteNonQuery("Re_ThemNganh", CommandType.StoredProcedure,
                ref err, new SqlParameter("@MaNganh", MaNganh),
                new SqlParameter("@TenNganh", TenNganh),
                new SqlParameter("@MaKhoa", MaKhoa));
        }

        public bool XoaNganh(ref string err, string MaNganh)
        {
            return db.MyExecuteNonQuery("Re_XoaNganh", CommandType.StoredProcedure,
                ref err, new SqlParameter("@MaNganh", MaNganh));
        }
    }
}
