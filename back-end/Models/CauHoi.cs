using System.Data;

namespace back_end.Models
{
    public class CauHoi
    {
        public CauHoi() { }
        public CauHoi(int maCauHoi, string noiDungCauHoi, string hinhAnh, string giaiThich, int maBoCauHoi)
        {
            MaCauHoi = maCauHoi;
            NoiDungCauHoi = noiDungCauHoi;
            HinhAnh = hinhAnh;
            GiaiThich = giaiThich;
            MaBoCauHoi = maBoCauHoi;
        }

        public int MaCauHoi { get; set; }
        public string NoiDungCauHoi { get; set; }
        public string HinhAnh { get; set; }
        public string GiaiThich { get; set; }
        public int MaBoCauHoi { get; set; }
        public List<CauHoi> GetAll()
        {
            List<CauHoi> cauHois = new List<CauHoi>();
            DataTable dt = cDatabase.GetTable("Select *from CauHoi");
            for (int i = 0; i < dt.Rows.Count; i++) {
                cauHois.Add(
                    new CauHoi(
                         MaCauHoi = (int)dt.Rows[i][0],
                        NoiDungCauHoi = (string)dt.Rows[i][1],
                        HinhAnh = (string)dt.Rows[i][2],
                        GiaiThich = (string)dt.Rows[i][3],
                        MaBoCauHoi = (int)dt.Rows[i][4]
                  )
               );
            }
            return cauHois;
        }
        public List<CauHoi> GetAllById()
        {
            List<CauHoi> cauHois = new List<CauHoi>();
            DataTable dt = cDatabase.GetTable("Select *from CauHoi where MaBoCauHoi=" + MaBoCauHoi);
            for (int i = 0; i < dt.Rows.Count; i++) {
                cauHois.Add(
                    new CauHoi(
                         MaCauHoi = (int)dt.Rows[i][0],
                        NoiDungCauHoi = (string)dt.Rows[i][1],
                        HinhAnh = (string)dt.Rows[i][2],
                        GiaiThich = (string)dt.Rows[i][3],
                        MaBoCauHoi = (int)dt.Rows[i][4]
                  )
               );
            }
            return cauHois;
        }
        public List<CauHoi> GetAllByIdRandom()
        {
            List<CauHoi> cauHois = new List<CauHoi>();
            DataTable dt = cDatabase.GetTable("Select *from CauHoi where MaBoCauHoi=" + MaBoCauHoi);
            for (int i = 0; i < dt.Rows.Count; i++) {
                cauHois.Add(
                    new CauHoi(
                         MaCauHoi = (int)dt.Rows[i][0],
                        NoiDungCauHoi = (string)dt.Rows[i][1],
                        HinhAnh = (string)dt.Rows[i][2],
                        GiaiThich = (string)dt.Rows[i][3],
                        MaBoCauHoi = (int)dt.Rows[i][4]
                  )
               );
            }
            cauHois = cauHois.OrderBy(a => Guid.NewGuid()).ToList();
            return cauHois;
        }
        public CauHoi GetById()
        {
            DataTable dt = cDatabase.GetTable("Select *from CauHoi where MaCauHoi=" + MaCauHoi);
            return new CauHoi(
                         MaCauHoi = (int)dt.Rows[0][0],
                        NoiDungCauHoi = (string)dt.Rows[0][1],
                        HinhAnh = (string)dt.Rows[0][2],
                        GiaiThich = (string)dt.Rows[0][3],
                        MaBoCauHoi = (int)dt.Rows[0][4]
                  );
        }
    }


    public static class CauHoiEndpoints
    {
        public static void MapCauHoiEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/CauHoi", () => {
                return new CauHoi().GetAll();
            })
            .WithName("GetAllCauHois");

            routes.MapGet("/api/CauHoi/{id}", (int id) => {
                return new CauHoi { MaCauHoi = id }.GetById();
            })
            .WithName("GetCauHoiById");

            routes.MapGet("/api/CauHoi/GetAll/{id}", (int id) => {
                return new CauHoi { MaBoCauHoi = id }.GetAllById();
            })
            .WithName("GetAllCauHoiById");

            routes.MapGet("/api/CauHoi/GetAllRandom/{id}", (int id) => {
                return new CauHoi { MaBoCauHoi = id }.GetAllByIdRandom();
            })
            .WithName("GetAllCauHoiByIdRandom");

            routes.MapPut("/api/CauHoi/{id}", (int id, CauHoi input) => {
                cDatabase.ExecuteCMD($"Update CauHoi set NoiDungCauHoi=N'{input.NoiDungCauHoi}',HinhAnh='{input.HinhAnh}',GiaiThich =N'{input.GiaiThich}' where MaCauHoi=" + id);
            })
            .WithName("UpdateCauHoi");

            routes.MapPost("/api/CauHoi/", (CauHoi model) => {
                try {
                    cDatabase.ExecuteCMD($"Insert into CauHoi(NoiDungCauHoi,HinhAnh,GiaiThich,MaBoCauHoi) " +
                    $"values(N'{model.NoiDungCauHoi}','{model.HinhAnh}',N'{model.GiaiThich}',{model.MaBoCauHoi})");
                } catch (Exception) {
                    return false;
                }
                return true;
            })
            .WithName("CreateCauHoi");

            routes.MapDelete("/api/CauHoi/{id}", (int id) => {
                cDatabase.ExecuteCMD($"delete from CauHoi where MaCauHoi =" + id);
            })
            .WithName("DeleteCauHoi");
        }
    }
}
