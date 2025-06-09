using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float destroyRange = 1f;
    [SerializeField] private float seekRange = 5f;

    [SerializeField] private GameObject Target;

    private Vector3 initialPosition;

    private void Start()
    {
        //la posici�n inicial del enemigo
        initialPosition = transform.position;
    }

    private void Update()
    {
        Vector3 dirToTarget = (Target.transform.position - transform.position).normalized;
        float rawAngle = Vector3.Dot(transform.right, dirToTarget);
        float radians = Mathf.Acos(rawAngle);
        float angle = radians * Mathf.Rad2Deg;

        float distanceToTarget = Vector3.Distance(Target.transform.position, transform.position);

        // Si el personaje est� cerca y dentro del �ngulo de visi�n
        if (distanceToTarget < seekRange && angle <= 60)
        {
            MoveTowards(Target.transform.position);
        }
        else
        {
            // Regresar a la posici�n inicial
            if (Vector3.Distance(transform.position, initialPosition) > 0.1f)
            {
                MoveTowards(initialPosition);
            }
        }

        if (distanceToTarget < destroyRange)
        {
            Destroy(gameObject);
        }
    }

    void MoveTowards(Vector3 destination)
    {
        Vector3 direction = (destination - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        // Girar sprite hacia la izquierda si se mueve hacia la izquierda
        GetComponent<SpriteRenderer>().flipX = direction.x < 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, destroyRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seekRange);
    }
}
