using csvReader.Endpoints.csvReader;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapMethods(ReaderGetAll.Template, ReaderGetAll.Methods, ReaderGetAll.Handle);

app.UseAuthorization();

app.Run();
