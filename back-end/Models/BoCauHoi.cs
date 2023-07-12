using System.Data;

namespace back_end.Models
{
    public class BoCauHoi
    {
        #region Prop and Init
        public BoCauHoi() { }
        public BoCauHoi(int maBoCauHoi, string tenBoCauHoi, string hinhAnh, int thoiGianLamBai, double soDiemDau, long giaBan, string gioiThieu, int maMonHoc, int maThuMucChuDe, bool dangDuocBan)
        {
            MaBoCauHoi = maBoCauHoi;
            TenBoCauHoi = tenBoCauHoi;
            HinhAnh = hinhAnh;
            ThoiGianLamBai = thoiGianLamBai;
            SoDiemDau = soDiemDau;
            GiaBan = giaBan;
            GioiThieu = gioiThieu;
            MaMonHoc = maMonHoc;
            MaThuMucChuDe = maThuMucChuDe;
            DangDuocBan = dangDuocBan;
        }

        public int MaBoCauHoi { get; set; }
        public string TenBoCauHoi { get; set; }
        public string HinhAnh { get; set; }
        public int ThoiGianLamBai { get; set; }
        public double SoDiemDau { get; set; }
        public long GiaBan { get; set; }
        public string GioiThieu { get; set; }
        public int MaMonHoc { get; set; }
        public int MaThuMucChuDe { get; set; }
        public bool DangDuocBan { get; set; }
        #endregion
        public List<BoCauHoi> GetAll()
        {
            List<BoCauHoi> boCauHois = new List<BoCauHoi>();
            DataTable dt = cDatabase.GetTable($"Select *from BoCauHoi");
            for (int i = 0; i < dt.Rows.Count; i++) {
                boCauHois.Add(
                    new BoCauHoi(
                        MaBoCauHoi = (int)dt.Rows[i][0],
                        TenBoCauHoi = (string)dt.Rows[i][1],
                        HinhAnh = (string)dt.Rows[i][2],
                        ThoiGianLamBai = (int)dt.Rows[i][3],
                        SoDiemDau = (double)dt.Rows[i][4],
                        GiaBan = (long)dt.Rows[i][5],
                        GioiThieu = (string)dt.Rows[i][6],
                        MaMonHoc = (int)dt.Rows[i][7],
                        MaThuMucChuDe = (int)dt.Rows[i][8],
                        DangDuocBan = (bool)dt.Rows[i][9]
               ));
            }
            return boCauHois;
        }
        public List<BoCauHoi> GetAllDangDuocBan()
        {
            List<BoCauHoi> boCauHois = new List<BoCauHoi>();
            DataTable dt = cDatabase.GetTable($"Select *from BoCauHoi where DangDuocBan=1");
            for (int i = 0; i < dt.Rows.Count; i++) {
                boCauHois.Add(
                    new BoCauHoi(
                        MaBoCauHoi = (int)dt.Rows[i][0],
                        TenBoCauHoi = (string)dt.Rows[i][1],
                        HinhAnh = (string)dt.Rows[i][2],
                        ThoiGianLamBai = (int)dt.Rows[i][3],
                        SoDiemDau = (double)dt.Rows[i][4],
                        GiaBan = (long)dt.Rows[i][5],
                        GioiThieu = (string)dt.Rows[i][6],
                        MaMonHoc = (int)dt.Rows[i][7],
                        MaThuMucChuDe = (int)dt.Rows[i][8],
                        DangDuocBan = (bool)dt.Rows[i][9]
               ));
            }
            return boCauHois;
        }
        public List<BoCauHoi> GetAllById()
        {
            List<BoCauHoi> boCauHois = new List<BoCauHoi>();
            DataTable dt = cDatabase.GetTable($"Select *from BoCauHoi where MaThuMucChuDe=" + MaThuMucChuDe);
            for (int i = 0; i < dt.Rows.Count; i++) {
                boCauHois.Add(
                    new BoCauHoi(
                        MaBoCauHoi = (int)dt.Rows[i][0],
                        TenBoCauHoi = (string)dt.Rows[i][1],
                        HinhAnh = (string)dt.Rows[i][2],
                        ThoiGianLamBai = (int)dt.Rows[i][3],
                        SoDiemDau = (double)dt.Rows[i][4],
                        GiaBan = (long)dt.Rows[i][5],
                        GioiThieu = (string)dt.Rows[i][6],
                        MaMonHoc = (int)dt.Rows[i][7],
                        MaThuMucChuDe = (int)dt.Rows[i][8],
                        DangDuocBan = (bool)dt.Rows[i][9]
               ));
            }
            return boCauHois;
        }

        public BoCauHoi GetById()
        {
            DataTable dt = cDatabase.GetTable($"Select *from BoCauHoi where MaBoCauHoi=" + MaBoCauHoi);
            BoCauHoi boCauHoi = new BoCauHoi(
                        MaBoCauHoi = (int)dt.Rows[0][0],
                        TenBoCauHoi = (string)dt.Rows[0][1],
                        HinhAnh = (string)dt.Rows[0][2],
                        ThoiGianLamBai = (int)dt.Rows[0][3],
                        SoDiemDau = (double)dt.Rows[0][4],
                        GiaBan = (long)dt.Rows[0][5],
                        GioiThieu = (string)dt.Rows[0][6],
                        MaMonHoc = (int)dt.Rows[0][7],
                        MaThuMucChuDe = (int)dt.Rows[0][8],
                        DangDuocBan = (bool)dt.Rows[0][9]);
            return boCauHoi;
        }
    }


    public static class BoCauHoiEndpoints
    {
        public static void MapBoCauHoiEndpoints(this IEndpointRouteBuilder routes)
        {
            #region Gets
            routes.MapGet("/api/BoCauHoi", () => {
                return new BoCauHoi().GetAll();
            })
            .WithName("GetAllBoCauHois");

            routes.MapGet("/api/BoCauHoi/DangDuocBan", () => {
                return new BoCauHoi().GetAllDangDuocBan();
            })
            .WithName("GetAllBoCauHoisDangDuocBan");


            routes.MapGet("/api/BoCauHoi/{id}", (int id) => {
                return new BoCauHoi { MaBoCauHoi = id }.GetById();
            })
            .WithName("GetBoCauHoiById");

            routes.MapGet("/api/BoCauHoi/GetAll/{id}", (int id) => {
                return new BoCauHoi { MaThuMucChuDe = id }.GetAllById();
            })
            .WithName("GetAllBoCauHoiById");
            #endregion

            #region Actions
            routes.MapPut("/api/BoCauHoi/{id}", (int id, BoCauHoi input) => {
                cDatabase.ExecuteCMD($"Update BoCauHoi set  TenBoCauHoi = N'{input.TenBoCauHoi}', " +
                    $"HinhAnh = '{input.HinhAnh}', ThoiGianLamBai = {input.ThoiGianLamBai}, " +
                    $"SoDiemDau = {input.SoDiemDau}, GiaBan = {input.GiaBan}, " +
                    $"GioiThieu = N'{input.GioiThieu}', MaMonHoc = {input.MaMonHoc}, " +
                    $"MaThuMucChuDe = {input.MaThuMucChuDe}, DangDuocBan = {input.DangDuocBan}");
            })
            .WithName("UpdateBoCauHoi");

            routes.MapPut("/api/BoCauHoi/UpdateBan/{id}", (int id, BoCauHoi input) => {
                cDatabase.ExecuteCMD($"Update BoCauHoi set  DangDuocBan='{input.DangDuocBan}', " +
                    $"GiaBan ='{input.GiaBan}' where MaBoCauHoi={id}");
            })
            .WithName("UpdateBanBoCauHoi");

            routes.MapPost("/api/BoCauHoi", (BoCauHoi model) => {
                try {
                    cDatabase.ExecuteCMD($"insert into BoCauHoi(tenBoCauHoi, hinhAnh, " +
                   $"thoiGianLamBai, soDiemDau,giaBan,gioiThieu, maMonHoc, maThuMucChuDe, DangDuocBan)" +
                   $"values(N'{model.TenBoCauHoi}', '{model.HinhAnh}',{model.ThoiGianLamBai}," +
                   $"{model.SoDiemDau},{model.GiaBan},N'{model.GioiThieu}', {model.MaMonHoc}, " +
                   $"{model.MaThuMucChuDe}, 0)");
                } catch (Exception e) {
                    Console.WriteLine(e);
                    return false;
                }
                return true;
            })
            .WithName("CreateBoCauHoi");

            routes.MapPost("/api/BoCauHoi/MuaBoCauHoi", (int maBoCauHoi, int maThuMucChuDe) => {
                try {
                    cDatabase.ExecuteCMD($"INSERT INTO BoCauHoi(TenBoCauHoi,HinhAnh,ThoiGianLamBai,SoDiemDau," +
                        $"GiaBan,GioiThieu,MaMonHoc,MaThuMucChuDe,DangDuocBan) \r\nSELECT TenBoCauHoi,HinhAnh," +
                        $"ThoiGianLamBai,SoDiemDau,-1,GioiThieu,MaMonHoc,{maThuMucChuDe},0\r\nFROM BoCauHoi\r\nWHERE MaBoCauHoi = ${maBoCauHoi}");
                    int maVuaThem = (int)cDatabase.GetTable("select max(MaBoCauHoi) from BoCauHoi").Rows[0][0];
                    DataTable cacCauHoiCuaBoMua = cDatabase.GetTable("select *from cauhoi where mabocauhoi=" + maBoCauHoi);
                    for (int i = 0; i < cacCauHoiCuaBoMua.Rows.Count; i++) {
                        int maCauHoiCu = (int)cacCauHoiCuaBoMua.Rows[i][0];
                        cDatabase.ExecuteCMD($"insert into CauHoi(NoiDungCauHoi,HinhAnh,GiaiThich,MaBoCauHoi) " +
                            $"select NoiDungCauHoi,HinhAnh,GiaiThich,{maVuaThem} from CauHoi where MaCauHoi={maCauHoiCu}");
                        int maCauHoiVuaThem = (int)cDatabase.GetTable("select max(MaCauHoi) from CauHoi").Rows[0][0];
                        DataTable cacCauTraLoi = cDatabase.GetTable($"select *from cauTraLoi where maCauHoi ={maCauHoiCu}");
                        cDatabase.ExecuteCMD($"insert into CauTraLoi(NoiDungCauTraLoi,DungSai,MaCauHoi) select NoiDungCauTraLoi,DungSai,{maCauHoiVuaThem} from CauTraLoi where MaCauHoi = {maCauHoiCu}\r\n");
                    }
                } catch (Exception e) {
                    Console.WriteLine(e);
                    return false;
                }
                return true;
            })
            .WithName("MuaBoCauHoi");

            routes.MapDelete("/api/BoCauHoi/{id}", (int id) => {
                cDatabase.ExecuteCMD($"delete from BoCauHoi where MaBoCauHoi=" + id);
            })
            .WithName("DeleteBoCauHoi");
            #endregion
        }
    }
}
