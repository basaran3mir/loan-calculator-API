using BusinessLogicLayer.BLL;
using DataAccessLayer.DAL;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular dev server adresin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddDbContext<LoanCalculatorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<BankDAL>();
builder.Services.AddScoped<BankBLL>();

builder.Services.AddScoped<CustomerDAL>();
builder.Services.AddScoped<CustomerBLL>();

builder.Services.AddScoped<LoanAppDAL>();
builder.Services.AddScoped<LoanAppBLL>();

builder.Services.AddScoped<LoanTypeDAL>();
builder.Services.AddScoped<LoanTypeBLL>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//CORS policy
app.UseCors("AllowAngularClient");

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
