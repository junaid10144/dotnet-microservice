using Microsoft.EntityFrameworkCore;
using PlatformService;
using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseInMemoryDatabase("InMem"));

builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine($"--> CommandService Endpoint {builder.Configuration["CommandService"]}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Seed the database
PrepDb.PrepPopulation(app);

app.Run();