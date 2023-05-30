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
    /// <param name="filePath">Параметр.</param>    
    /// <returns>Код возврата.</returns>
    public static int AddMunHierarchy(string filePath, string regionCode)
    {
      try
      {
        Logger.Debug("Start.");
        // Загрузить id населенных пунктов
        List<string> cityIds = IntegrationServiceClient.RunFunctionWithListResult<string>("Settings", "GetCityIds", new { regionCode });
        // Загрузить id муниципальных районов
        List<string> municipalAreaIds = IntegrationServiceClient.RunFunctionWithListResult<string>("Settings", "GetMunicipalAreaIds", new { regionCode });
        // Загрузить id поселений
        List<string> settlementIds = IntegrationServiceClient.RunFunctionWithListResult<string>("Settings", "GetSettlementIds", new { regionCode });

        XmlReader reader = XmlReader.Create(filePath);
        int i = 0;

        // Загрузить иерархию для поселений
        while (reader.Read())
        {
          if (reader.NodeType == XmlNodeType.Element && reader.Name == "ITEM")
          {
            string objectId = reader.GetAttribute("OBJECTID");
            string parentObjId = reader.GetAttribute("PARENTOBJID");
            var isActive = reader.GetAttribute("ISACTIVE");
            if (isActive == "1" && settlementIds.IndexOf(objectId) != -1 && municipalAreaIds.IndexOf(parentObjId) != -1)
            {
              var result = IntegrationServiceClient.RunActionWithResult("Settings", "AddMunHierarchySettlement", new { objectId, parentObjId });
              Logger.Debug("{0} Settlement OBJECTID: {1} is {2}", i, reader.GetAttribute("OBJECTID"), result);
            }
            else
              Logger.Debug("{0} Settlement OBJECTID: {1} is {2}", i, reader.GetAttribute("OBJECTID"), "not found.");
            i++;
          }
        }

        // Загрузить иерархию для населенных пунктов
        reader.Close();
        reader = XmlReader.Create(filePath);
        i = 0;
        while (reader.Read())
        {
          if (reader.NodeType == XmlNodeType.Element && reader.Name == "ITEM")
          {
            string objectId = reader.GetAttribute("OBJECTID");
            string parentObjId = reader.GetAttribute("PARENTOBJID");
            var isActive = reader.GetAttribute("ISACTIVE");
            if (isActive == "1" && cityIds.IndexOf(objectId) != -1 && (municipalAreaIds.IndexOf(parentObjId) != -1 || settlementIds.IndexOf(parentObjId) != -1))
            {
              var result = IntegrationServiceClient.RunActionWithResult("Settings", "AddMunHierarchyCity", new { objectId, parentObjId });
              Logger.Debug("{0} City OBJECTID: {1} is {2}", i, reader.GetAttribute("OBJECTID"), result);
            }
            else
              Logger.Debug("{0} City OBJECTID: {1} is {2}", i, reader.GetAttribute("OBJECTID"), "not found.");
            i++;
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
