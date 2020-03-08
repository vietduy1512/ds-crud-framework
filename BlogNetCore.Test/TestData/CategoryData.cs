using BlogNetCore.AppService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogNetCore.Test.TestData
{
    public static class CategoryData
    {
        public static IQueryable<Category> GetCategoriesQueryable()
        {
            return (new List<Category>
            {
                new Category()
                {
                    Id = 1,
                    Name = "IT",
                    Description = "Information technology (IT) is the use of computers to store, retrieve, transmit, and manipulate data, or information, often in the context of a business or other enterprise.",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                },
                new Category()
                {
                    Name = "Sport",
                    Description = "Sport is generally recognised as system of activities which are based in physical athleticism or physical dexterity.",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                },
                new Category()
                {
                    Name = "Cryptocurrency",
                    Description = "A cryptocurrency (or crypto currency) is a digital asset designed to work as a medium of exchange that uses strong cryptography to secure financial transactions, control the creation of additional units, and verify the transfer of assets. Cryptocurrencies are a kind of alternative currency and digital currency (of which virtual currency is a subset). Cryptocurrencies use decentralized control as opposed to centralized digital currency and central banking systems.",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now
                }
            }).AsQueryable();
        }
    }
}
