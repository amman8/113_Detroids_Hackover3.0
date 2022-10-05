using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;
    List<Vector3> positions;
    public PlayerMovement s_pms;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            StartRewind();
            Debug.Log("Rewind is Working");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            StopRewind();
            Debug.Log("Rewind is Working");
        }
    }

    private void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }


    public void StartRewind()
    {
        isRewinding = true;
        s_pms.gravity = 0f;
    }
    public void StopRewind()
    {
        s_pms.gravity = -19.62f;
        isRewinding = false;
    }

    public void Rewind()
    {
        if(positions.Count>0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
        
    }
    public void Record()
    {
        positions.Insert(0,transform.position);
    }

}
