using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    public void PlayGame(){

        int clickedobj=
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            //int.Parse converts string to an integer

        GameManager.instance.CharIndex=clickedobj;
        Debug.Log("clicked "+ clickedobj);

        SceneManager.LoadScene("Gameplay");
        Debug.Log("sahne yüklendi "+ clickedobj);
    }



}//class 
