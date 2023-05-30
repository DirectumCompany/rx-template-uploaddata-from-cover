using System.ComponentModel.Composition;

namespace Sungero.RxCmd
{
  [Export(typeof(IRxCmdPlugin))]
  public class FiasPlugin : IRxCmdPlugin
  {
    // Метод получения команд для добавления их в RxCmd.
    public BaseCommand GetCommand()
    {
      // Здесь задается команда плагина первого уровня.
      // Команда первого уровня логически объединяет семейство команд плагина в рамках области действия. 
      return new FiasCommand("fias", "Fias processing command.");
    }
  }
}
