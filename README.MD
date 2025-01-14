# ASPNET MVC Todo List Application With Entity Framework Core using SQL SERVER Database as Database

## How to use:

- Go to `appsettings.json` file in `TodoList` and `EntityFrameworkCore` Projects and then replace it with your SQL Server database's connection string
- If you want to use In Memory Repository instead of SQL Server, go to `Program.cs` inside `TodoList` project and uncomment this line `// builder.Services.AddSingleton<ITodoItemRepository, InMemoryTodoItemRepository>();` and comment this line `builder.Services.AddDbContext<SQLServerWebContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))`
