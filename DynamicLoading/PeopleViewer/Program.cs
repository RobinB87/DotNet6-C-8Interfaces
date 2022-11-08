using PersonReader.Factory;
using PersonReader.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(5000));

// add reference to the ReaderFactory in the DI container
// if the code needs a ReaderFactory, the DI container will take care of it
builder.Services.AddSingleton<ReaderFactory>();

// to get the DataReader that we need, we need to call the GetReader method
// on the factory
builder.Services.AddSingleton<IPersonReader>(
    s => s.GetService<ReaderFactory>()!.GetReader());

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
