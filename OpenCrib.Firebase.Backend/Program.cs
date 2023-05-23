using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using OpenCrib.Firebase.Backend.Services;
using OpenCrib.Firebase.Backend.Models;
using Google.Cloud.Firestore;
using Microsoft.OpenApi.Models;
using Google.Cloud.Firestore.V1;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Google.Api;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;


//var credentials = GoogleCredential.FromFile(@"C:\Users\development-01\OneDrive\Escritorio\Development\OPENCRIB\OpenCrib.Firebase.Backend\OpenCrib.Firebase.Backend\opencrib-74dcd-firebase-adminsdk-hwhj1-5e26f2caf5.json");



public class Program
{
    public static void Main(string[] args)
    {
        
        //JSON KEY NEEDED
        var path = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
        string projectId = "opencrib-74dcd";
        GoogleCredential credential;

        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream);
        }

        var app = FirebaseApp.Create(new AppOptions
        {
            ProjectId = projectId,
            Credential = credential
        });

        FirestoreClient client = FirestoreClient.Create();
        //FirestoreClientBuilder for custom settings and credentials

        FirestoreDb db = FirestoreDb.Create(projectId, client);

        CreateHostBuilder(args, db);
    }

    public static void CreateHostBuilder(string[] args, FirestoreDb db)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
        });
        builder.Services.AddSingleton(db);
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }


}


