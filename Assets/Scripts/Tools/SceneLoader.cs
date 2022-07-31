using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadScene(bool destroyDontDestroys = false)
    {
        if(destroyDontDestroys)
        {
            var results = FindObjectsOfType<DontDestroyOnLoad>().ToList();
            results.ForEach(x => Destroy(x.gameObject));
        }
        SceneManager.LoadScene(sceneName);
    }
}
