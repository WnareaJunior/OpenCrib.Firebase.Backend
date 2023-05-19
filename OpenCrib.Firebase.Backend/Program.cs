using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using OpenCrib.Firebase.Backend.Services;
using OpenCrib.Firebase.Backend.Models;
using Google.Cloud.Firestore;
using Microsoft.OpenApi.Models;

//var credentials = GoogleCredential.FromFile(@"C:\Users\development-01\OneDrive\Escritorio\Development\OPENCRIB\OpenCrib.Firebase.Backend\OpenCrib.Firebase.Backend\opencrib-74dcd-firebase-adminsdk-hwhj1-5e26f2caf5.json");


public class Program
{
    public Program(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Firebase Firestore configuration
        string projectId = "opencrib-74dcd";
        GoogleCredential credential;
        using (var stream = new FileStream(@"C:\Users\development-01\OneDrive\Escritorio\Development\OPENCRIB\OpenCrib.Firebase.Backend\OpenCrib.Firebase.Backend\opencrib-74dcd-firebase-adminsdk-hwhj1-5e26f2caf5.json", FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream);
        }

        var app = FirebaseApp.Create(new AppOptions
        {
            ProjectId = projectId,
            Credential = credential
        });

        FirestoreDb db = FirestoreDb.Create(projectId);

        // Add Firestore database to the DI container
        services.AddSingleton(db);

        // Add Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Handle production environment settings
        }

        app.UseRouting();

        // Add Swagger UI
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
            c.RoutePrefix = string.Empty;
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/
