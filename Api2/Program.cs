using GameApi.Data;
using GameApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Disable HTTPS redirection in development
builder.Services.AddDbContext<GameContext>(opt =>
    opt.UseInMemoryDatabase("GameDb"));

builder.Services.AddControllers();

var app = builder.Build();

// Seed initial data into the in-memory database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GameContext>();

    if (!context.Quests.Any())
    {
        context.Quests.AddRange(new Quest
        {
            Id = 1,
            Name = "Tuhoa rotat",
            Description = "Tapa 3 rottaa ja tuo nahat minulle.",
            Reward = 50
        },
        new Quest
        {
            Id = 2,
            Name = "Etsi Viljo",
            Description = "Onkos Viljoo näkyny.",
            Reward = 100
        });

        context.SaveChanges();
    }
}


app.MapControllers();

app.Run();





