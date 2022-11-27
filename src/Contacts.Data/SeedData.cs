using Contacts.Api.Common.Extensions;
using Contacts.Core.Entities;
using Contacts.Core.Enums;
using Contacts.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;

namespace Contacts.Data;

public static class SeedData
{
    private static IUnitOfWork _uow;
    public static async Task SeedUsers(IUnitOfWork uow, UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _uow = uow;
        

        var usersToCreate = new List<SeedUserModel>
        {
            new()
            {
                Email = "user@mysite.com", Password = "Password@123", Role = UserRoleEnum.UserRole.Name
            },
            new()
            {
                Email = "admin@mysite.com", Password = "Password@123", Role = UserRoleEnum.AdminRole.Name
            }
        };

        foreach (var role in Enumeration.GetAll<UserRoleEnum>())
        {
            var roleExists = await roleManager.RoleExistsAsync(role.Name);
            if (!roleExists) await roleManager.CreateAsync(new IdentityRole(role.Name));
        }

        foreach (var userToCreate in usersToCreate)
        {
            if (userManager.Users.Any(r => r.UserName == userToCreate.Email)) continue;

            var user = new AppUser
            {
                UserName = userToCreate.Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            await userManager.CreateAsync(user, userToCreate.Password);
            await userManager.AddToRoleAsync(user, userToCreate.Role);
        }

        var contacts = await uow.People.GetAllAsync();
        if (contacts.Any()) return;

        CreateContacts();
    }

    private static void CreateContacts()
    {
        string[] maleNames = new string[] { "Allan", "Ben", "Charlie","Daniel", "Eric", "Fred", "Gavin", "Henry", "Ian", "Jack", "Kobi", "Len", "Manny", "Nico", "Oliver", "Peter", "Ruan", "Steven","Thinus","Walter" };
        string[] femaleNames = new string[]
        {
            "Abby", "Bianca", "Charlene", "Dale", "Elizabeth", "Felicia", "Gorgia", "Helen", "Ilze", "Jacqui", "Karen",
            "Liz", "Mary", "Nicole", "Octavia", "Patricia", "Rachel", "Suzan", "Tata"
        };


        string[] surnames = new string[] { "Abbot", "Bezuindenhout", "Conwel", "Du Toit", "Estafan", "Fourie", "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Wilson", "Anderson", "Jackson", "Martin"};


        for (int i = 0; i <= 1000; i++)
        {
            var person = new Person
            {
                GenderId = i % 2 == 0 ? GenderEnum.Female.Id : GenderEnum.Male.Id,
            };
            person.FirstName = person.GenderId == GenderEnum.Male.Id ? maleNames.PickRandom() : femaleNames.PickRandom();
            person.Surname = surnames.PickRandom();

            Random random = new Random();
            var age = random.Next(18, 65);
            person.DateOfBirth = DateTime.Now.AddYears(-age);

            random = new Random();
            person.RegionId = random.Next(1, 9);
            person.Phone = GenerateMobile();
            person.Email = $"{person.FirstName.ToLower()}.{person.Surname.ToLower()}@company.com";

            _uow.People.Add(person);
            _uow.Complete();
        }


    }

    private static string GenerateMobile()
    {
        var numbers = new List<int>();
        while (numbers.Count < 10)
        {
            var randomNumber = new Random().Next(1, 10);
            numbers.Add(randomNumber);
        }

        return "0" + string.Join(string.Empty, numbers);
    }
}

public class SeedUserModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}