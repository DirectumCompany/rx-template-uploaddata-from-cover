using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData.Structures.JobTitlesLoaderErrorReport
{
  /// <summary>
  /// Должность.
  /// </summary>
  partial class JobTitle
  {
    public string ReportSessionId { get; set; }
    
    public string Name { get; set; }
    
    public string Department { get; set; }
    
    public string Error { get; set; }
  }
  
}