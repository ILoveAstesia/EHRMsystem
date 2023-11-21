
namespace EHRMsystem.Model;

public class Person
{
    public int Id  {set;get;}
    public String? Name {set;get;}
    //public int DepartmentId  {set;get;}
    public List<Department> Departments { get;set; } = new();

    public int GetId(){
        return Id;
    }

}

