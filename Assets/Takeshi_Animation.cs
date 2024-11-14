using UnityEngine;

public class Takeshi_Animation : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    private Vector3 moveVelocity;

    public int speed;

    private bool _isGround;
    [SerializeField] private float _rayLength = 1f;
    [SerializeField] private float _rayOffset;
    [SerializeField] private LayerMask _layerMask = default;
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && _isGround)
       {
            characterController.Move(speed * Time.deltaTime * gameObject.transform.forward);
            animator.SetBool("Run", true);
       }else{
            animator.SetBool("Run", false);
       }

       if(Input.GetKey(KeyCode.S) && _isGround){
            characterController.Move(-speed / 2 * Time.deltaTime * gameObject.transform.forward);
            animator.SetBool("Back", true);
       }else{
            animator.SetBool("Back", false);
       }

       if(Input.GetKey (KeyCode.D)){
            transform.Rotate(0, 1, 0);
       }
       if(Input.GetKey (KeyCode.A)){
            transform.Rotate(0, -1, 0);
       }

       if(Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("Jump", true);
       }else{
            animator.SetBool("Jump", false);
       }

       //animator.SetFloat("speed", new Vector3(moveVelocity.x, 0, moveVelocity.z).magnitude);
    }

    private void FixedUpdate()
    {
        // 接地判定
        _isGround = CheckGrounded();
    }

    private bool CheckGrounded()
    {
        var ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);
        return Physics.Raycast(ray, _rayLength, _layerMask);
    }

}
