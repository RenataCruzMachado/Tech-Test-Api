using tech_test_api.Context;
using Microsoft.EntityFrameworkCore;
using tech_test_api.Repositories;
using tech_test_api.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CourseDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
builder.Services.AddScoped<CourseDbContext, CourseDbContext>();

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
