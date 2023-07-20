using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Core
{
    public partial class GlobalInstaller : GeneralInstaller
    {
        protected override async void DoStart()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                .AddCommand(new LoadSceneCommand("Menu"));
        }
        protected override void DoInstallDependencies()
        {
            ServiceLocator.Instance.RegisterService(CommandQueue.Instance);
        }
    }
}
