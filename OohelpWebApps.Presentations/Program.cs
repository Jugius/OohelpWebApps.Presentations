using Microsoft.EntityFrameworkCore;
using OohelpWebApps.Presentations.Api.Services;
using OohelpWebApps.Presentations.Database;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.Bind("Project", new AppConfig());

var connectionString = builder.Configuration.GetValue<string>("ConnectionString");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    //����������� ��������� (����� �� ������ ������ � UTF8)
    //options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic);

    //������������ ���� Enum � ������
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    //������ ���������������� JSON 
    //options.JsonSerializerOptions.WriteIndented = true;

    //���������� � ���� ������ ���� ������� (�� ��������� CamelCase, ���� "myData")
    options.JsonSerializerOptions.PropertyNamingPolicy = null;

    //������������ �������� � �������� ����������
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddScoped<PresentationsService>();
builder.Services.AddSingleton<AuthenticationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Presentation}/{action=Index}/{id?}");

app.Run();
