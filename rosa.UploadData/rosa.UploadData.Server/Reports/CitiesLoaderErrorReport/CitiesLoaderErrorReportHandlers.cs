using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.UploadData
{
  partial class CitiesLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      CitiesLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.CitiesLoaderErrorReport.City>();
      foreach (var city in CitiesLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.CitiesLoaderErrorReport.City.Create(
          reportSessionId,
          city.Split('|')[0],
          city.Split('|')[1],
          city.Split('|')[2],
          city.Split('|')[3]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.CitiesLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.CitiesLoaderErrorReport.SourceTableName, CitiesLoaderErrorReport.ReportSessionId);
    }

  }
}