using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEditorInternal.Profiling.Memory.Experimental;

public class Buttle : MonoBehaviour
{

    [SerializeField] public GameObject SkillMenu;

    [SerializeField] public GameObject[] skills = new GameObject[4];
    private TextMeshProUGUI[] skillsText = new TextMeshProUGUI[4];

    [SerializeField] public EnemySetting _enemySetting;
    private EnemyData enemyData;
    private string Enemy_ID;
    private int Enemy_HP;

    public GameObject playerPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SkillMenu.SetActive(false);
        //playerPanel.SetActive(false);
        for(int i = 0; i < skills.Length; i++){
            skillsText[i] = skills[i].GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    //バトルスタート
    public void ButtleStart(){
        Enemy_ID = Takeshi.touchEnemy;
        Debug.Log(Enemy_ID);
        enemyData = _enemySetting.GetEnemy(Enemy_ID);
        Enemy_HP = enemyData.HP;
        Debug.Log(Enemy_HP);
        PlayerTurn();
    }

    //自分のターン
    public void PlayerTurn(){
        Debug.Log("PlayerTurn");
        playerPanel.SetActive(true);
    }
    //敵のターン
    public void EnemyTurn(){
        Debug.Log("EnemyTurn");
        playerPanel.SetActive(false);
        int rnd = Random.Range(1, 10);
        if(rnd >= 1 && rnd <= 6){
            Takeshi.Player_HP -= 10;
            Debug.Log("dmage => -10 = "+ Takeshi.Player_HP);
        }else {
            Debug.Log("miss => " + Takeshi.Player_HP);
        }
        if(Takeshi.Player_HP <= 0){
            Debug.Log("Die");
        }else{
            PlayerTurn();
        }
    }

    //たたかう
    public void OnButtleButton()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Takeshi.nowSkills[i] == null)
            {
                skillsText[i].text = "-";
            }
            else
            {
                skillsText[i].text = Takeshi.nowSkills[i].Name;
            }
        }
        SkillMenu.SetActive(true);
    }

    //にげる
    public void OnEscapeButton()
     {
          gameObject.SetActive(false);
          Time.timeScale = 1;
     }

    //攻撃のボタン
    public void OnSkill(GameObject skillButton)
    {
        int skillNum = 0;
        switch(skillButton.name){
            case "Skill_0":
                skillNum = 0;
                break;
            case "Skill_1":
                skillNum = 1;
                break;
            case "Skill_2":
                skillNum = 2;
                break;
            case "Skill_3":
                skillNum = 3;
                break;
        }
        Enemy_HP -= Takeshi.nowSkills[skillNum].Attack;
        Debug.Log("Enemy -" +Takeshi.nowSkills[skillNum].Attack + "=" + Enemy_HP);
        if(Enemy_HP <= 0){
            PlayerWin();
        }else{
            EnemyTurn();
        }
    }

    //勝利時
    public void PlayerWin(){
        Debug.Log("PlayerWin");
        gameObject.SetActive(false);
        GetItem();
        Time.timeScale = 1;
    }

    public void GetItem(){

    }
}
