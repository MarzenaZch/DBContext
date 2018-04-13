
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    
    [Table("Suppliers", Schema = "Production")]
public class Suppliers
{

    [System.ComponentModel.DataAnnotations.Key]

    public int supplierID{set;get;}
    public string companyName{set;get;}
    public string contactName{set;get;}
    public string contacttitle{set;get;}
    
    public string address{set;get;}
    
    public string city{set;get;}
    public string region{set;get;}
    public string postalCode{set;get;}
    public string country{set;get;}

    public string phone{set;get;}
    public string fax{set;get;}

    
}
}