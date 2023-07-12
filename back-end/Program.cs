using back_end.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins, options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapNguoiDungEndpoints();

app.MapThuMucChuDeEndpoints();

/*app.MapBoCauHoiEndpoints();

app.MapMonHocEndpoints();

app.MapCauHoiEndpoints();

app.MapCauTraLoiEndpoints();
*/

app.Run();
