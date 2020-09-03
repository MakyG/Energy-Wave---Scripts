using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMap : MonoBehaviour
{

    public void Choose()
    {
        SceneManager.LoadScene("MapChoose");
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Map1()
    {
        SceneManager.LoadScene("Map1");
    }
    public void Map2()
    {
        SceneManager.LoadScene("Map2");
    }
    public void Map3()
    {
        SceneManager.LoadScene("Map3");
    }
    public void Map4()
    {
        SceneManager.LoadScene("Map4");
    }
    public void Update()
    {
    }
}
