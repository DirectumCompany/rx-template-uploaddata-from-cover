using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.UploadData
{
  partial class LoginsLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      LoginsLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.LoginsLoaderErrorReport.Login>();
      foreach (var jobTitle in LoginsLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.LoginsLoaderErrorReport.Login.Create(
          reportSessionId,
          jobTitle.Split('|')[0],
          jobTitle.Split('|')[1]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.LoginsLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.LoginsLoaderErrorReport.SourceTableName, LoginsLoaderErrorReport.ReportSessionId);
    }

  }
}