using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//configuracion de la autenticacion de usuario
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie((options) =>
{
    options.LoginPath = new PathString("/Empleado/Login");
    //es para que la cookie tenga duracion de 8 horas para que vuelva a pedir clave y correo el cliente 
    options.ExpireTimeSpan = TimeSpan.FromHours(8);

    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//habilitar la autenticacion del usuario 
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
