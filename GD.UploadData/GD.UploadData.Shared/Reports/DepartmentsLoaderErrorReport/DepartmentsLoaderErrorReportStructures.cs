using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData.Structures.DepartmentsLoaderErrorReport
{
  /// <summary>
  /// Подразделение.
  /// </summary>
  partial class Department
  {
    public string ReportSessionId { get; set; }
    
    public string Name { get; set; }
    
    public string ShortName { get; set; }
    
    public string HeadOffice { get; set; }
    
    public string BusinessUnit { get; set; }
    
    public string Code { get; set; }
    
    public string Manager { get; set; }
    
    public string Phone { get; set; }
    
    public string Description { get; set; }
    
    public string Error { get; set; }
  }
}