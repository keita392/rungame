using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject TreePrefab1;
    public GameObject TreePrefab2;
    public int NunberOfTrees;
    public float spacing = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tree = TreePrefab1;
        tree.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject tree2 = TreePrefab2;
        tree2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        for (int i = 0; i < NunberOfTrees; i++)
        {
            Vector3 position1 = new Vector3(-40, 0, i * spacing);
            Vector3 position2 = new Vector3(40, 0, i * spacing);
            Instantiate(tree, position1, Quaternion.identity);
            Instantiate(tree, position2, Quaternion.identity);

            Vector3 position3 = new Vector3(-50, 0, i * spacing);
            Vector3 position4 = new Vector3(50, 0, i * spacing);
            Instantiate(tree2, position3, Quaternion.identity);
            Instantiate(tree2, position4, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
