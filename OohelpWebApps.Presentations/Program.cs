using Microsoft.EntityFrameworkCore;
using OohelpWebApps.Presentations;
using OohelpWebApps.Presentations.Domain;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Domain.Repositories.Interfaces;
using OohelpWebApps.Presentations.Domain.Repositories.EntityFramework;
using OohelpWebApps.Presentations.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Bind("Project", new AppConfig());
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(AppConfig.ConnectionString));

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    //кодирование кириллицы (иначе на выходе строка в UTF8)
    //options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic);

    //Сериализация типа Enum в строку
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    //запись форматированного JSON 
    //options.JsonSerializerOptions.WriteIndented = true;

    //сбрасываем в ноль формат имен свойств (по умолчанию CamelCase, вида "myData")
    options.JsonSerializerOptions.PropertyNamingPolicy = null;

    //игнорировать свойства с нулевыми значениями
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddScoped<IPresentationRepository, EFPresentationRepository>();
builder.Services.AddScoped<InMemoryUsersRepository>();
builder.Services.AddScoped<PresentationService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Presentation}/{action=Index}/{id?}");

app.Run();
