using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class ProductRepo
    {
        public List<Product> GetAllProducts(string sortBy, string searchP, int page)
        {
            TSQLContext dbContext=new TSQLContext();
            return dbContext.Products.ToList();
        }
        
      /*  SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        
       command.CommandText=$@"Select * from GetAllProducts where productname like  '%{searchP}%'  order by {sortBy} OFFSET {page*5} ROWS FETCH NEXT 5 ROWS ONLY ";
       command.Connection=connection;

        SqlDataReader reader = command.ExecuteReader();
      
        List <Product> productNames=new List<Product>();
        while(reader.Read())
            {
                Product temp= new Product();
                temp.ProductID=int.Parse(reader["productid"].ToString());
                temp.ProductName=reader["productname"].ToString();
                temp.SupplierID=int.Parse(reader["supplierid"].ToString());
                temp.CategoryID=int.Parse(reader["categoryid"].ToString());
                temp.UnitPrice=decimal.Parse(reader["unitprice"].ToString());
                temp.Discontinued=bool.Parse(reader["discontinued"].ToString());
                productNames.Add(temp);
            }
                return productNames;
            
       }
        SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        
       command.CommandText=$@"Select * from GetAllProducts where productname like  '%{searchP}%'  order by {sortBy} OFFSET {page*5} ROWS FETCH NEXT 5 ROWS ONLY ";
       command.Connection=connection;

        SqlDataReader reader = command.ExecuteReader();
      
        List <Product> productNames=new List<Product>();
        while(reader.Read())
            {
                Product temp= new Product();
                temp.ProductID=int.Parse(reader["productid"].ToString());
                temp.ProductName=reader["productname"].ToString();
                temp.SupplierID=int.Parse(reader["supplierid"].ToString());
                temp.CategoryID=int.Parse(reader["categoryid"].ToString());
                temp.UnitPrice=decimal.Parse(reader["unitprice"].ToString());
                temp.Discontinued=bool.Parse(reader["discontinued"].ToString());
                productNames.Add(temp);
            }
                return productNames;
            
       }/* */
        public void AddProduct(Product p)
        {


            TSQLContext dbContext= new TSQLContext();
            dbContext.Products.Add(p);
            dbContext.SaveChanges();
            //po wyslaniu  na serwer przełacza na liste produktów 
       // SqlConnection connection= new SqlConnection();
       // connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
       // connection.Open();
       // SqlCommand command= new SqlCommand();
      //  command.CommandType=CommandType.Text;

      //  command.CommandText=$"exec [dbo].[addProduct]  {p.ProductName},{p.SupplierID},{p.CategoryID},{p.UnitPrice} ,{p.Discontinued}";
      //  command.Connection=connection;
      //  command.ExecuteNonQuery();
        }
        public void delete(int id)
        {
            
        SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
      
      command.CommandText=$@"[dbo].[deleteProduct] {id} ";
        command.Connection=connection;

        SqlDataReader reader = command.ExecuteReader();
        
        
        

        }

       
        
        
        
    }
    
       
}