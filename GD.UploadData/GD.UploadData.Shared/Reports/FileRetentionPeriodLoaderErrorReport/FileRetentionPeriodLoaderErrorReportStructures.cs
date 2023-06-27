using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData.Structures.FileRetentionPeriodLoaderErrorReport
{
  /// <summary>
  /// Срок хранения.
  /// </summary>
  partial class FileRetentionPeriod
  {
    public string ReportSessionId { get; set; }
    
    public string Name { get; set; }
    
    public string RetentionPeriod { get; set; }
    
    public string Note { get; set; }
    
    public string Error { get; set; }
  }
}