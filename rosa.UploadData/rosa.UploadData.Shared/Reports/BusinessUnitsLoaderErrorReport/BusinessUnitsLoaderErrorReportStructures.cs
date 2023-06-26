using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.UploadData.Structures.BusinessUnitsLoaderErrorReport
{
  /// <summary>
  /// Организация.
  /// </summary>
  partial class Company
  {
    public string ReportSessionId { get; set; }
    
    public string Name { get; set; }
    
    public string LegalName { get; set; }
    
    public string HeadCompany { get; set; }
    
    public string CEO { get; set; }
    
    public string TIN { get; set; }
    
    public string TRRC { get; set; }
    
    public string PSRN { get; set; }
    
    public string NCEO { get; set; }
    
    public string NCEA { get; set; }
    
    public string City { get; set; }
    
    public string Region { get; set; }
    
    public string LegalAddress { get; set; }
    
    public string PostalAddress { get; set; }
    
    public string Phones { get; set; }
    
    public string Email { get; set; }
    
    public string Homepage { get; set; }
    
    public string Note { get; set; }
    
    public string Account { get; set; }
    
    public string Bank { get; set; }
    
    public string Error { get; set; }
  }
}