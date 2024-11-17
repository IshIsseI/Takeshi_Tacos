using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPageMain : MonoBehaviour
{
    public GameObject StartPage;
    public GameObject Explanetion;
    private bool isStart;

    void Start()
    {
        StartPage.SetActive(true);
        Explanetion.SetActive(false);
        isStart = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && isStart == true){
            OnScreen();
        }
        if(Input.GetKeyDown(KeyCode.Return) && isStart == false){
            OnButtonStart();
        }
    }

    public void OnButtonStart(){
        isStart = true;
        StartPage.SetActive(false);
        Explanetion.SetActive(true);
    }

    public void OnScreen(){
        SceneManager.LoadScene("MapSelect");
    }
}
