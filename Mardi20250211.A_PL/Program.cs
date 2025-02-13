using Mardi20250211.B_BLL.Interfaces;
using Mardi20250211.B_BLL.Services;
using Mardi20250211.C_DAL.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//register services
RegisterServicesAndDbConnection(builder);


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

app.Run();


static void RegisterServicesAndDbConnection(WebApplicationBuilder builder)
{
    //builder.Services.AddScoped<IContentService, ContentService>();
    builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();

    //Utilisattion de la connection factory afin d'avoir tous les services de DAL dans une seul factory
    builder.Services.AddScoped<ISqlServicesConnectionFactory, SqlServicesConnectionFactory>();
    DALDependencyInjection.RegisterServicesRepository(builder.Services);
}