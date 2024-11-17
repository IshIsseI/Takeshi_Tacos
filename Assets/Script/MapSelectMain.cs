using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectMain : MonoBehaviour
{

    public GameObject Character;
    public GameObject[] Paths;
    private RectTransform _Character;
    private RectTransform[] _Path;

    private int NowMap;

    void Start()
    {
        _Character = Character.GetComponent<RectTransform> ();
        _Path = new RectTransform[Paths.Length];
        for(int i = 0; i < Paths.Length; i++){
            _Path[i] = Paths[i].GetComponent<RectTransform> ();
        }
        _Character.position = _Path[0].position;
        NowMap = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            if(NowMap == 0){
                ChangeMap(NowMap + 1);
            }else if(NowMap == 2){
                ChangeMap(NowMap + 1);
            }
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            if(NowMap == 1){
                ChangeMap(NowMap + 1);
            }
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            if(NowMap == 1){
                ChangeMap(NowMap - 1);
            }else if(NowMap == 3){
                ChangeMap(NowMap - 1);
            }
        }
        else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            if(NowMap == 2){
                ChangeMap(NowMap - 1);
            }
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            switch(NowMap){
                case 0:
                    SceneManager.LoadScene("Stage_" + 0);
                    break;
                case 1:
                    SceneManager.LoadScene("Stage_" + 1);
                    break;
                case 2:
                    SceneManager.LoadScene("Stage_" + 2);
                    break;
                case 3:
                    SceneManager.LoadScene("Stage_" + 3);
                    break;
            }
        }
    }

    void ChangeMap(int i){
        NowMap = i;
        _Character.position = _Path[i].position;
    }
}
