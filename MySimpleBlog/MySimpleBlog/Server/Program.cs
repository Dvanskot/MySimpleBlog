using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using MySimpleBlog.Shared.Core.Data;
using MySimpleBlog.Shared.Core.Interfaces;
using MySimpleBlog.Shared.Core.Serives;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Getting the connection string
var ConnectionString = builder.Configuration.GetConnectionString("SimpleBlogConn");

//Injecting Application DB Context class
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(ConnectionString);
}, ServiceLifetime.Transient
);

builder.Services.AddHttpClient<IContactService, ContactService>();
builder.Services.AddHttpClient<INewsArticleService, NewsArticleService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Adding Swagger to expose APIs
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Simple Blog V1");
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
