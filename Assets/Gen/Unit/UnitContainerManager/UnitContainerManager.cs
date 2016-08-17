using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitContainerManager:UnitContainerManagerDefault
  {
    public UnitContainerManager(Unit Unit, UnitContainerManagerFactory UnitContainerManagerFactory){
    Init(Unit, UnitContainerManagerFactory);
    }
  }
}
