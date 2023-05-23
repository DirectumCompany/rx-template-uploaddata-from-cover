using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.UploadData.Structures.EmployeesLoaderErrorReport
{
  /// <summary>
  /// Сотрудник.
  /// </summary>
  partial class Employee
  {
    public string ReportSessionId { get; set; }
    
    public string Person { get; set; }
    
    public string Login { get; set; }
    
    public string BusinessUnit { get; set; }
    
    public string Department { get; set; }
    
    public string JobTitle { get; set; }
    
    public string PersonnelNumber { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }       
    
    public string Description { get; set; }
    
    public string Error { get; set; }
  }
}