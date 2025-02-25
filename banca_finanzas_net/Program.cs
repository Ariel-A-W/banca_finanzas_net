using banca_finanzas_net.DIP;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ***************************************************************************************
// Conexión hacia la base de datos.
builder.Services.AddPostgreSQLConnection(builder.Configuration);
// ***************************************************************************************

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ******************************************************************************************
// *** All Services Dependency Injection ****************************************************
builder.Services.AddServicesDIP(builder.Configuration);
// ******************************************************************************************

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
