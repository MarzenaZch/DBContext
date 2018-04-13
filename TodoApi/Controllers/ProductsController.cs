using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApi.Models;
using TodoApi.Repository;

public class ProductsController :Controller
{
    [HttpGet]
    public ViewResult GetAllProducts(string sortBy, string searchP, int page)
    {
       ProductRepo product= new ProductRepo();
      
        if(sortBy==null)///argument przyjmuje null GetAllProduct przyjmuje product name zeby nie wywaliło błędu 
        {
            sortBy="ProductName";

        };
        ViewData["currentPage"]=page;
        ViewData["sortBy"]=sortBy;

        ViewData["products"]=product.GetAllProducts(sortBy, searchP, page);///wysłanie view elemntu 
        return View();
        
    }
    [HttpGet]
    public ViewResult AddProduct()
    {
        SuppliersRepo suppliers= new SuppliersRepo();
      
        List <SelectListItem> supplai=new List<SelectListItem>();
        List <Suppliers> a= suppliers.GetAllSuppliers();

        foreach(Suppliers i in a)
        {
            supplai.Add(new SelectListItem { Text = i.companyName, Value = i.supplierID.ToString () });
        }
        
        
        ViewData["supplier"]=supplai;
        //ViewData["category"]=categoY;
        
        
        
        

        return View();
    }
   
         [HttpPost] //dodawnaie formularza 
    public ActionResult AddProduct ([FromForm] Product p) {

           //Response.Redirect ("http://localhost:5000/Products/GetAllProducts");///po wysłaniu przełacza na liste produktow
         if(p.ProductName.Length>3  &&p.UnitPrice>0 )
        {
        ProductRepo product = new ProductRepo ();
        product.AddProduct (p);
        
       
            return Ok();
           
        }
        else
        {
            return BadRequest(p.ProductName="za malo znakow ");
        }
        
         
         

    }

//ActionResult Ok()
//{
  //  throw new NotImplementedException();
//}

public ActionResult Delete(int id)
        {
        
       
        ProductRepo product = new ProductRepo ();
        product.delete(id);
        
        return RedirectToAction("GetAllProducts"); 
     //if(p.ProductName.Length>50&&p.CategoryID>0&&p.UnitPrice>0)
    
    }

}