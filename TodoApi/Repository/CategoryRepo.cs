
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class CategoryRepo
    {
        public List<Category> getAllListCategory()
        {

             TSQLContext dbContext=new TSQLContext();
            return dbContext.Category.ToList();
          // SqlConnection connection= new SqlConnection();
        //connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
        //connection.Open();
        //SqlCommand command= new SqlCommand();
        //command.CommandType=CommandType.Text;
        //command.CommandText=$@"select*from Production.Categories  ";
        
        //command.Connection=connection;

         //SqlDataReader reader = command.ExecuteReader();
      
        // List<Category> item=new List<Category>();
        
         //while(reader.Read())
       // {
         //   Category temp1=new Category();
         //   temp1.categoryName=reader["categoryname"].ToString();
         //   temp1.categoryID=int.Parse(reader["categoryid"].ToString());
         //   item.Add(temp1);
           
           // item.Add(new SelectListItem { Text =  temp1.campanyName,Value=temp1.supplierID.ToString()});
            
            
            
      //  }
      //  return item;
        

        }

      public List<Category> GetAllCategory(string searchC,string sortBy)
      {
          SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        command.CommandType=CommandType.Text;
       
        
       
        command.CommandText=$@"Select * from Production.Categories WHERE categoryname LIKE '%{searchC}%' or description LIKE '%{searchC}%' order by {sortBy} ";
        command.Connection=connection;

        SqlDataReader reader = command.ExecuteReader();
      
        List <Category> categoryNames=new List<Category>();
        while(reader.Read())
        {
            Category temp1=new Category();
            temp1.categoryID=int.Parse(reader["categoryid"].ToString());
            temp1.categoryName=reader["categoryname"].ToString();
            temp1.description=reader["description"].ToString();
            categoryNames.Add(temp1);

        }
        
        return categoryNames;

      }  

      public void AddCategory(Category c)
      {
           SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        command.CommandType=CommandType.Text;

        command.CommandText=$"exec [dbo].[AddCategory] {c.categoryName},{c.description}";
        command.Connection=connection;
        command.ExecuteNonQuery();///dodowanie do sql
      }
       
        
    }
    
       
}