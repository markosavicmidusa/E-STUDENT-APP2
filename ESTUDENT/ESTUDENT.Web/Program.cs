using System.Globalization;
using Dapper;
using ESTUDENT.Repositories;
using ESTUDENT.Resource.Resources.DataAnnotations;
using ESTUDENT.Services;
using ESTUDENT.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


#region ESTUDENT SERVICES


//DODATO U RAZVVOJU

// Service product Repository zbog koriscenja u Home Conbtroleru

builder.Services.AddSingleton<IExamRepository, ExamRepository>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<IStudentExamRepository, StudentExamRepository>();

builder.Services.AddSingleton<IService, Service>();

//auto mapper

builder.Services.AddAutoMapper(typeof(MapperService));

// adding dapper crud beacuse the project is instanced with one type of mysql querries
//vazi globalno

// SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL); 

#endregion


#region Localization

//Localization
builder.Services.AddLocalization(options => { options.ResourcesPath = ""; });


builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(
    options => options.DataAnnotationLocalizerProvider =
    (_, factory) => new StringLocalizer<DataAnnotations>(factory));

builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {

        List<CultureInfo> supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("sr"),
            new CultureInfo("en")
        };

        options.DefaultRequestCulture = new RequestCulture("sr");
        options.SetDefaultCulture("sr");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    }

);



#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
