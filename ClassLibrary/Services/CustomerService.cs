﻿using ClassLibrary.Data;
using ClassLibrary.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassLibrary.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomerDTO> GetAllCustomers(string q)
        {
            var customers = _context.Customers
                .Select(c => new CustomerDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryLabel = c.Country.CountryLabel,
                    Age = c.Age,
                    Birthday = c.Birthday,
                });


            if (!String.IsNullOrEmpty(q))
            {
                customers = customers.Where(c => c.Name.Contains(q));
            }

            return customers;
        }

        public void CreateCustomer(CustomerDTO customerDTO)
        {
            var customerDb = new Customer();
            customerDb.Name = customerDTO.Name;
            customerDb.Country = _context.Countries
                .Where(c => c.CountryLabel == customerDTO.CountryLabel)
                .First();
            customerDb.Age = customerDTO.Age;
            customerDb.Birthday = customerDTO.Birthday;

            _context.Customers.Add(customerDb);
            _context.SaveChanges();
        }

        public List<SelectListItem> FillCountryDropDown()
        {
            List<SelectListItem> countries = new List<SelectListItem>();
            countries = _context.Countries.Select(c => new SelectListItem
            {
                Text = c.CountryLabel,
                Value = c.CountryLabel,
            })
                .ToList();

            countries.Insert(0, new SelectListItem
            {
                Text = "Choose a country...",
                Value = ""
            });

            return countries;
        }


        public IEnumerable<CustomerDTO> GetAllRichards()
        {
            var richards = _context.Customers
                .Where(c => c.Name.Contains("Nelly"))
                .Select(c => new CustomerDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryLabel = c.Country.CountryLabel,
                    Age = c.Age,
                    Birthday = c.Birthday,
                });
            return richards;
        }
    }
}

