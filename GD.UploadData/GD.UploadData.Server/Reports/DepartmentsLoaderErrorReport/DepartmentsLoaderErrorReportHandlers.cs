using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData
{
  partial class DepartmentsLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      DepartmentsLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.DepartmentsLoaderErrorReport.Department>();
      foreach (var department in DepartmentsLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.DepartmentsLoaderErrorReport.Department.Create(
          reportSessionId,
          department.Split('|')[0],
          department.Split('|')[1],
          department.Split('|')[2],
          department.Split('|')[3],
          department.Split('|')[4],
          department.Split('|')[5],
          department.Split('|')[6],
          department.Split('|')[7],
          department.Split('|')[8]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.DepartmentsLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.DepartmentsLoaderErrorReport.SourceTableName, DepartmentsLoaderErrorReport.ReportSessionId);
    }

  }
}