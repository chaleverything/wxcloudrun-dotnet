using DataBase;
using Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.RegisterContexts().RegisterServices();
//builder.Services.AddControllers().AddJsonOptions(opt => {
//    opt.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All);
//});
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Console.OutputEncoding = Encoding.UTF8;

var app = builder.Build();

#region Test
//aspnetapp.LocalTest.TranscodingTest.EncodeTest();
//aspnetapp.LocalTest.EnumTest.GetEnumTest();
//aspnetapp.LocalTest.CommTest.FillChildrenTest();
#endregion Test

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.Run();
