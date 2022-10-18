using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public async void LoadScene(string sceneName)
    {
        Debug.Log($"{sceneName} start loading");
        AsyncOperationHandle<SceneInstance> asyncOperationHandle = Addressables.LoadSceneAsync(sceneName);
        StartCoroutine(ConsoleLoader(asyncOperationHandle));
        await asyncOperationHandle.Task;
        Debug.Log($"{sceneName} loaded");
    }

    IEnumerator ConsoleLoader(AsyncOperationHandle ao)
    {
        while (!ao.IsDone)
        {
            Debug.Log($"Loading level... {ao.PercentComplete * 100}%");
            yield return null;
        }
    }
}
