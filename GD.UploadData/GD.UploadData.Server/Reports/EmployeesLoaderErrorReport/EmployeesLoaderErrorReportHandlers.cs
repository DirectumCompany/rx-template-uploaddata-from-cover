using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData
{
  partial class EmployeesLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      EmployeesLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.EmployeesLoaderErrorReport.Employee>();
      foreach (var employee in EmployeesLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.EmployeesLoaderErrorReport.Employee.Create(
          reportSessionId,
          employee.Split('|')[0],
          employee.Split('|')[1],
          employee.Split('|')[2],
          employee.Split('|')[3],
          employee.Split('|')[4],
          employee.Split('|')[5],
          employee.Split('|')[6],
          employee.Split('|')[7],
          employee.Split('|')[8],
          employee.Split('|')[9]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.EmployeesLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.EmployeesLoaderErrorReport.SourceTableName, EmployeesLoaderErrorReport.ReportSessionId);
    }

  }
}