//using System.Reflection;
//using System.Text;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using MiraShop.DAL;
//using Swashbuckle.AspNetCore.Filters;
//using MiraShop.API.Middlewares;
//using MiraShop.API.Services;
//using MiraShop.API.Models.Mapper;
//using Microsoft.AspNetCore.ResponseCompression;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddHttpClient();
//builder.Services.AddHttpContextAccessor();

//builder.Services.AddResponseCompression(opts =>
//{
//    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
//        new[] { "application/octet-stream" });
//});

//var clientUrl = builder.Configuration.GetSection("AppSettings:ClientOrigin").Value!;

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        builder =>
//        {
//            builder.WithOrigins(clientUrl)
//                    .AllowAnyMethod()
//                    .AllowAnyHeader();
//        });
//});

////builder.Services.AddControllers();
////builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
////{
////    options.TokenValidationParameters = new TokenValidationParameters
////    {
////        ValidateIssuerSigningKey = true,
////        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
////        ValidateIssuer = false,
////        ValidateAudience = false
////    };
////});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
////builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
////builder.Services.AddSwaggerGen(swagger =>
////{
////    swagger.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
////    {
////        Description = "Standard Authorization heaeder using the Bearer scheme (\"bearer {token}\")",
////        In = ParameterLocation.Header,
////        Name = "Authorization",
////        Type = SecuritySchemeType.ApiKey,
////        Scheme = "Bearer"
////    });

////    swagger.OperationFilter<SecurityRequirementsOperationFilter>();

////    // using System.Reflection;
////    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
////    //swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
////});

//// Add dependencies
//MiraShop.DAL.DependencyInjectionRegistry.ConfigureServices(builder.Configuration, builder.Services);
//MiraShop.BLL.DependencyInjectionRegistry.ConfigureServices(builder.Services);
//builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

//var app = builder.Build();

//app.UseCors("AllowSpecificOrigin");

//app.UseDefaultFiles();
//app.UseStaticFiles();

//// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

//app.UseHttpsRedirection();

//app.UseResponseCompression();

//app.UseRouting();

//app.UseAuthentication();

//app.UseAuthorization();

//app.UseCurrentUserMiddleware();

//app.UseMiddleware<GlobalExceptionMiddleware>();

//app.MapControllers();

//app.MapFallbackToFile("/index.html");

//using (var scope = app.Services.CreateScope())
//{
//    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MiraShopAppContext>>();
//    using var context = factory.CreateDbContext();

//    if (context.Database.IsSqlServer())
//    {
//        context.Database.Migrate();
//    }
//}

//app.Run();