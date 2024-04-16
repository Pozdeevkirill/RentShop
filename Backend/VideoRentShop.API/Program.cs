using Microsoft.EntityFrameworkCore;
using VideoRentShop.API;
using VideoRentShop.API.Settings;
using VideoRentShop.Data;

var builder = WebApplication.CreateBuilder(args);

//Добавление зависимостей
builder.Services.AddDependencyInjection(builder.Configuration);



// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);

builder.Services.Configure<TokenSetting>(builder.Configuration.GetSection("TokenSetting"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "AllowSetOrigins";
builder.Services.AddCors();

#region Подключение к БД

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MainDbContext>(x => x.UseSqlServer(
    connectionString,
    y => y.MigrationsAssembly("VideoRentShop.Migrations")
));

#endregion

var app = builder.Build();

//Автоматическая миграция
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<MainDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
//app.UseCors(MyAllowSpecificOrigins);

app.Run();
