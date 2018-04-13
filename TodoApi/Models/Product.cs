
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models

{

    [Table("Products", Schema = "Production")]
public class Product{
    public int ProductID{get; set;}

    public string ProductName{get; set;}

    public int SupplierID{get; set;}

    public int CategoryID{get; set;}

    public decimal UnitPrice{get; set;}

    public bool Discontinued{get; set;}
}
}
