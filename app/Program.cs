var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var sqlController = new SqlController();

app.UseStaticFiles();

app.MapGet("/", () => {
    var file = File.ReadAllText("templates/index.html");
    return Results.Content(file, "text/html");
});

app.MapGet("/users", () => {
    var file = File.ReadAllText("templates/users.html");
    return Results.Content(file, "text/html");
});

app.MapGet("/registerUser", () => {
    var file = File.ReadAllText("templates/register.html");
    return Results.Content(file, "text/html");
});

app.MapGet("/newPosition", () => {
    var file = File.ReadAllText("templates/addPosition.html");
    return Results.Content(file, "text/html");
});







app.MapPost("/register", async (HttpContext context) => {
    await sqlController.InsertData(context);
});

app.MapPost("/allPositions", async (HttpContext context) => {
    await sqlController.getPositions(context);
});

app.MapPost("/registerPosition", async (HttpContext context) => {
    await sqlController.InsertPosition(context);
});

app.MapGet("/allUsers", async (HttpContext context) => {
    await sqlController.getAllUsers(context);
});

app.MapGet("/allUsersByPosition/{position}", async (HttpContext context) => {
    await sqlController.getAllUsersByPosition(context);
});

app.Run();
