using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject Enemy4;
    

    private void Start()
    {
        Instantiate(Enemy1);
        Instantiate(Enemy2);
        Instantiate(Enemy3);
        Instantiate(Enemy4);
    }
}
