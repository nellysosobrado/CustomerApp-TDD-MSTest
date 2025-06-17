using ClassLibrary.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data
{
    public class DataInitializer
    {
        private readonly ICustomerService _customerService;
        private readonly ApplicationDbContext _context;

        public DataInitializer(ICustomerService customerService, ApplicationDbContext context)
        {
            _customerService = customerService;
            _context = context;
        }

        public void SeedData()
        {
            _context.Database.Migrate();
            SeedCountries();
            SeedCustomers();
        }

        private void SeedCountries()
        {
            CountryDoesNotExist("Sweden");
            CountryDoesNotExist("Norway");
            CountryDoesNotExist("Denmark");
            CountryDoesNotExist("Finland");
        }

        private void CountryDoesNotExist(string countryLabel)
        {
            // Check to see if country already exists in db
            if (_context.Countries.Any(c => c.CountryLabel == countryLabel)) return;

            _context.Countries
                .Add(new Country
                {
                    CountryLabel = countryLabel
                });
            _context.SaveChanges();
        }

        private void SeedCustomers()
        {
            // Check to see if customer already exists in db
            if (_context.Customers.Any(c => c.Name == "Nelly")) return;
            _context.Customers
                .Add(new Customer
                {
                    Name = "Nelly",
                    CountryId = 1,
                    Age = 25,
                    Birthday = new DateTime(1970, 05, 21)
                });
            // Check to see if customer already exists in db
            if (_context.Customers.Any(c => c.Name == "Anton")) return;
            _context.Customers
                .Add(new Customer
                {
                    Name = "Anton",
                    CountryId = 1,
                    Age = 26,
                    Birthday = new DateTime(2007, 05, 21)
                });
            // Check to see if customer already exists in db
            if (_context.Customers.Any(c => c.Name == "Peter")) return;
            _context.Customers
                .Add(new Customer
                {
                    Name = "26",
                    CountryId = 1,
                    Age = 47,
                    Birthday = new DateTime(1975, 05, 21)
                });
            // Check to see if customer already exists in db
            if (_context.Customers.Any(c => c.Name == "Nelly 2")) return;
            _context.Customers
                .Add(new Customer
                {
                    Name = "Nelly 2",
                    CountryId = 1,
                    Age = 65,
                    Birthday = new DateTime(1955, 05, 21)
                });

            _context.SaveChanges();
        }
    }
}
