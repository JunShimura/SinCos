using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInstance : MonoBehaviour
{
    [SerializeField]
    Vector3 volumeSize = new Vector3Int(5, 5, 1);
    [SerializeField]
    float radius = 5;
    [SerializeField]
    bool isCheck = true;

    List<MeshFilter> meshFilters= new List<MeshFilter>();

    // Start is called before the first frame update
    void Start()
    {
        Vector3 v = Vector3.zero;
        Vector3 center = transform.position + volumeSize / 2.0f;
        // チェック
        for (var k = 0; k < volumeSize.z; k++)
        {
            for (var j = 0; j < volumeSize.y; j++)
            {
                for (var i = 0; i < volumeSize.x; i++)
                {
                    if (!isCheck || (i + j + k) % 2 == 0) //チェックか
                    {
                        v = new Vector3(i, j, k);
                        v += transform.position;
                        if (Vector3.Distance(v, center) < radius)
                        {
                            var instance = Instantiate<GameObject>(this.gameObject, v, Quaternion.identity);
                            Destroy(instance.GetComponent<CheckInstance>());
                            meshFilters.Add(instance.GetComponent<MeshFilter>());
                            //instance.transform.SetParent(transform);
                        }
                    }
                    else
                    {
                        //s += char2;
                    }
                }
            }
        }
    }
    /*
     void Start_()
    {
        //MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Count];

        int i = 0;
        while (i < meshFilters.Count)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);
    }
    */
}
