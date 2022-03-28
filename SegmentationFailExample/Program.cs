using System.Runtime.InteropServices;
using VxSdkNet;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();


var currentPath = new DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent;
//Windows
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
  
    Environment.SetEnvironmentVariable("PATH", $"{currentPath?.FullName}{Path.DirectorySeparatorChar}bin");

}
//linux
else
{
    Environment.SetEnvironmentVariable("PATH",Environment.GetEnvironmentVariable("PATH") + $"{currentPath?.FullName}{Path.DirectorySeparatorChar}bin");
}


//Windows based
// Build the path to GStreamer based on the current system settings.

//Linux based


// You may set this environment variable to gain g-streamer debug information.
//   See the g-streamer documentation for more information.
//Environment.SetEnvironmentVariable("GST_DEBUG", "2");

Init("XXXX", "XXX", "XXXX");



app.Run();




/// <summary>
/// init system
/// </summary>
/// <param name="ip"></param>
/// <param name="username"></param>
/// <param name="password"></param>
/// <returns></returns>
bool Init(string ip, string username, string password)
{
    try
    {
        var vxSystem = new VXSystem(ip, 443, true, "");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error creating new connection {e.Message} trace: {e.StackTrace}");
        return false;
    }

    return true;
}