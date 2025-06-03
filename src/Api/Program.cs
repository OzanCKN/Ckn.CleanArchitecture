using Ckn.Api;
using Ckn.Application;
using Ckn.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Scalar.AspNetCore; // Eklendi

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddWebApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapScalarApiReference(opt =>
{
    opt
        .WithTitle("Carva Api Documentation")
        .WithTheme(ScalarTheme.Kepler)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});




app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();