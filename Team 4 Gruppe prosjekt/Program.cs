using Team_4_Gruppe_prosjekt.Model;

DB.MakeData();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

// Skriv her

app.MapPost("/newTask", (ToDoItem item) =>
{
    try
    {
        var newToDoItem = new ToDoItem(item.Title, item.Description, item.UserId);
        DB.ToDoList.Add(newToDoItem);
        return "Item added successfully";
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        return ex.ToString();
    }
})
    .WithOpenApi();

// Fode jeg skriver kode med masse feil treinger vi debuging
app.MapGet("/tasks", () => DB.ToDoList)
    .WithOpenApi();

app.MapGet("/userTaskList", (int userId) => DB.GetUsersToDoList(userId))
    .WithOpenApi();

app.MapPut("/markTaskAsDone", (int taskId) =>
{
    if (DB.MarkTaskAsDone(taskId)) return "Updated sucsesfully";
    return "How fucked up is fucked up? Thats fucked up";
})
    .WithOpenApi();

app.MapGet("/getAllUsers", () => DB.Users)
    .WithOpenApi();

app.MapGet("/getUser", (string userName) =>
{
    if (DB.Users.Any(u => u.Name == userName))
    {
        return DB.Users.First(u => u.Name == userName);
    }
    return null;
})
    .WithOpenApi();

app.MapPut("/updateTask", (ToDoItem item) =>
{
    try
    {
        var foundItem = DB.ToDoList.First(e => e.Id == item.Id);
        foundItem.Title = item.Title;
        foundItem.Description = item.Description;
        return "Updated sucsesfully";
    }
    catch (Exception ex) { return ex.ToString(); }
})
    .WithOpenApi();

// Til her

app.Run();

