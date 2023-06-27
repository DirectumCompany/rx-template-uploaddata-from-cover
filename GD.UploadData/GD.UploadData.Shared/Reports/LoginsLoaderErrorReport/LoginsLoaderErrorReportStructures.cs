using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData.Structures.LoginsLoaderErrorReport
{
  /// <summary>
  /// Учетная запись.
  /// </summary>
  partial class Login
  {
    public string ReportSessionId { get; set; }
    
    public string Name { get; set; }
    
    public string Error { get; set; }
  }
  
}