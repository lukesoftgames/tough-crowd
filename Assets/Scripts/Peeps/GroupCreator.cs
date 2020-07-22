using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int groupSizeLimit = 4;
    [SerializeField] GameObject peep;
    int numberInGroup;

    void Awake()
    {
        numberInGroup = Random.Range(1, groupSizeLimit);
    }
    void Start()
    {
        for (int i = 0; i < numberInGroup; i++)
        {
            Instantiate(peep, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
