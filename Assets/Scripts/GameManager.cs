using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    //from that instance we can access all of the public var and funcs inside
    [SerializeField] private GameObject[] Characters;

    private int _charIndex;
    public int CharIndex{
        get{ return _charIndex;}
        set {_charIndex=value;}
    }

    private void Awake() {
    //Singleton pattern, only one copy is allowed.
        if(instance==null){
            instance=this; //refering to the class itself
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

//Delegation
    private void OnEnable(){
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable(){
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
        Debug.Log("OnLevelFinishedLoading çalıştı: " + scene.name);  
        if(scene.name=="GamePlay"){
            Debug.Log("CharIndex Değeri: " + CharIndex);
            Debug.Log("Karakter instantiate ediliyor: " + Characters[CharIndex].name);
            
            Instantiate(Characters[CharIndex]);
            Debug.Log("CharIndex sahne değişiminde: " + CharIndex);
            
            
        }
    }


}//class
