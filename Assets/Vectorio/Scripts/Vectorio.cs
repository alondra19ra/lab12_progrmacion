using UnityEngine;

public class Vectorio : MonoBehaviour
{
    public float TimeToDestroy = 0.1f;
    private LineRenderer lineRenderer;

    public object startTarget;
    public object finalTarget;

    public Color lineColor;

    public bool chaseTarget = false;
    public float width = 0.1f;


    public float[] floats = new float[2] { 0.1f, 0.1f };

    void Awake()
    {
        
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
     
        lineRenderer.textureMode = LineTextureMode.Stretch;
    }
    private void Start()
    {
        if (startTarget.GetType() == typeof(Vector3))
        {
            lineRenderer.SetPosition(0, (Vector3)startTarget);
        }
        else if (startTarget.GetType() == typeof(GameObject))
        {
            lineRenderer.SetPosition(0, ((GameObject)startTarget).transform.position);
        }
        if (finalTarget.GetType() == typeof(Vector3))
        {
            lineRenderer.SetPosition(1, (Vector3)finalTarget);
        }
        else if (finalTarget.GetType() == typeof(GameObject))
        {
            lineRenderer.SetPosition(1, ((GameObject)finalTarget).transform.position);
        }
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.sortingOrder = -1;
        Destroy(gameObject, TimeToDestroy);
    }

    private void Update()
    {
        
    }
    private void OnDestroy()
    {
        DrawVectors.Instance.Destroyed?.Invoke();
    }
    public void Set(object _target, object _end, Color _color, bool _chaseTarget = false, float _width = 0.1f)
    {
        startTarget = _target;
        finalTarget = _end;

        lineColor = _color;
        chaseTarget = _chaseTarget;

        lineRenderer.startWidth = _width;
    }
}
