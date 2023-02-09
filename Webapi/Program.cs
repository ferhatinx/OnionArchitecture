using Application;
using Persistence;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

#region Registrations
builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);
#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
