using AutoMapper;
using Desafio_Ilia_PARR.Config;
using Desafio_Ilia_PARR.Model.Context;
using Desafio_Ilia_PARR.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration["ConnectionStrings:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(option => option.
                    UseMySql(connection,
                             new MySqlServerVersion("10.4.13-MariaDB")));


//Mapping VOs.
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add Dependency Injection
builder.Services.AddScoped<IAlocacaoRepository, AlocacaoRepository>();

// Add services to the container.
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
