using HelloWorldLinux.Models;
using MessagePack;
using MessagePack.AspNetCoreMvcFormatter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Insert(0, new MessagePackOutputFormatter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () =>
{
    var response = new Response
    {
        Message = "Hello from MessagePack!",
        Timestamp = DateTime.UtcNow
    };

    // Explicitly serialize to MessagePack bytes
    var bytes = MessagePackSerializer.Serialize(response);
    return Results.File(bytes, "application/x-msgpack");
});

app.Run("http://0.0.0.0:8080");
