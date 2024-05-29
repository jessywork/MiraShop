using BlazorApp1.Components;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiraShop.API.Middlewares;
using MiraShop.API.Models.Mapper;
using MiraShop.API.Services;
using MiraShop.DAL;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddResponseCompression(opts =>
//{
//    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
//        new[] { "application/octet-stream" });
//});

var clientUrl = builder.Configuration.GetSection("AppSettings:ClientOrigin").Value!;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins(clientUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add dependencies
MiraShop.DAL.DependencyInjectionRegistry.ConfigureServices(builder.Configuration, builder.Services);
MiraShop.BLL.DependencyInjectionRegistry.ConfigureServices(builder.Services);
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseResponseCompression();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCurrentUserMiddleware();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MiraShopAppContext>>();
    using var context = factory.CreateDbContext();

    if (context.Database.IsSqlServer())
    {
        context.Database.Migrate();
    }
}

app.Run();
