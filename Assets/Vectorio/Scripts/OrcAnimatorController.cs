using UnityEngine;

public class OrcAnimatorController : MonoBehaviour
{
    Animator animator;
    public float animationSpeed = 1.0f;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = animationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0 || vertical != 0)
            animator.SetBool("IsMoving", true);
        else
            animator.SetBool("IsMoving", false);

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        if (vertical > 0)
        {
            animator.Play("OrcWalkUp");
        }
        else if (vertical < 0)
        {
            animator.Play("OrcWalkDown");
        }
        else if (horizontal < 0)
        {
            animator.Play("OrcWalkLeft");
        }
        else if (horizontal > 0)
        {
            animator.Play("OrcWalkRight");
        }
        /*if (Input.GetKeyDown(KeyCode.A))
        {
           DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.left , Color.red);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.right, Color.red);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.up, Color.red);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.down, Color.red);
        }*/
    }
}
