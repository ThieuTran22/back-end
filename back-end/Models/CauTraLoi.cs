using System.Data;

namespace back_end.Models
{
    public class CauTraLoi
    {
        public CauTraLoi() { }
        public CauTraLoi(int maCauTraLoi, string noiDungCauTraLoi, bool dungSai, int maCauHoi)
        {
            MaCauTraLoi = maCauTraLoi;
            NoiDungCauTraLoi = noiDungCauTraLoi;
            DungSai = dungSai;
            MaCauHoi = maCauHoi;
        }

        public int MaCauTraLoi { get; set; }
        public string NoiDungCauTraLoi { get; set; }
        public bool DungSai { get; set; }
        public int MaCauHoi { get; set; }
        public List<CauTraLoi> GetAll()
        {
            List<CauTraLoi> cauTraLois = new List<CauTraLoi>();
            DataTable dt = cDatabase.GetTable("Select *from CauTraLoi");
            for (int i = 0; i < dt.Rows.Count; i++) {
                cauTraLois.Add(
                    new CauTraLoi(
                            MaCauTraLoi = (int)dt.Rows[i][0],
                            NoiDungCauTraLoi = (string)dt.Rows[i][1],
                            DungSai = (bool)dt.Rows[i][2],
                            MaCauHoi = (int)dt.Rows[i][3]
                  )
               );
            }
            return cauTraLois;
        }
        public List<CauTraLoi> GetAllById()
        {
            List<CauTraLoi> cauTraLois = new List<CauTraLoi>();
            DataTable dt = cDatabase.GetTable("Select *from CauTraLoi where MaCauHoi=" + MaCauHoi);
            for (int i = 0; i < dt.Rows.Count; i++) {
                cauTraLois.Add(
                    new CauTraLoi(
                            MaCauTraLoi = (int)dt.Rows[i][0],
                            NoiDungCauTraLoi = (string)dt.Rows[i][1],
                            DungSai = (bool)dt.Rows[i][2],
                            MaCauHoi = (int)dt.Rows[i][3]
                  )
               );
            }
            return cauTraLois;
        }
        public List<CauTraLoi> GetAllByIdRandom()
        {
            List<CauTraLoi> cauTraLois = new List<CauTraLoi>();
            DataTable dt = cDatabase.GetTable("Select *from CauTraLoi where MaCauHoi=" + MaCauHoi);
            for (int i = 0; i < dt.Rows.Count; i++) {
                cauTraLois.Add(
                    new CauTraLoi(
                            MaCauTraLoi = (int)dt.Rows[i][0],
                            NoiDungCauTraLoi = (string)dt.Rows[i][1],
                            DungSai = (bool)dt.Rows[i][2],
                            MaCauHoi = (int)dt.Rows[i][3]
                  )
               );
            }
            cauTraLois = cauTraLois.OrderBy(a => Guid.NewGuid()).ToList();
            return cauTraLois;
        }
    }


    public static class CauTraLoiEndpoints
    {
        public static void MapCauTraLoiEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/CauTraLoi", () => {
                return new CauTraLoi().GetAll();
            })
            .WithName("GetAllCauTraLois");

            routes.MapGet("/api/CauTraLoi/GetAll/{id}", (int id) => {
                return new CauTraLoi { MaCauHoi = id }.GetAllById();
            })
            .WithName("GetAllCauTraLoiById");

            routes.MapGet("/api/CauTraLoi/GetAllRandom/{id}", (int id) => {
                return new CauTraLoi { MaCauHoi = id }.GetAllByIdRandom();
            })
            .WithName("GetAllCauTraLoiByIdRandom");

            routes.MapPut("/api/CauTraLoi/{id}", (int id, CauTraLoi input) => {
                cDatabase.ExecuteCMD($"update CauTraLoi set NoiDungCauTraLoi=N'{input.NoiDungCauTraLoi}', DungSai ='{input.DungSai}' where MaCauTraLoi=" + id);
            })
            .WithName("UpdateCauTraLoi");

            routes.MapPost("/api/CauTraLoi/", (CauTraLoi model) => {
                cDatabase.ExecuteCMD($"Insert into CauTraLoi(NoiDungCauTraLoi,DungSai,MaCauHoi) " +
                    $"values(N'{model.NoiDungCauTraLoi}','{model.DungSai}',{cDatabase.GetTable("Select max(MaCauHoi) from CauHoi").Rows[0][0]})");
            })
            .WithName("CreateCauTraLoi");

            routes.MapDelete("/api/CauTraLoi/{id}", (int id) => {
                cDatabase.ExecuteCMD($"delete from CauTraLoi where MaCauTraLoi=" + id);
            })
            .WithName("DeleteCauTraLoi");
        }
    }
}
