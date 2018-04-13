using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repository;

public class CategoryController:Controller
{
    public ViewResult GetAllCategory(string searchC,string sortBy)
    {
        CategoryRepo category= new CategoryRepo();
        if(sortBy==null) 
        {
            sortBy="categoryID";

        };
        
        ViewData["sortBy"]=sortBy;
        
        ViewData["category"]=category.GetAllCategory(searchC,sortBy);
        return View();
    }

    public ViewResult AddCategoryForm()
    {
        return View();
    }

    [HttpPost]//dodawnaie formularza 
    public void AddCategory([FromForm] Category c)
     {    
        CategoryRepo category = new CategoryRepo ();
        category.AddCategory(c);    

    }
}