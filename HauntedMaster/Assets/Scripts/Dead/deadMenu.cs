using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadMenu : MonoBehaviour
{
    public void backMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
