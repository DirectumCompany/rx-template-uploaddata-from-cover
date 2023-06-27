using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData
{
  partial class CompaniesLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      CompaniesLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.CompaniesLoaderErrorReport.Company>();
      foreach (var company in CompaniesLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.CompaniesLoaderErrorReport.Company.Create(
          reportSessionId,
          company.Split('|')[0],
          company.Split('|')[1],
          company.Split('|')[2],
          company.Split('|')[3],
          company.Split('|')[4],
          company.Split('|')[5],
          company.Split('|')[6],
          company.Split('|')[7],
          company.Split('|')[8],
          company.Split('|')[9],
          company.Split('|')[10],
          company.Split('|')[11],
          company.Split('|')[12],
          company.Split('|')[13],
          company.Split('|')[14],
          company.Split('|')[15],
          company.Split('|')[16],
          company.Split('|')[17],
          company.Split('|')[18],
          company.Split('|')[19]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.CompaniesLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.CompaniesLoaderErrorReport.SourceTableName, CompaniesLoaderErrorReport.ReportSessionId);
    }

  }
}