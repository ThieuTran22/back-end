using System.Data;

namespace back_end.Models
{

    public class NguoiDung
    {
        #region Prop and Init
        public NguoiDung() { }
        public NguoiDung(string taiKhoan, string matKhau, string hoVaTen, string tenHienThi, string soDienThoai, DateTime ngaySinh, long soDu, bool chucVu)
        {
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            HoVaTen = hoVaTen;
            TenHienThi = tenHienThi;
            SoDienThoai = soDienThoai;
            NgaySinh = ngaySinh;
            SoDu = soDu;
            ChucVu = chucVu;
        }

        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public string TenHienThi { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public long SoDu { get; set; }
        public bool ChucVu { get; set; }
        #endregion
        public List<NguoiDung> GetAll()
        {
            List<NguoiDung> nguoiDungs = new List<NguoiDung>();
            DataTable dt = cDatabase.GetTable("Select *from NguoiDung");
            for (int i = 0; i < dt.Rows.Count; i++) {
                nguoiDungs.Add(
                    new NguoiDung(
                        TaiKhoan = (string)dt.Rows[i][0],
                        MatKhau = (string)dt.Rows[i][1],
                        HoVaTen = (string)dt.Rows[i][2],
                        TenHienThi = (string)dt.Rows[i][3],
                        SoDienThoai = (string)dt.Rows[i][4],
                        NgaySinh = (DateTime)dt.Rows[i][5],
                        SoDu = (long)dt.Rows[i][6],
                        ChucVu = (bool)dt.Rows[i][7]
               ));
            }
            return nguoiDungs;
        }
        public NguoiDung GetById()
        {
            List<NguoiDung> nguoiDungs = new List<NguoiDung>();
            DataTable dt = cDatabase.GetTable($"Select *from NguoiDung where TaiKhoan='{TaiKhoan}'");
            return new NguoiDung(
                    TaiKhoan = (string)dt.Rows[0][0],
                    MatKhau = (string)dt.Rows[0][1],
                    HoVaTen = (string)dt.Rows[0][2],
                    TenHienThi = (string)dt.Rows[0][3],
                    SoDienThoai = (string)dt.Rows[0][4],
                    NgaySinh = (DateTime)dt.Rows[0][5],
                    SoDu = (long)dt.Rows[0][6],
                    ChucVu = (bool)dt.Rows[0][7]
           );
        }
    }


    public static class NguoiDungEndpoints
    {
        public static void MapNguoiDungEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/NguoiDung", () => {
                NguoiDung nguoiDungs = new NguoiDung();
                return nguoiDungs.GetAll();
            })
            .WithName("GetAllNguoiDungs");

            routes.MapGet("/api/NguoiDung/{taiKhoan}", (string taiKhoan) => {
                NguoiDung nguoiDung = new NguoiDung { TaiKhoan = taiKhoan };
                return nguoiDung.GetById();
            })
            .WithName("GetNguoiDungById");

            routes.MapPut("/api/NguoiDung/{id}", (string taiKhoan, NguoiDung input) => {
                try {

                    cDatabase.ExecuteCMD($"update NguoiDung set HoVaTen=N'{input.HoVaTen}',TenHienThi=N'{input.TenHienThi}', SoDienThoai='{input.SoDienThoai}', MatKhau = '{BCrypt.Net.BCrypt.HashPassword(input.MatKhau, BCrypt.Net.BCrypt.GenerateSalt())}', NgaySinh='{input.NgaySinh.ToString("MM-dd-yyyy")}' where TaiKhoan = '{taiKhoan}'");
                } catch (Exception) {

                    throw;
                }
            })
            .WithName("UpdateNguoiDung");

            routes.MapPost("/api/NguoiDung", (NguoiDung model) => {
                try {
                    cDatabase.ExecuteCMD("insert into NguoiDung(TaiKhoan,MatKhau,HoVaTen,TenHienThi,SoDienThoai,NgaySinh,SoDu,ChucVu) " +
                    $"values('{model.TaiKhoan}','{BCrypt.Net.BCrypt.HashPassword(model.MatKhau, BCrypt.Net.BCrypt.GenerateSalt())}',N'{model.HoVaTen}',N'{model.TenHienThi}','{model.SoDienThoai}'," +
                    $"'{model.NgaySinh.ToString("MM-dd-yyyy")}',{model.SoDu},'{model.ChucVu}')");
                } catch (Exception e) {
                    Console.WriteLine(e);
                    return false;
                }
                return true;
            })
            .WithName("CreateNguoiDung");

            routes.MapDelete("/api/NguoiDung/{id}", (string taiKhoan) => {
                cDatabase.ExecuteCMD($"Delete NguoiDung where TaiKhoan = '{taiKhoan}'");
            })
            .WithName("DeleteNguoiDung");

            routes.MapPost("/api/NguoiDung/CheckLogin", (string taiKhoan, string matKhau) => {

                DataTable db = cDatabase.GetTable($"select *from NguoiDung where taikhoan='{taiKhoan}'");
                if (db.Rows.Count == 0) return false;

                // Kiểm tra mật khẩu
                bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(matKhau, db.Rows[0][1].ToString()!);
                return isPasswordCorrect;
            })
            .WithName("CheckLogin");
        }
    }


}
