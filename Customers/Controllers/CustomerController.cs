using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly ApplicationDbContext _context;

    public CustomerController(ICustomerService customerService, ApplicationDbContext context)
    {
        _customerService = customerService;
        _context = context;
    }


    public IActionResult Customers(string q)

    {
        var customersVM = new CustomersVM();
        customersVM.Customers = _customerService.GetAllCustomers(q);
        customersVM.Countries = _customerService.FillCountryDropDown();

        return View(customersVM);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Customers(CustomersVM customersVM)
    {
        if (ModelState.IsValid)
        {
            _customerService.CreateCustomer(customersVM.CustomerCreateDTO);


            TempData["success"] = "Customer created successfully";

            return RedirectToAction("Customers", "Customer");
        }

        customersVM.Customers = _customerService.GetAllCustomers(customersVM.q);
        customersVM.Countries = _customerService.FillCountryDropDown();

        return View(customersVM);
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        var customerVM = new CustomerVM();
        customerVM.Countries = _customerService.FillCountryDropDown();
        var customerDB = _context.Customers
            .Include(c => c.Country)
            .First(c => c.Id == id);

        customerVM.Name = customerDB.Name;
        customerVM.CountryLabel = customerDB.Country.CountryLabel;
        customerVM.Age = customerDB.Age;
        customerVM.Birthday = customerDB.Birthday;

        return View(customerVM);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, CustomerVM customerVM)
    {
        if (ModelState.IsValid)
        {
            //Hämta objekt från db
            var customerDB = _context.Customers.First(c => c.Id == id);
            customerDB.Name = customerVM.Name;
            customerDB.Country = _context.Countries
                .Where(c => c.CountryLabel == customerVM.CountryLabel)
                .First();
            customerDB.Age = customerVM.Age;
            customerDB.Birthday = customerVM.Birthday;

            _context.SaveChanges();

            // Used for Toastr notifications
            TempData["success"] = "Customer edited successfully";

            //Redirect
            return RedirectToAction("Customers", "Customer");
        }

        return View(customerVM);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var customerVM = new CustomerVM();
        var customerDB = _context.Customers
            .Include(c => c.Country)
            .First(c => c.Id == id);

        customerVM.Name = customerDB.Name;
        customerVM.CountryLabel = customerDB.Country.CountryLabel;
        customerVM.Age = customerDB.Age;
        customerVM.Birthday = customerDB.Birthday;

        return View(customerVM);
    }


    public IActionResult Delete(int id)
    {
        var customerDB = _context.Customers
            .Include(_c => _c.Country)
            .FirstOrDefault(u => u.Id == id);
        var customerVM = new CustomerVM();

        if (customerDB == null)
        {
            return NotFound();
        }

        customerVM.Id = id;
        customerVM.Name = customerDB.Name;
        customerVM.CountryLabel = customerDB.Country.CountryLabel;
        customerVM.Age = customerDB.Age;
        customerVM.Birthday = customerDB.Birthday;

        return View(customerVM);

        if (customerDB == null)
        {
            return NotFound();
        }
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteCustomer(int id)
    {
        var customerDB = _context.Customers.Find(id);
        if (customerDB == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customerDB);
        _context.SaveChanges();

        TempData["success"] = "Customer deleted successfully";

        return RedirectToAction("Customers", "Customer");
    }
}
