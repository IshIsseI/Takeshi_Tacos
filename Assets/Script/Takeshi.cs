using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Linq;
using Unity.VisualScripting;

public class Takeshi : MonoBehaviour
{
     private Animator animator;
     private CharacterController characterController;

     public int speed;

     private bool _isGround;
     [SerializeField] private float _rayLength = 1f;
     [SerializeField] private float _rayOffset;
     [SerializeField] private LayerMask _layerMask = default;
     [SerializeField] private GameObject ButtleCanvas;
     public static  SkillData[] nowSkills;
     [SerializeField] public SkillSetting _skillSetting;

     public static string touchEnemy;
     [SerializeField] public Buttle _buttle;

     public GameObject MenuPanel;

     public static int Player_HP = 100;
     void Start()
     {
          animator = GetComponent<Animator>();
          characterController = GetComponent<CharacterController>();
          nowSkills = new SkillData[4];

          ButtleCanvas.SetActive(false);
          for(int i = 0; i < nowSkills.Length; i++){
               nowSkills[i] = _skillSetting.DataList[i];
          }
          for(int i = 0; i < 4; i++){
               Debug.Log(nowSkills[i].Name);
          }
     }

     // Update is called once per frame
     void Update()
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

          if (Input.GetKeyDown(KeyCode.Escape))
          {
               MenuPanel.SetActive(true);
               Time.timeScale = 0;
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
               Debug.Log("Touch");
               touchEnemy = enemy_col.gameObject.GetComponent<EnemyName>().Enemy_Name;
               ButtleCanvas.SetActive(true);
               _buttle.ButtleStart();
               Destroy(enemy_col.gameObject);
               Time.timeScale = 0;
          }

     }

}
