﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roatation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(Vector3.up * (Random.Range(10.0f, 40.0f) * Time.deltaTime));

	}
}
