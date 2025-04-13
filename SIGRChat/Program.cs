using SignalChat.Hubs;
using Microsoft.EntityFrameworkCore;
using SignalChat.Context; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddDbContext<ChatDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build(); 

if (!app.Environment.IsDevelopment()) 
{ 
    app.UseExceptionHandler("/Error"); 
    app.UseHsts(); 
} 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub_NET>("/chatHub"); 

app.Run();