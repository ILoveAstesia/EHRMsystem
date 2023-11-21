using System.ComponentModel.DataAnnotations;

namespace EHRMsystem.Model;

public class DepartmentPerson{
    public int Id{get;set;}
    public int PersonId {get;set;}

    public int DepartmentId {get;set;}
}