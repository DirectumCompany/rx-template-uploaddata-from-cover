using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.UploadData
{
  partial class PersonsLoaderErrorReportServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var reportSessionId = System.Guid.NewGuid().ToString();
      PersonsLoaderErrorReport.ReportSessionId = reportSessionId;
      
      var tableData = new List<Structures.PersonsLoaderErrorReport.Person>();
      foreach (var person in PersonsLoaderErrorReport.LoaderErrorsStructure.Split(';'))
        tableData.Add(Structures.PersonsLoaderErrorReport.Person.Create(
          reportSessionId,
          person.Split('|')[0],
          person.Split('|')[1],
          person.Split('|')[2],
          person.Split('|')[3],
          person.Split('|')[4],
          person.Split('|')[5],
          person.Split('|')[6],
          person.Split('|')[7],
          person.Split('|')[8],
          person.Split('|')[9],
          person.Split('|')[10],
          person.Split('|')[11],
          person.Split('|')[12],
          person.Split('|')[13],
          person.Split('|')[14],
          person.Split('|')[15],
          person.Split('|')[16],
          person.Split('|')[17]));
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.PersonsLoaderErrorReport.SourceTableName, tableData);
    }

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.PersonsLoaderErrorReport.SourceTableName, PersonsLoaderErrorReport.ReportSessionId);
    }

  }
}