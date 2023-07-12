using System.Data;

namespace back_end.Models
{
    public class MonHoc
    {
        #region prop and init
        public MonHoc() { }
        public MonHoc(int maMonHoc, string tenMonHoc)
        {
            MaMonHoc = maMonHoc;
            TenMonHoc = tenMonHoc;
        }

        public int MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        #endregion
        public List<MonHoc> GetAll()
        {
            List<MonHoc> monHocs = new List<MonHoc>();
            DataTable dt = cDatabase.GetTable($"Select *from MonHoc");
            for (int i = 0; i < dt.Rows.Count; i++) {
                monHocs.Add(
                    new MonHoc(
                                   MaMonHoc = (int)dt.Rows[i][0],
                                   TenMonHoc = (string)dt.Rows[i][1]
               ));
            }
            return monHocs;
        }
    }


    public static class MonHocEndpoints
    {
        public static void MapMonHocEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/MonHoc", () => {
                return new MonHoc().GetAll();
            })
            .WithName("GetAllMonHocs");

            routes.MapPut("/api/MonHoc/{id}", (int id, MonHoc input) => {
                cDatabase.ExecuteCMD($"update MonHoc set TenMonHoc=N'{input.TenMonHoc}' where MaMonHoc =" + id);
            })
            .WithName("UpdateMonHoc");

            routes.MapPost("/api/MonHoc/", (MonHoc model) => {
                if (cDatabase.GetTable($"select *from MonHoc where TenMonHoc ='{model.TenMonHoc}'").Rows.Count > 0)
                    return false;
                cDatabase.ExecuteCMD($"insert into MonHoc(TenMonHoc) values(N'{model.TenMonHoc}')");
                return true;
            })
            .WithName("CreateMonHoc");

            routes.MapDelete("/api/MonHoc/{id}", (int id) => {
                //return Results.Ok(new MonHoc { ID = id });
            })
            .WithName("DeleteMonHoc");
        }
    }
}
