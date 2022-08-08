using Jifiti.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITransactionsService, TransctionsService>();
string apiUri = builder.Configuration.GetValue<string>("Api:Uri");
//To make  HttpClient instances manageable, and to avoid the socket exhaustion issue mentioned above,
// IHttpClientFactory interface which can be used to configure and create HttpClient instances
// in an app through Dependency Injection (DI) - (see TransactionService class
builder.Services.AddHttpClient("TransactionsApi", 
    c => c.BaseAddress = new Uri(apiUri));

//Creates a single instance for the duration of the scoped request,
//which means per HTTP request in ASP.NET.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
    });
});


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
app.UseCors();
app.Run();
