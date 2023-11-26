using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackBox.Factory;
using BlackECS;
using LasyDI;

public class EcsInstaller : MonoInstaller
{
    public override void OnInstall()
    {
        World.SetExternalComponentConstructor<ComponentFactory>(factory => 
        {
            factory.Bind<CubeInitializationComponent>();
        });

        World.RegistrationSystem<CubeInitializationSystem>();
        World.RegistrationSystem<CubeWaitTakeAttackSystem>();
        World.RegistrationSystem<CubeTakeAttackSystem>();
    }
}
