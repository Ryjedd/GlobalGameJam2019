﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Control : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnPointerClick(PointerEventData eventData){
		Application.LoadLevel("Controls");
	}
}
