using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repository;

public class SuppliersController : Controller
{
    [HttpGet]
    public ViewResult GetAllSuppliers(string searchS,string sortBy)
    {
      SuppliersRepo supp= new SuppliersRepo();
        if(sortBy==null)
        {
            sortBy="supplierID";
        };
        ViewData["sortBy"]=sortBy;
       
        
        ViewData["suppliers"]=supp.GetAllSuppliers(searchS, sortBy);

        return View();

    }
    [HttpGet]
    public ViewResult AddSupplierForm()
    {
        return View();
    }
    [HttpPost]
    public void AddSupplier([FromForm]Suppliers s)
    {
   SuppliersRepo supp= new SuppliersRepo();
   supp.addDataSup(s);
    }

}