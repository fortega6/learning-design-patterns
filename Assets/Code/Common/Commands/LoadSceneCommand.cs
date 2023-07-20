using System.Threading.Tasks;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using UI;
using UnityEngine.SceneManagement;

namespace Common.Commands
{
    public class LoadSceneCommand : Command
    {
        private readonly string _sceneToLoad;

        public LoadSceneCommand(string sceneToLoad)
        {
            _sceneToLoad = sceneToLoad;
        }
        
        public async Task Execute()
        {
            var loadingScreen = ServiceLocator.Instance.GetService<LoadingScreen>();
            loadingScreen.Show();
            await LoadScene(_sceneToLoad);
            loadingScreen.Hide();
        }
        
        private async Task LoadScene(string sceneName)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
            {
                await Task.Yield();
            }

            await Task.Yield();
        }
    }
}
