using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WkCommerce.Domain.Entity;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int IdCategory { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool FgActive { get; set; }
}