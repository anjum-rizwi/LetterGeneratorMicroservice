using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSingleton<LetterGenerator.Services.BlobStorageService>();
builder.Services.AddSingleton<LetterGenerator.Services.FileGeneratorService>();
builder.Services.AddSingleton<LetterGenerator.Services.AtlasMailMergeService>();
builder.Services.AddSingleton<LetterGenerator.Services.EventGridPublisher>();
builder.Services.AddSingleton<LetterGenerator.Services.JobHistoryService>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
