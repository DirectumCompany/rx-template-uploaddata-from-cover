using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.UploadData.Structures.CaseFileLoaderErrorReport
{
  /// <summary>
  /// Номенклатура дел.
  /// </summary>
  partial class CaseFile
  {
    public string ReportSessionId { get; set; }
    
    public string Department { get; set; }
    
    public string RetentionPeriod { get; set; }
    
    public string Title { get; set; }
    
    public string Ind { get; set; }
    
    public string Note { get; set; }
    
    public string Error { get; set; }
  }
}