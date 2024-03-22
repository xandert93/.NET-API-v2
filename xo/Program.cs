var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Adds controllers to handle HTTP requests.
builder.Services.AddEndpointsApiExplorer(); // Adds API explorer services for generating Swagger/OpenAPI documentation.
builder.Services.AddSwaggerGen(); // Adds Swagger generation services.

var app = builder.Build(); // Builds the WebApplication instance.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Adds Swagger middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwaggerUI(); // Adds Swagger UI middleware to generate interactive documentation.
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS.

app.UseAuthorization(); // Adds authorization middleware to enable authorization capabilities.

app.MapControllers(); // Maps controllers to routes in the HTTP request pipeline.

app.Run(); // Executes the request pipeline and listens for incoming requests.
