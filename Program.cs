using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesBO.OrderServiceClients;
using BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones;
using BackEndSisVes.BackEndSisVesBO.OrderServiceLogin;
using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton<DataContext>(provider => new DataContext(connectionString));

builder.Services.AddScoped<OrderServiceClients>();
builder.Services.AddScoped<OrderServiceCanton>();
builder.Services.AddScoped<OrderServiceDistrito>();
builder.Services.AddScoped<OrderServiceProvincia>();
builder.Services.AddScoped<OrderServiceDirections>();
builder.Services.AddScoped<OrderServiceLogin>();
builder.Services.AddScoped<OrderServiceTypeFuel>();
builder.Services.AddScoped<OrderServiceBrandVehicle>();
builder.Services.AddScoped<OrderServiceModelBrandVehicle>();
builder.Services.AddScoped<OrderServiceEngineVehicle>();


//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();//added
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
//added:
app.UseStaticFiles();
app.UseRouting();


app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=LoginPage}/{id?}"
);

app.MapControllers();

app.Run();
