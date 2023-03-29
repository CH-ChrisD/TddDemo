using TddDemo.Web.Endpoints;

var builder = WebApplication.CreateBuilder(args);

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

var booksEndpoint = new Books();

app.MapGet("/hello_world", booksEndpoint.HelloWorld)
   .WithName(Books.Name)
   .WithOpenApi();

//app.MapPost("/add_books", )

app.Run();
