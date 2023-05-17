using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexInstance : MonoBehaviour
{
    [SerializeField]
    uint polygonalNumber = 5;
    [SerializeField]
    float radius = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 v = Vector3.zero;
        for (var i = 0; i < polygonalNumber; i++)
        {
            v.x = Mathf.Cos(Mathf.PI * 2 * i / polygonalNumber);
            v.y = Mathf.Sin(Mathf.PI * 2 * i / polygonalNumber);
            v*=radius;
            var vertexInstance=Instantiate<GameObject>(this.gameObject, v, Quaternion.identity);
            Destroy(vertexInstance.GetComponent<VertexInstance>());
        }
    }
}
