using ScreenScene.Business;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("ScreenSceneDBConnection");

connectionString = $"{connectionString}User ID={builder.Configuration["User:Id"]};Password={builder.Configuration["User:Password"]};";

Configuration.Configure(builder.Services, connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
