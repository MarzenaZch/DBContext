using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class SuppliersRepo
    {
        public List<Suppliers> GetAllSuppliers()
        {
            SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        command.CommandType=CommandType.Text;
        command.CommandText=$@"select*from Production.Suppliers  ";
        
        command.Connection=connection;

         SqlDataReader reader = command.ExecuteReader();
      
         List<Suppliers> item=new List<Suppliers>();
        
         while(reader.Read())
        {
            Suppliers temp1=new Suppliers();
            temp1.companyName=reader["companyname"].ToString();
            temp1.supplierID=int.Parse(reader["supplierid"].ToString());
            item.Add(temp1);
           
            //item.Add(new SelectListItem { Text =  temp1.campanyName,Value=temp1.supplierID.ToString()});
            
            
            
        }
        return item;
        

        }
        public List<Suppliers> GetAllSuppliers(string searchS,string sortBy)
        {

             TSQLContext dbContext=new TSQLContext();
            return dbContext.Suppliers.ToList();

        //SqlConnection connection=new SqlConnection();
        //connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
        //connection.Open();
      
       // SqlCommand command=new SqlCommand();
       
       
       // command.CommandText=$@"select * from Production.Suppliers where companyname like '%{searchS}%' OR contactname like '%{searchS}%' order by {sortBy} " ;
       // command.Connection=connection;
      //  SqlDataReader reader=command.ExecuteReader();
      //  List <Suppliers> suppliersName=new List<Suppliers>();
      //  while(reader.Read())
      //  {
        //    Suppliers temp=new Suppliers();
        //    temp.supplierID=int.Parse(reader["supplierid"].ToString());
        //    temp.campanyName= reader["companyname"].ToString();
        //    temp.contacName= reader["contactname"].ToString();
        //    temp.contactittle= reader["contacttitle"].ToString();
        //    temp.adress= reader["address"].ToString();
         //   temp.city= reader["city"].ToString();
        //    temp.region= reader["region"].ToString();
        //    temp.postalCode= reader["postalcode"].ToString();
        //    temp.country= reader["country"].ToString();
            
         //   temp.phone= reader["phone"].ToString();
         //   temp.fax= reader["fax"].ToString();
         //   suppliersName.Add(temp);
       // }
       

     //   return suppliersName;
        }
        public void addDataSup(Suppliers s)
        {
            SqlConnection connection= new SqlConnection();
        connection.ConnectionString="Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True";
        connection.Open();
        SqlCommand command= new SqlCommand();
        command.CommandType=CommandType.Text;
        command.CommandText=$"exec [dbo].[addSupplier]  {s.companyName},{s.contactName},{s.contacttitle},{s.address},{s.city},{s.region},{s.postalCode},{s.country},{s.phone},{s.fax}";
        command.Connection=connection;
        command.ExecuteNonQuery();///dodowanie do sql
        }
       
        
    }
    
       
}