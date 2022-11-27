using Contacts.Api.Common.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var services = builder.Services;

builder.Services.AddControllers();

services.AddApplicationServices(builder.Configuration);

var policyName = "CorsPolicy";
 services.AddCors();

 services.AddCors(opt =>
 {
     opt.AddPolicy(policyName, corsPolicyBuilder =>
     {
         corsPolicyBuilder
             .WithOrigins("https://localhost:4200")
             .AllowCredentials()
             //.SetIsOriginAllowedToAllowWildcardSubdomains()
             .AllowAnyHeader()
             .AllowAnyMethod();
     });
 });

services.AddIdentityServices(builder.Configuration);

var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors(policyName);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToController("Index", "Fallback");
});

// using var scope = app.Services.CreateScope();
// var scopeServices = scope.ServiceProvider;
// try
// {
//     var context = scopeServices.GetRequiredService<DataContext>();
//     var uow = scopeServices.GetRequiredService<IUnitOfWork>();
//     var userManager = scopeServices.GetRequiredService<UserManager<AppUser>>();
//     var roleManager = scopeServices.GetRequiredService<RoleManager<IdentityRole>>();
//     await context.Database.MigrateAsync();
//     await SeedData.SeedUsers(uow, userManager, roleManager);
// }
// catch (Exception ex)
// {
//     var service = scopeServices.GetRequiredService<ILogger<Program>>();
//     service.LogError(ex, "An error occurred during migration");
// }
app.Run();