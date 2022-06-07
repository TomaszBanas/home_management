using SmartHome.BL.Decorators;
using SmartHome.BL.Mappers;
using SmartHome.BL.Repositories;
using SmartHome.BL.Services;
using SmartHome.Controllers;
using SmartHome.Database;
using SmartHome.Database.Models;
using SmartHome.Database.Repositories;
using SmartHome.Models.Dto;
using SmartHome.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<DatabaseContextConfig>(options => options.ConnectionString = builder.Configuration.GetConnectionString("DatabaseContext"));
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<CacheRepository>();


builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddScoped<IMapper<HttpContext, DecorationModel>, DecorationModelMapper>();
builder.Services.AddScoped<ModelResolver<DecorationModel>>();
builder.Services.AddScoped<DecoratorProviderService>();

builder.Services.AddScoped<IDecorator, FilterDecorator>();
builder.Services.AddScoped<IDecorator, PaggingDecorator>();


// TODO
builder.Services.AddScoped<IRepository<EntityType>, GenericRepository<EntityType>>();
builder.Services.AddScoped<IMapper<EntityType, ModelType>, ModelTypeToDtoMapper>();
builder.Services.AddScoped<IMapper<ModelType, EntityType>, ModelTypeFromDtoMapper>();
builder.Services.AddScoped<IService<ModelType>, GenericService<ModelType, EntityType>>();

//builder.Services.AddScoped<IRepository<Data2>, GenericRepository<Data2>>();
//builder.Services.AddScoped<IMapper<Data2Dto, Data2>, Data2FromDtoMapper>();
//builder.Services.AddScoped<IMapper<Data2, Data2Dto>, Data2ToDtoMapper>();
//builder.Services.AddScoped<IService<Data2Dto>, GenericService<Data2Dto, Data2>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

new ReadonlyGenericController<ModelType>().Handle(app, "modelType", "ModelType");

//app.UseAuthorization();

//app.MapControllers();

app.Run();
