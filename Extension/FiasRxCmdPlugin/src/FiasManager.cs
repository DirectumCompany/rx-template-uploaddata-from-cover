using Sungero.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Sungero.RxCmd
{
  /// <summary>
  /// Реализация команд.
  /// </summary>
  public class FiasManager
  {

    #region Properties

    internal static ILog Logger => Logs.GetLogger<FiasManager>();

    #endregion

    #region Methods

    /// <summary>
    /// Заготовка для реализации команды.
    /// </summary>
    /// <param name="filePath">Путь к файлу с иерархией.</param>
    /// <param name="regionCode">Код региона.</param>
    /// <returns>Код возврата.</returns>
    public static int AddMunicipalHierarchy(string filePath, string regionCode)
    {
      try
      {
        Logger.Debug("Start.");
        // Загрузить id населенных пунктов
        var cityIds = IntegrationServiceClient.RunFunctionWithListResult<string>("UploadData", "GetCityIds", new { regionCode });
        // Загрузить id муниципальных районов
        var municipalAreaIds = IntegrationServiceClient.RunFunctionWithListResult<string>("UploadData", "GetMunicipalAreaIds", new { regionCode });
        // Загрузить id поселений
        var settlementIds = IntegrationServiceClient.RunFunctionWithListResult<string>("UploadData", "GetSettlementIds", new { regionCode });

        var i = 0;
        // Загрузить иерархию для поселений
        using (var reader = XmlReader.Create(filePath))
        {
          while (reader.Read())
          {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "ITEM")
            {
              var objectId = reader.GetAttribute("OBJECTID");
              var parentObjId = reader.GetAttribute("PARENTOBJID");
              var isActive = reader.GetAttribute("ISACTIVE");
              if (isActive == "1" && settlementIds.IndexOf(objectId) != -1 && municipalAreaIds.IndexOf(parentObjId) != -1)
              {
                var result = IntegrationServiceClient.RunActionWithResult("UploadData", "AddMunicipalHierarchySettlement", new { objectId, parentObjId });
                Logger.Debug("{0} Settlement OBJECTID: {1}. Update result - {2}", i, reader.GetAttribute("OBJECTID"), result);
              }
              else
                Logger.Debug("{0} Settlement OBJECTID: {1} is {2}", i, reader.GetAttribute("OBJECTID"), "not found.");
              i++;
            }
          }
        }

        // Загрузить иерархию для населенных пунктов
        i = 0;
        using (var reader = XmlReader.Create(filePath))
        {
          while (reader.Read())
          {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "ITEM")
            {
              var objectId = reader.GetAttribute("OBJECTID");
              var parentObjId = reader.GetAttribute("PARENTOBJID");
              var isActive = reader.GetAttribute("ISACTIVE");
              if (isActive == "1" && cityIds.IndexOf(objectId) != -1 && (municipalAreaIds.IndexOf(parentObjId) != -1 || settlementIds.IndexOf(parentObjId) != -1))
              {
                var result = IntegrationServiceClient.RunActionWithResult("UploadData", "AddMunicipalHierarchyCity", new { objectId, parentObjId });
                Logger.Debug("{0} City OBJECTID: {1}. Update result - {2}", i, reader.GetAttribute("OBJECTID"), result);
              }
              else
                Logger.Debug("{0} City OBJECTID: {1} is {2}", i, reader.GetAttribute("OBJECTID"), "not found.");
              i++;
            }
          }
        }
        Logger.Debug("DONE.");
      }
      catch (Exception ex)
      {
        Logger.Log(LogLevel.Error, ex, ex.Message);
        return -1;
      }
      return 0;
    }

    #endregion
  }
}
