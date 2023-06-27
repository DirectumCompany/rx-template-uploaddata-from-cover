using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData
{
  partial class SettlementsLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      SettlementsLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.SettlementsLoaderErrorReport.Settlement>();
      foreach (var settlement in SettlementsLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.SettlementsLoaderErrorReport.Settlement.Create(
          reportSessionId,
          settlement.Split('|')[0],
          settlement.Split('|')[1],
          settlement.Split('|')[2],
          settlement.Split('|')[3]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.SettlementsLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.SettlementsLoaderErrorReport.SourceTableName, SettlementsLoaderErrorReport.ReportSessionId);
    }

  }
}