using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData
{
  partial class JobTitlesLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      JobTitlesLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.JobTitlesLoaderErrorReport.JobTitle>();
      foreach (var jobTitle in JobTitlesLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.JobTitlesLoaderErrorReport.JobTitle.Create(
          reportSessionId,
          jobTitle.Split('|')[0],
          jobTitle.Split('|')[1],
          jobTitle.Split('|')[2]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.JobTitlesLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.JobTitlesLoaderErrorReport.SourceTableName, JobTitlesLoaderErrorReport.ReportSessionId);
    }

  }
}