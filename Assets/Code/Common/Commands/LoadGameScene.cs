using System.Threading.Tasks;
using Patterns.Behaviour.Command;

namespace Common.Commands
{
    public class LoadGameScene : Command
    {
        public async Task Execute()
        {
            await new LoadSceneCommand("Game").Execute();
            await new StartBattleCommand().Execute();
        }
    }
}
