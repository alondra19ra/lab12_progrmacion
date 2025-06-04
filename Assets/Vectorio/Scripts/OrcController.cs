using UnityEngine;

public class OrcController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform enemy;

    void Update()
    {

        Movement();

        if (Input.GetKey(KeyCode.Space))
        {
            EnemyDir();
        }

    }

    public void EnemyDir()
    {
        Vector3 EnemeyDir = (enemy.position - transform.position).normalized;

        print(Vector3.Distance(transform.position, enemy.position));
        DrawVectors.Instance.Draw(transform.position, transform.position + EnemeyDir, Color.green);
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.left, Color.blue);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.right, Color.black);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.up, Color.white);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            DrawVectors.Instance.Draw(transform.position, transform.position + Vector3.down, Color.magenta);
        }
    }
}
