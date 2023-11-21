using System.ComponentModel.DataAnnotations.Schema;

namespace EHRMsystem.Model;

public class Department{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id {set;get;}
    public String? Name {set;get;}
    public List<Person> Persons { get;set; } = new();
}