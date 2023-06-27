using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData
{
  partial class CaseFileLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      CaseFileLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.CaseFileLoaderErrorReport.CaseFile>();
      foreach (var classifire in CaseFileLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.CaseFileLoaderErrorReport.CaseFile.Create(reportSessionId,
                                                                           classifire.Split('|')[0],
                                                                           classifire.Split('|')[1],
                                                                           classifire.Split('|')[2],
                                                                           classifire.Split('|')[3],
                                                                           classifire.Split('|')[4],
                                                                           classifire.Split('|')[5]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.CaseFileLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.CaseFileLoaderErrorReport.SourceTableName, CaseFileLoaderErrorReport.ReportSessionId);
    }

  }
}