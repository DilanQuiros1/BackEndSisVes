using BackEndSisVes.BackEndSisVesBA;
using BackEndSisVes.BackEndSisVesBO.OrderServiceClients;
using BackEndSisVes.BackEndSisVesBO.OrderServiceCredits;
using BackEndSisVes.BackEndSisVesBO.OrderServiceDirecciones;
using BackEndSisVes.BackEndSisVesBO.OrderServiceLogin;
using BackEndSisVes.BackEndSisVesBO.OrderServiceSales;
using BackEndSisVes.BackEndSisVesBO.OrderServiceVehicles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddSingleton<DataContext>(provider => new DataContext(connectionString));

builder.Services.AddScoped<OrderServiceClients>();
builder.Services.AddScoped<OrderServiceTypeContacs>();
builder.Services.AddScoped<OrderServiceContacts>();
builder.Services.AddScoped<OrderServiceCanton>();
builder.Services.AddScoped<OrderServiceDistrito>();
builder.Services.AddScoped<OrderServiceProvincia>();
builder.Services.AddScoped<OrderServiceDirections>();
builder.Services.AddScoped<OrderServiceLogin>();
builder.Services.AddScoped<OrderServiceTypeID>();

builder.Services.AddScoped<OrderServiceTypeFuel>();
builder.Services.AddScoped<OrderServiceBrandVehicle>();
builder.Services.AddScoped<OrderServiceModelBrandVehicle>();
builder.Services.AddScoped<OrderServicePrestacionesVehicle>();
builder.Services.AddScoped<OrderServiceEngineVehicle>();
builder.Services.AddScoped<OrderServiceDimentionWheelVehicle>();
builder.Services.AddScoped<OrderServiceBrandWheelVehicles>();
builder.Services.AddScoped<OrderServiceWheelVehicles>();
builder.Services.AddScoped<OrderServiceTypeWheelsVehicles>();
builder.Services.AddScoped<OrderServiceBill>();
builder.Services.AddScoped<OrderServiceVehicle>();
builder.Services.AddScoped<OrderServiceRodajeVehicle>();
builder.Services.AddScoped<OrderServiceSales>();
builder.Services.AddScoped<OrderServiceCredits>();




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
