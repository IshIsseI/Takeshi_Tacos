using UnityEngine;
using UnityEngine.AI;

public class PracticeDummy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    private Transform player;
    private Animator animator;
    public float lookRadius;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Takeshi.CanMove)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance <= lookRadius)
            {
                navMeshAgent.SetDestination(player.position);
                animator.SetBool("Look", true);
            }
            else
            {
                animator.SetBool("Look", false);
            }
        }

    }
}
