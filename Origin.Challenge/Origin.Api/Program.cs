using Origin.DatabaseContext.IoC;
using Origin.Business.IoC;
using Origin.Repository.IoC;

///Warning - Mucho Texto
/**
    Para complementar el patron Repository, se diseño esta solucion con la inyeccion de dependencias,
    patron que actualmente me fascina por su impresionante tecnica.
    Mismo patron que he aprendido en mi oficio, que aun sigo aprendiendo y perfeccionando.
    Fue realizado aprox en 4 dias hasta el momento que he recibido el challenge. 

    Fue un enorme gusto participar de este challenge, cual sea el resultado fue un buen tiempo de exigencia propia que disfrute.

    Muchisimas Gracias Por la Oportunidad.
    Saludos. 
    Daniel Nina .
 */


const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
log.Info($"Starting Origin Challenge, Good Luck. {Environment.UserName}  | {System.Security.Principal.WindowsIdentity.GetCurrent()}");

builder.WebHost.UseIISIntegration();

//Injectamos las dependencias
builder.Services.AddDatabaseContext(builder.Configuration.GetConnectionString("DbContext"));
builder.Services.AddRepository();
builder.Services.AddBusiness();
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(Program));

//cors publico
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddLog4Net();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
