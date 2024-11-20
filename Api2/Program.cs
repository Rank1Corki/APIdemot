using Microsoft.EntityFrameworkCore;
using GameApi.Data;
using GameApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Lis‰‰ DbContext-palvelu SQLite-tietokantaa varten
builder.Services.AddDbContext<GameContext>(opt =>
    opt.UseInMemoryDatabase("GameDb"));

builder.Services.AddControllers();

// Build the app
var app = builder.Build();

// Seed initial data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GameContext>();

    // Add test quests to the database
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
        Description = "Onkos Viljoo n‰kyny.",
        Reward = 100
    });

    context.SaveChanges();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
