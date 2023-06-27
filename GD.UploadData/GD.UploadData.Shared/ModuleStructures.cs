using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using GD.CitizenRequests;

namespace GD.UploadData.Structures.Module
{
  
  #region Классификаторы обращений
  
  /// <summary>
  /// Базовый классификатор обращений.
  /// </summary>
  partial class ClassifierBase
  {
    public string Code { get; set; }
    
    public string Name { get; set; }
    
    public string FullCode { get; set; }
    
    public string Error { get; set; }
  }
  
  #endregion
  
  #region Организационная структура
  
  /// <summary>
  /// Должность.
  /// </summary>
  partial class JobTitle
  {
    public string Name { get; set; }
    
    public string Department { get; set; }
    
    public string DepartmentCode { get; set; }
    
    public string Error { get; set; }
  }
  
  /// <summary>
  /// Подразделение.
  /// </summary>
  partial class Department
  {
    public string Name { get; set; }
    
    public string ShortName { get; set; }
    
    public string HeadOffice { get; set; }
    
    public string BusinessUnit { get; set; }
    
    public string Code { get; set; }
    
    public string Manager { get; set; }
    
    public string Phone { get; set; }
    
    public string Description { get; set; }
    
    public string Error { get; set; }
  }
  
  /// <summary>
  /// Организация.
  /// </summary>
  partial class Company
  {
    public string Name { get; set; }
    
    public string LegalName { get; set; }
    
    public string HeadCompany { get; set; }
    
    public string Nonresident { get; set; }
    
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
  
  /// <summary>
  /// Персона.
  /// </summary>
  partial class Person
  {
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
  
  /// <summary>
  /// Сотрудник.
  /// </summary>
  partial class Employee
  {
    public string Person { get; set; }
    
    public string Login { get; set; }
    
    public string BusinessUnit { get; set; }
    
    public string Department { get; set; }
    
    public string JobTitle { get; set; }
    
    public string PersonnelNumber { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
    
    public string Description { get; set; }
    
    public string JabberId { get; set; }
    
    public string DepartmentCode { get; set; }

    public string Error { get; set; }
  }
  
  /// <summary>
  /// Наша организация.
  /// </summary>
  partial class BusinessUnit
  {
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
  
  /// <summary>
  /// Учетная запись.
  /// </summary>
  partial class Login
  {
    public string Name { get; set; }
    
    public string Error { get; set; }
  }
  
  /// <summary>
  /// Срок хранения.
  /// </summary>
  partial class FileRetentionPeriod
  {
    public string Name { get; set; }
    
    public string RetentionPeriod { get; set; }
    
    public string Note { get; set; }
    
    public string Error { get; set; }
  }
  
  /// <summary>
  /// Номенклатура дел.
  /// </summary>
  partial class CaseFile
  {
    public string Department { get; set; }
    
    public string RetentionPeriod { get; set; }
    
    public string Title { get; set; }
    
    public string Index { get; set; }
    
    public string Note { get; set; }
    
    public string Error { get; set; }
  }
  
  /// <summary>
  /// Номенклатуры дел.
  /// </summary>
  partial class CaseFilesInfo
  {
    public byte[] File { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public Sungero.Company.IBusinessUnit BusinessUnit { get; set; }
    
    public Sungero.Docflow.IRegistrationGroup RegistrationGroup { get; set; }
    
    public List<GD.UploadData.Structures.Module.CaseFile> CaseFiles{ get; set; }
  }
  
  #endregion
  
  /// <summary>
  /// Муниципальный район.
  /// </summary>
  partial class MunicipalArea
  {
    // Страна
    public Sungero.Commons.ICountry Country  { get; set; }

    // Регион
    public Sungero.Commons.IRegion Region  { get; set; }

    // Глобальный уникальный идентификатор адресного объекта типа UUID
    public string ObjectGUID { get; set; }
    
    // Наименование
    public string Name { get; set; }
    
    // Краткое наименование типа объекта
    public string TypeName { get; set; }
    
    // Уровень адресного объекта
    public string Level { get; set; }
    
    // Статус актуальности адресного объекта ФИАС
    public string IsActual { get; set; }
    
    // Признак действующего адресного объекта
    public string IsActive { get; set; }
    
    // Уникальный идентификатор записи. Ключевое поле
    public string ObjectId { get; set; }

    public string Error { get; set; }
  }
  
  /// <summary>
  /// Населенный пункт.
  /// </summary>
  partial class City
  {
    // Страна
    public Sungero.Commons.ICountry Country  { get; set; }

    // Регион
    public Sungero.Commons.IRegion Region  { get; set; }

    // Глобальный уникальный идентификатор адресного объекта типа UUID
    public string ObjectGUID { get; set; }
    
    // Наименование
    public string Name { get; set; }
    
    // Краткое наименование типа объекта
    public string TypeName { get; set; }
    
    // Уровень адресного объекта
    public string Level { get; set; }
    
    // Статус актуальности адресного объекта ФИАС
    public string IsActual { get; set; }
    
    // Признак действующего адресного объекта
    public string IsActive { get; set; }
    
    // Уникальный идентификатор записи. Ключевое поле
    public string ObjectId { get; set; }

    public string Error { get; set; }
  }

  /// <summary>
  /// Поселение.
  /// </summary>
  partial class Settlement
  {
    // Страна
    public Sungero.Commons.ICountry Country  { get; set; }

    // Регион
    public Sungero.Commons.IRegion Region  { get; set; }

    // Глобальный уникальный идентификатор адресного объекта типа UUID
    public string ObjectGUID { get; set; }
    
    // Наименование
    public string Name { get; set; }
    
    // Краткое наименование типа объекта
    public string TypeName { get; set; }
    
    // Уровень адресного объекта
    public string Level { get; set; }
    
    // Статус актуальности адресного объекта ФИАС
    public string IsActual { get; set; }
    
    // Признак действующего адресного объекта
    public string IsActive { get; set; }
    
    // Уникальный идентификатор записи. Ключевое поле
    public string ObjectId { get; set; }

    public string Error { get; set; }
  }
  
}