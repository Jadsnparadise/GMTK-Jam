using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] string scene1;
    public void GameStart()
    {
        SceneManager.LoadScene(scene1);
    }
}
