using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData
{
  partial class BusinessUnitsLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      BusinessUnitsLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.BusinessUnitsLoaderErrorReport.Company>();
      foreach (var businessUnit in BusinessUnitsLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.BusinessUnitsLoaderErrorReport.Company.Create(
          reportSessionId,
          businessUnit.Split('|')[0],
          businessUnit.Split('|')[1],
          businessUnit.Split('|')[2],
          businessUnit.Split('|')[3],
          businessUnit.Split('|')[4],
          businessUnit.Split('|')[5],
          businessUnit.Split('|')[6],
          businessUnit.Split('|')[7],
          businessUnit.Split('|')[8],
          businessUnit.Split('|')[9],
          businessUnit.Split('|')[10],
          businessUnit.Split('|')[11],
          businessUnit.Split('|')[12],
          businessUnit.Split('|')[13],
          businessUnit.Split('|')[14],
          businessUnit.Split('|')[15],
          businessUnit.Split('|')[16],
          businessUnit.Split('|')[17],
          businessUnit.Split('|')[18],
          businessUnit.Split('|')[19]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.BusinessUnitsLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.BusinessUnitsLoaderErrorReport.SourceTableName, BusinessUnitsLoaderErrorReport.ReportSessionId);
    }

  }
}