using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectMain : MonoBehaviour
{

    public GameObject Character;
    public GameObject[] Paths;
    private RectTransform _Character;
    private RectTransform[] _Path;

    private int NowMap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            if(NowMap == 0){
                NowMap = 1;
                _Character.position = _Path[1].position;
            }else if(NowMap == 2){
                NowMap = 3;
                _Character.position = _Path[3].position;
            }
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            if(NowMap == 1){
                NowMap = 2;
                _Character.position = _Path[2].position;
            }
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            if(NowMap == 1){
                NowMap = 0;
                _Character.position = _Path[0].position;
            }else if(NowMap == 3){
                NowMap = 2;
                _Character.position = _Path[2].position;
            }
        }
        else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            if(NowMap == 2){
                NowMap = 1;
                _Character.position = _Path[1].position;
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
}
