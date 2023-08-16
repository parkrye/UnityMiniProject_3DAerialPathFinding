using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Flight : MonoBehaviour
{
    [SerializeField] Transform target;
    Stack<Vector3> path;

    void Awake()
    {
        path = new();
    }

    void Start()
    {
        transform.LookAt(target);
        path = PathFinder.PathFinding(transform, transform.position, target.position, 0.6f);
        if (path.Count > 0)
        {
            Debug.Log("Successfully Find Path");
            StartCoroutine(MoveRoutine());
        }
        else
        {
            Debug.Log("Fail to Find Path");
        }
    }

    IEnumerator MoveRoutine()
    {
        while (path.Count > 0)
        {
            Vector3 nextPosition = path.Pop();
            Debug.Log($"Least Path : {path.Count}");
            for (int i = 0; i < 10; i++)
            {
                transform.Translate((nextPosition - transform.position) * 0.1f);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(path.Count > 0)
        {
            foreach(Vector3 t in path)
            {
                Gizmos.DrawWireSphere(t, 0.5f);
            }
        }
    }
}