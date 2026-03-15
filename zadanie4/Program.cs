using Microsoft.EntityFrameworkCore;
using zadanie4.Data;
using zadanie4.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;

    // Relax password requirements
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3;

    // Do not require unique email or confirmed email
    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    var roleExists = roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult();
    if (!roleExists)
    {
        roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
    }

    var adminEmail = "admin@example.com";
    var adminPassword = "admin";

    var adminUser = userManager.FindByNameAsync("admin").GetAwaiter().GetResult();

    if (adminUser == null)
    {
        adminUser = userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult();
    }

    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true,
            DisplayName = "Administrator"
        };

        var result = userManager.CreateAsync(adminUser, adminPassword).GetAwaiter().GetResult();
        if (result.Succeeded)
        {
            userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
            Console.WriteLine($"Admin user created: {adminEmail} / {adminPassword}");
        }
        else
        {
            Console.WriteLine("Failed to create admin user:");
            foreach (var e in result.Errors)
            {
                Console.WriteLine($" - {e.Code}: {e.Description}");
            }
        }
    }
    else
    {
        var changed = false;
        if (!string.Equals(adminUser.UserName, adminEmail, StringComparison.OrdinalIgnoreCase))
        {
            adminUser.UserName = adminEmail;
            changed = true;
        }
        if (!string.Equals(adminUser.Email, adminEmail, StringComparison.OrdinalIgnoreCase))
        {
            adminUser.Email = adminEmail;
            changed = true;
        }
        if (changed)
        {
            var upd = userManager.UpdateAsync(adminUser).GetAwaiter().GetResult();
            Console.WriteLine($"Admin user updated username/email: {upd.Succeeded}");
        }

        var token = userManager.GeneratePasswordResetTokenAsync(adminUser).GetAwaiter().GetResult();
        var reset = userManager.ResetPasswordAsync(adminUser, token, adminPassword).GetAwaiter().GetResult();
        Console.WriteLine($"Admin password reset succeeded: {reset.Succeeded}");

        var isInRole = userManager.IsInRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
        if (!isInRole)
            userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();

        var passwordOk = userManager.CheckPasswordAsync(adminUser, adminPassword).GetAwaiter().GetResult();
        Console.WriteLine($"Admin user exists. Password matches '{adminPassword}': {passwordOk}");
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quiz}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();