using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public string navigate;
    public void NavigateScene()
    {
        SceneManager.LoadScene(navigate);
    }
}
