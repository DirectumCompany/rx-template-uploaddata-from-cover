using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.UploadData
{
  partial class FileRetentionPeriodLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      FileRetentionPeriodLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.FileRetentionPeriodLoaderErrorReport.FileRetentionPeriod>();
      foreach (var classifire in FileRetentionPeriodLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.FileRetentionPeriodLoaderErrorReport.FileRetentionPeriod.Create(reportSessionId,
                                                                                   classifire.Split('|')[0],
                                                                                   classifire.Split('|')[1],
                                                                                   classifire.Split('|')[2],
                                                                                   classifire.Split('|')[3]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.FileRetentionPeriodLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.FileRetentionPeriodLoaderErrorReport.SourceTableName, FileRetentionPeriodLoaderErrorReport.ReportSessionId);
    }

  }
}