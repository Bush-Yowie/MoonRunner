using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Object : MonoBehaviour
{
    //asset list
    [SerializeField] List<GameObject> BlockTypes;
    List<GameObject> blocks;
    [SerializeField] float TimeBetweenSpawns = 1f;
    float counting = 0;
    public GameObject SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counting >= TimeBetweenSpawns)
        {
            int random = Random.Range(0, BlockTypes.Count);
            GameObject temp = Instantiate(BlockTypes[random], SpawnPoint.transform.position, Quaternion.identity);
            counting = 0;
        }
        else
        {
            counting += Time.deltaTime;
        }
    }
}
