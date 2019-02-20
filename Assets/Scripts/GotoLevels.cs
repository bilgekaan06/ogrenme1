using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GotoLevels : MonoBehaviour
{
    public Button level2Button;
    public Button level3Button;

    void Start()
    {
        if (Player.thegate1)
            level2Button.interactable = true;
        if (Player.thegate2)
            level3Button.interactable = true;
    }
    public void levels(int levelId)
    {

        SceneManager.LoadScene(levelId, LoadSceneMode.Single);
        //Application.LoadLevel(levelId);
    }
}
