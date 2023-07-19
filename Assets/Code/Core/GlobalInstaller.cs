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
            await LoadNextScene();
        }
        private async Task LoadNextScene()
        {
            await LoadScene("Game");
            ServiceLocator.Instance.GetService<LoadingScreen>().Hide();
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
        protected override void DoInstallDependencies()
        {
        }
    }
}
