using UnityEngine;
using UnityEngine.AI;

public class PracticeDummy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform player;
    private Animator animator;

    public float lookRadius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshAgent.SetDestination(player.position);

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {
            navMeshAgent.SetDestination(player.position);
            animator.SetBool("Look", true);
        }
        else{
            animator.SetBool("Look", false);
        }
    }
}
