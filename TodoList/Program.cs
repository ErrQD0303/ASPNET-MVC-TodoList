var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddSingleton<ITodoItemRepository, InMemoryTodoItemRepository>();
builder.Services.AddDbContext<SQLServerWebContext>();
builder.Services.AddScoped<ITodoItemRepository, SQLServerTodoItemRepository<SQLServerWebContext>>();

builder.Services.AddTransient<TodoListManager>();
builder.Services.AddSingleton<IEFDBConnection, EFSQLServerConnection>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
