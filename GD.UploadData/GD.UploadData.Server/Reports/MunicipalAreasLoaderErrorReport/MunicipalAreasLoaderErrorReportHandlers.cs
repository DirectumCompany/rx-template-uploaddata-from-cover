using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace GD.UploadData
{
  partial class MunicipalAreasLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      MunicipalAreasLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.MunicipalAreasLoaderErrorReport.MunicipalArea>();
      foreach (var municipalArea in MunicipalAreasLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.MunicipalAreasLoaderErrorReport.MunicipalArea.Create(
          reportSessionId,
          municipalArea.Split('|')[0],
          municipalArea.Split('|')[1],
          municipalArea.Split('|')[2],
          municipalArea.Split('|')[3]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.MunicipalAreasLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.MunicipalAreasLoaderErrorReport.SourceTableName, MunicipalAreasLoaderErrorReport.ReportSessionId);
    }

  }
}