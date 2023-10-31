using Common.Commands;
using Common.Score;
using Core.DataStorage;
using Core.Serializers;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using ScoreSystem = Common.Score.ScoreSystem;

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

            var serializer = new JsonUtilityAdapter();
            var dataStore = new PlayerPrefsDataStoreAdapter(serializer);
            var scoreSystemImpl = new ScoreSystemImpl(dataStore);
            ServiceLocator.Instance.RegisterService<ScoreSystem>(scoreSystemImpl);
        }
    }
}
