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
    public class DBLopHoc
    {
        DAL db = null;
        public DBLopHoc()
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

        public DataSet DSLopHoc()
        {
            return db.ExecuteQueryDataSet("NonP_DanhSachLopHoc", CommandType.StoredProcedure);
        }

        public DataSet TimLopHoc(string malh)
        {
            return db.ExecuteQueryDataSetParam("HasP_TimKiemLop", CommandType.StoredProcedure, new SqlParameter("@malop", malh));
        }

        public bool ThemLopHoc(ref string err, string MaLopHoc, string MaMHDT, string MaGV, int GioiHan, string Phong, string Thu, int TietBatDau, int TietKetThuc, string ThoiGianBatDau, string ThoiGianKetThuc, string HocKy, int Nam)
        {
            return db.MyExecuteNonQuery("Re_ThemLopHoc", CommandType.StoredProcedure,
                ref err, new SqlParameter("@MaLopHoc", MaLopHoc),
                new SqlParameter("@MaMHDT", MaMHDT),
                new SqlParameter("@MaGV", MaGV),
                new SqlParameter("@GioiHan", GioiHan),
                new SqlParameter("@Phong", Phong),
                new SqlParameter("@Thu", Thu),
                new SqlParameter("@TietBatDau", TietBatDau),
                new SqlParameter("@TietKetThuc", TietKetThuc),
                new SqlParameter("@ThoiGianBatDau", ThoiGianBatDau),
                new SqlParameter("@ThoiGianKetThuc", ThoiGianKetThuc),
                new SqlParameter("@HocKy", HocKy),
                new SqlParameter("@Nam", Nam));
        }

        public bool XoaLopHoc(ref string err, string malh)
        {
            return db.MyExecuteNonQuery("Re_XoaLopHoc", CommandType.StoredProcedure,
                ref err, new SqlParameter("@MaLopHoc", malh));
        }

        public DataSet TimKiemLopHocTheoMH(string mamh)
        {
            string query = string.Format("SELECT * FROM dbo.RTM_TimKiemLopHocTheoMon(N'{0}')", mamh);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public DataSet ThoiKhoaBieuSV(string masv)
        {
            string query = string.Format("SELECT * FROM dbo.RTM_XemTKB(N'{0}')", masv);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public DataSet ThoiKhoaBieuGV(string magv)
        {
            string query = string.Format("SELECT * FROM dbo.RTM_XemTKBGV(N'{0}')", magv);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public DataSet ChiTietLopHocGV(string magv)
        {
            string query = string.Format("SELECT * FROM dbo.RTM_ChiTietLHGV(N'{0}')", magv);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public DataSet DanhSachSVLH(string malh)
        {
            string query = string.Format("SELECT * FROM dbo.RTO_DanhSachSVLopHoc(N'{0}')", malh);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        public int TongSVLopHoc(string malh)
        {
            string query = string.Format("SELECT dbo.RNO_TongSVLopHoc(N'{0}')", malh);
            return Convert.ToInt32(db.MyExecuteScalarFunction(query));
        }

        public DataSet DanhSachLH(string malh, string masv)
        {
            string query = string.Format("SELECT * FROM dbo.RTM_TimKiemLHDK(N'{0}', N'{1}')", malh, masv);
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }
    }
}
