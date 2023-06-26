using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.UploadData.Structures.PersonsLoaderErrorReport
{
  
  /// <summary>
  /// Персона.
  /// </summary>
  partial class Person
  {
    
    public string ReportSessionId { get; set; }
    
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string MiddleName { get; set; }
    
    public string Sex { get; set; }
    
    public string DateOfBirth { get; set; }
    
    public string TIN { get; set; }
    
    public string INILA { get; set; }    
    
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