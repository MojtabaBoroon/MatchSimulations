using MatchSimulations.Application;
using MatchSimulations.Application.Abstractios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IMatchSimulation, MatchSimulation>();
builder.Services.AddTransient<IStageCalculator, StageCalculator>();
builder.Services.AddTransient<ILeagueSimulation, LeagueSimulation>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=League}/{action=Index}/{id?}");

app.Run();
