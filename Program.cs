using CustomerOrdersMcp.Http.Data;

// Load environment variables from .env file
var envFile = Path.Combine(Directory.GetCurrentDirectory(), ".env");
if (File.Exists(envFile))
{
    foreach (var line in File.ReadAllLines(envFile))
    {
        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
            continue;
        var parts = line.Split('=', 2);
        if (parts.Length == 2)
            Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
    }
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CustomerRepository>();

builder.Services
    .AddMcpServer()
    .WithToolsFromAssembly()
    .WithHttpTransport(options =>
    {
        options.Stateless= true;
    });

var app = builder.Build();
   

app.MapMcp( pattern: "/mcp" );
app.MapGet( pattern: "/healthz",
    () => Results.Ok(new { status = "Healthy" }));

var serverHost = Environment.GetEnvironmentVariable("SERVER_HOST") ?? "localhost";
var serverPort = Environment.GetEnvironmentVariable("SERVER_PORT") ?? "2323";
var serverUrl = $"http://{serverHost}:{serverPort}";

app.Run( url: serverUrl );
