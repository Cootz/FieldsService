using FieldsService.Models.Dtos;
using FieldsService.Repositories;
using FieldsService.Services;
using FieldsService.Utils.Validation;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string pathToData = builder.Configuration.GetValue<string>("PathToData")!;

builder.Services
    .AddSingleton(provider => new FieldsRepositoryOptions() { PathToData = pathToData })
    .AddScoped<IValidator<double>, FieldIdValidator>()
    .AddScoped<IValidator<CoordinateDto>, CoordinateDtoValidator>()
    .AddScoped<IFieldsRepository, FieldsRepository>(provider => {
        FieldsRepository repository = new(provider.GetRequiredService<FieldsRepositoryOptions>());
        repository.LoadData();
        return repository;
    })
    .AddScoped<IFieldsService, FieldsService.Services.FieldsService>()
    .AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
