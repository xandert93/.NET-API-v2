var builder = WebApplication.CreateBuilder(args);

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

// Add services to the container.
builder.Services.AddControllers(); // Adds controllers to handle HTTP requests.
builder.Services.AddEndpointsApiExplorer(); // Adds API explorer services for generating Swagger/OpenAPI documentation.
builder.Services.AddSwaggerGen(); // Adds Swagger generation services.
builder.Services.AddCors(opts =>
{  
  // development mode CORS policy
  opts.AddPolicy("cors-dev", (corsBuilder) =>
  {
    // allow requests from FE development server (port 3000 for React, 8000 for Vue, 4200 for Angular)
    // .WithOrigins(<origin-1>, ...<origin-n>)
    corsBuilder.WithOrigins("http://localhost:3000")
    .AllowAnyMethod() // allows specified origins to make all types of HTTP request
    .AllowAnyHeader() // allows requests to include any headers (useful for non-GETs, where pre-flight request is sent containing certain headers)
    .AllowCredentials(); // allows cookies to be attached to the request
  });

  // production mode CORS policy
  opts.AddPolicy("cors-prod", (corsBuilder) =>
  {
    corsBuilder.WithOrigins("https://www.myapp.com")
    .AllowAnyMethod() 
    .AllowAnyHeader() 
    .AllowCredentials(); 
  });
});

var app = builder.Build(); // Builds the WebApplication instance.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseCors("cors-dev");
  app.UseSwagger(); // Adds Swagger middleware to serve generated Swagger as a JSON endpoint.
  app.UseSwaggerUI(); // Adds Swagger UI middleware to generate interactive documentation.
}
else
{
  app.UseCors("cors-prod");
  app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS.
}

app.UseAuthorization(); // Addsauthorisation middleware to enableauthorisation capabilities.

app.MapControllers(); // Maps controllers to routes in the HTTP request pipeline.

app.Run(); // Executes the request pipeline and listens for incoming requests.
