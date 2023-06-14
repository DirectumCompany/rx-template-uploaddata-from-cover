using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.UploadData.Structures.MunicipalAreasLoaderErrorReport
{
  /// <summary>
  /// Населенный пункт.
  /// </summary>
  partial class MunicipalArea
  {
    public string ReportSessionId { get; set; }
    
    public string Name { get; set; }
    
    public string ObjectGUID { get; set; }
    
    public string TypeName { get; set; }
    
    public string Error { get; set; }
  }
}