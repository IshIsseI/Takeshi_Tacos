using UnityEngine;
using System.Collections;

public class Takeshi : MonoBehaviour
{
     public GameObject TakeshiH;
     private Animator animator;
     private CharacterController characterController;

     public int speed;

     private bool _isGround;
     [SerializeField] private float _rayLength = 1f;
     [SerializeField] private float _rayOffset;
     [SerializeField] private LayerMask _layerMask = default;
     [SerializeField] private GameObject ButtleCanvas;
     [SerializeField] private GameObject BossCanvas;
     public static SkillData[] nowSkills;
     [SerializeField] public SkillSetting _skillSetting;

     public static string touchEnemy;
     [SerializeField] public Buttle _buttle;
     [SerializeField] public BossButtle _bossButtle;

     public GameObject MenuPanel;
     public GameObject MainCamera;
     public GameObject Camera2;
     public GameObject Camera3;
     public static int Player_HP = 100;
     public static bool CanMove;

     void Start()
     {
          CanMove = true;
          animator = GetComponent<Animator>();
          characterController = GetComponent<CharacterController>();
          nowSkills = new SkillData[4];
          MainCamera.SetActive(true);
          Camera2.SetActive(false);
          Camera3.SetActive(false);

          ButtleCanvas.SetActive(false);
          for (int i = 0; i < nowSkills.Length; i++)
          {
               nowSkills[i] = _skillSetting.DataList[i];
          }
          for (int i = 0; i < 4; i++)
          {
               Debug.Log(nowSkills[i].Name);
          }
     }
     void Update()
     {
          if (CanMove)
          {
               if (Input.GetKey(KeyCode.W) && _isGround)
               {
                    characterController.Move(speed * Time.deltaTime * gameObject.transform.forward);
                    animator.SetBool("Run", true);
               }
               else
               {
                    animator.SetBool("Run", false);
               }

               if (Input.GetKey(KeyCode.S) && _isGround)
               {
                    characterController.Move(-speed / 2 * Time.deltaTime * gameObject.transform.forward);
                    animator.SetBool("Back", true);
               }
               else
               {
                    animator.SetBool("Back", false);
               }

               if (Input.GetKey(KeyCode.D))
               {
                    transform.Rotate(0, 1, 0);
               }
               if (Input.GetKey(KeyCode.A))
               {
                    transform.Rotate(0, -1, 0);
               }

               if (Input.GetKeyDown(KeyCode.Space))
               {
                    animator.SetBool("Jump", true);
               }
               else
               {
                    animator.SetBool("Jump", false);
               }
          }


          if (Input.GetKeyDown(KeyCode.Escape))
          {
               MenuPanel.SetActive(true);
               CanMove = false;
               //Time.timeScale = 0;
          }
     }

     private void FixedUpdate()
     {
          _isGround = CheckGrounded();
     }

     private bool CheckGrounded()
     {
          var ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);
          return Physics.Raycast(ray, _rayLength, _layerMask);
     }
     void OnTriggerEnter(Collider enemy_col)
     {
          if (enemy_col.gameObject.tag == "Enemy")
          {
               Debug.Log("TouchEnemy");
               CanMove = false;
               touchEnemy = enemy_col.gameObject.GetComponent<EnemyName>().Enemy_Name;
               ButtleCanvas.SetActive(true);
               ChangeCamera(3);
               _buttle.ButtleStart();
               Destroy(enemy_col.gameObject);
               //Time.timeScale = 0;
          }

          if (enemy_col.gameObject.tag == "Boss")
          {
               Debug.Log("TouchBoss");
               CanMove = false;
               BossCanvas.SetActive(true);
               ChangeCamera(2);
               _bossButtle.BossButtleStart();
               //Time.timeScale = 0;
          }

          if (enemy_col.gameObject.tag == "Box")
          {
               Debug.Log("ぶつかった！");
               gameObject.GetComponent<CharacterController>().enabled = false;
               TakeshiH.transform.position = new Vector3(-133f, 1f, -167f);
               gameObject.GetComponent<CharacterController>().enabled = true;
          }

          if (enemy_col.gameObject.tag == "Box2")
          {
               gameObject.GetComponent<CharacterController>().enabled = false;
               transform.position = new Vector3(56.0f, 2.5f, 158.0f);
               gameObject.GetComponent<CharacterController>().enabled = true;
          }

     }
     public void Escape()
     {
          ChangeCamera(1);
     }

     public void ChangeCamera(int i)
     {
          if (i == 1)
          {
               Camera2.SetActive(false);
               Camera3.SetActive(false);
               MainCamera.SetActive(true);
          }
          else if (i == 2)
          {
               MainCamera.SetActive(false);
               Camera3.SetActive(false);
               Camera2.SetActive(true);
          }
          else if (i == 3)
          {
               Camera2.SetActive(false);
               MainCamera.SetActive(false);
               Camera3.SetActive(true);
          }
     }

}
