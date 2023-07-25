using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;

namespace Sungero.RxCmd
{
  /// <summary>
  /// Описание команд плагина.
  /// </summary>
  public class FiasCommand : BaseCommand
  {
    public FiasCommand(string name, string description)
      : base(name, description)
    {
      // Здесь задаются команды второго уровня и их аргументы. 
      // Для каждой команды указывается обработчик, который будет выполняться при вызове команды.

      // Загрузка иерархии по муниципальному делению.
      Func<string> defaultValue = () => "0";
      this.Add(new BaseCommand("add_municipal_hierarchy", "Add municipal hierarchy.")
               {
                 new Argument<string>("filePath", "Path to file AS_MUN_HIERARCHY_*.XML."),
                 new Argument<string>("regionCode", defaultValue, "Region code")
               }.WithHandler(typeof(FiasCommand), nameof(AddMunicipalHierarchyCommandHandler)));

    }

    /// <summary>
    /// Загрузка иерархии по муниципальному делению.
    /// </summary>
    /// <param name="filePath">Путь к файлу с иерархией.</param>
    /// <param name="regionCode">Код региона.</param>
    /// <returns>Код возврата.</returns>
    public static int AddMunicipalHierarchyCommandHandler(string username, string password, string service, string filePath, string regionCode = "0")
    {
      // Установить параметры подключения к сервису интеграции Directum RX.
      int exitCode = IntegrationServiceClient.Setup(username, password, null, service);
      return (exitCode == 0) ? FiasManager.AddMunicipalHierarchy(filePath, regionCode) : exitCode;
    }

  }
}
