using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData
{
  partial class ClassifierLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      ClassifierLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.ClassifierLoaderErrorReport.ClassifierBase>();
      foreach (var classifire in ClassifierLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.ClassifierLoaderErrorReport.ClassifierBase.Create(reportSessionId,
                                                                                   classifire.Split('|')[0],
                                                                                   classifire.Split('|')[1],
                                                                                   classifire.Split('|')[2],
                                                                                   classifire.Split('|')[3]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.ClassifierLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.ClassifierLoaderErrorReport.SourceTableName, ClassifierLoaderErrorReport.ReportSessionId);
    }

  }
}