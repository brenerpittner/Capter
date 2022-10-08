using Chapter.Contexts;
using Chapter.Interfaces;
using Chapter.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Adicionra cors para acesssar a API fora do domínio 
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Difereça entre AddSingleton, AddScoped, AddTransient
// https://pt.stackoverflow.com/questions/528196/quais-s%C3%A3o-as-diferen%C3%A7as-entre-os-m%C3%A9todos-addtransient-addscoped-e-addsingleton
builder.Services.AddScoped<ChapterContext, ChapterContext>();
builder.Services.AddScoped<LivroRepository, LivroRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();


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

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
