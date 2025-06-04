using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float destroyRange;
    [SerializeField] private float seekRange;

    [SerializeField] private GameObject Target;

    private void Start()
    {
       
    }

    private void Update()
    {
       

         Vector3 dir = (Target.transform.position - transform.position).normalized;

         float rawAngle = Vector3.Dot(transform.right, dir);
         float radians = Mathf.Acos(rawAngle);
         float angle = radians * Mathf.Rad2Deg;
         print("Angle: " + angle);

        if(rawAngle < 0)
        {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }

        if(Vector3.Distance(Target.transform.position, transform.position) < seekRange && angle <= 60)
        {
            DrawVectors.Instance.Draw(transform.position, transform.position + transform.right, Color.green);
            DrawVectors.Instance.Draw(transform.position, transform.position + dir, Color.cyan);

            DrawVectors.Instance.DrawDir(transform.position, transform.position + transform.right, Color.red);

            transform.position += dir * speed * Time.deltaTime;
        }


        if (Vector3.Distance(Target.transform.position, transform.position) < destroyRange)
            Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, destroyRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seekRange);
    }
}
