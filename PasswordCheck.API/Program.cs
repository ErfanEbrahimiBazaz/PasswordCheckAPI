using PasswordCheck.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.AllowTrailingCommas = true;
           options.JsonSerializerOptions.PropertyNamingPolicy = null; // Use original casing
       });
;

//  no caching and database operation
// in N layer architecture -> AddScoped or AddTransient
builder.Services.AddScoped<IPasswordStrengthChecker, PasswordStrengthChecker>();
//builder.Services.AddScoped<IPasswordBreachCheckService, PasswordBreachCheckService>();
builder.Services.AddHttpClient<IPasswordBreachCheckService, PasswordBreachCheckService>();


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
