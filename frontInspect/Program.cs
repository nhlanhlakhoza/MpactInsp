var builder = WebApplication.CreateBuilder(args);

// REQUIRED for Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient(); // Optional but recommended

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// REQUIRED — Enables Blazor realtime UI
app.MapBlazorHub();

// REQUIRED — Blazor page host
app.MapFallbackToPage("/_Host");

app.Run();
