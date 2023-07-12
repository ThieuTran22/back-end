using System.Data;

namespace back_end.Models
{
    public class ThuMucChuDe
    {
        #region Prop and Init
        public ThuMucChuDe() { }
        public ThuMucChuDe(int maThuMucChuDe, string tenThuMucChuDe, string taiKhoan)
        {
            MaThuMucChuDe = maThuMucChuDe;
            TenThuMucChuDe = tenThuMucChuDe;
            TaiKhoan = taiKhoan;
        }

        public int MaThuMucChuDe { get; set; }
        public string TenThuMucChuDe { get; set; }
        public string TaiKhoan { get; set; }
        #endregion
        public List<ThuMucChuDe> GetAll()
        {
            List<ThuMucChuDe> thuMucChuDes = new List<ThuMucChuDe>();
            DataTable dt = cDatabase.GetTable($"Select *from ThuMucChuDe");
            for (int i = 0; i < dt.Rows.Count; i++) {
                thuMucChuDes.Add(
                    new ThuMucChuDe(
                        MaThuMucChuDe = (int)dt.Rows[i][0],
                        TenThuMucChuDe = (string)dt.Rows[i][1],
                        TaiKhoan = (string)dt.Rows[i][2]
               ));
            }
            return thuMucChuDes;
        }
        public List<ThuMucChuDe> GetAllById()
        {
            List<ThuMucChuDe> thuMucChuDes = new List<ThuMucChuDe>();
            DataTable dt = cDatabase.GetTable($"Select *from ThuMucChuDe where TaiKhoan ='{TaiKhoan}'");
            for (int i = 0; i < dt.Rows.Count; i++) {
                thuMucChuDes.Add(
                    new ThuMucChuDe(
                        MaThuMucChuDe = (int)dt.Rows[i][0],
                        TenThuMucChuDe = (string)dt.Rows[i][1],
                        TaiKhoan = (string)dt.Rows[i][2]
               ));
            }
            return thuMucChuDes;
        }
        public ThuMucChuDe GetById()
        {
            DataTable dt = cDatabase.GetTable("select *from ThuMucChuDe where MaThuMucChuDe = " + MaThuMucChuDe);
            ThuMucChuDe thuMucChuDe = new ThuMucChuDe((int)dt.Rows[0][0], (string)dt.Rows[0][1], (string)dt.Rows[0][2]);
            return thuMucChuDe;
        }
    }


    public static class ThuMucChuDeEndpoints
    {
        public static void MapThuMucChuDeEndpoints(this IEndpointRouteBuilder routes)
        {
            #region Gets
            routes.MapGet("/api/ThuMucChuDe", () => {
                return new ThuMucChuDe().GetAll();
            })
            .WithName("GetAllThuMucChuDes");

            routes.MapGet("/api/ThuMucChuDe/{id}", (int id) => {
                return new ThuMucChuDe { MaThuMucChuDe = id }.GetById();
            })
            .WithName("GetThuMucChuDeById");

            routes.MapGet("/api/ThuMucChuDe/GetAll/{taiKhoan}", (string taiKhoan) => {
                return new ThuMucChuDe { TaiKhoan = taiKhoan }.GetAllById();
            })
            .WithName("GetAllThuMucChuDeById");
            #endregion

            #region Actions
            routes.MapPut("/api/ThuMucChuDe/{id}", (int id, ThuMucChuDe input) => {
                cDatabase.ExecuteCMD($"update ThuMucChuDe set TenThuMucChuDe = " +
                    $"N'{input.TenThuMucChuDe}' where MaThuMucChuDe =" + id);
            })
            .WithName("UpdateThuMucChuDe");

            routes.MapPost("/api/ThuMucChuDe", (ThuMucChuDe model) => {
                DataTable dt = cDatabase.GetTable($"select *from ThuMucChuDe where TaiKhoan='{model.TaiKhoan}' " +
                    $"and TenThuMucChuDe='{model.TenThuMucChuDe}'");
                if (dt.Rows.Count > 0)
                    return false;
                cDatabase.ExecuteCMD($"insert into ThuMucChuDe(TenThuMucChuDe,TaiKhoan) " +
                    $"values(N'{model.TenThuMucChuDe}','{model.TaiKhoan}')");
                return true;
            })
            .WithName("CreateThuMucChuDe");

            routes.MapDelete("/api/ThuMucChuDe/{id}", (int id) => {
                cDatabase.ExecuteCMD($"delete ThuMucChuDe where MaThuMucChuDe ='{id}'");
            })
            .WithName("DeleteThuMucChuDe");
            #endregion
        }
    }
}
