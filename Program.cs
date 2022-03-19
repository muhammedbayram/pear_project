using pear_project;
using pear_project.Helpers;
using pear_project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
services.AddCors();
builder.Services.AddControllers();
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
services.AddScoped<IUserService, UserService>();
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<PearDbContext>();
builder.Services.AddScoped<IPearRepository,PearRepository>();
builder.Services.AddScoped<IPearService,PearService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
        app.UseMiddleware<JwtMiddleware>();
        
app.MapControllers();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


