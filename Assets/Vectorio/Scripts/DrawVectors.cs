using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DrawVectors : MonoBehaviour
{
    public static DrawVectors Instance { get; private set; }

    public Vectorio vectorPrefab;
    public Transform container;

    private List<Vectorio> vectors = new List<Vectorio>();

    public Action Destroyed;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        Destroyed += ClearListFromEmpty;
    }

    [Tooltip("Draws a vector from start to end with the specified color. If start or end is null, it will not draw anything.")]
    public void Draw(object start, object end, Color color)
    {
        Vectorio vector = Instantiate(vectorPrefab, container);
        vector.Set(start, end, color, false, 0.1f);
        vectors.Add(vector);
    }

    public void DrawDir(object start, object dir, Color color)
    {
        Vectorio vector = Instantiate(vectorPrefab, container);
        vector.Set(start,(Vector3)start +  (Vector3)dir, color, false, 0.1f);
        vectors.Add(vector);

    }
    public void ClearListFromEmpty()
    {
        vectors.RemoveAll(x => x == null);
    }

    public void Clear()
    {
        foreach (var v in vectors)
            Destroy(v.gameObject);
        vectors.Clear();
    }

}
