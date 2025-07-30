/***********************************************
				EasyTouch IV
	Copyright © 2014-2015 The Hedgehog Team
  http://www.blitz3dfr.com/teamtalk/index.php
		
	  The.Hedgehog.Team@gmail.com
		
**********************************************/
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class BaseFinger{

	public int fingerIndex;	
	public int touchCount;
	public Vector2 startPosition;
	public Vector2 position;
	public Vector2 deltaPosition;	
	public float actionTime;
	public float deltaTime;		
	
	public Camera pickedCamera;
	public GameObject pickedObject;
	public bool isGuiCamera;
		
	public bool isOverGui;
	public GameObject pickedUIElement;

	public Gesture GetGesture(){

		Gesture gesture = new Gesture();
		SetGesture(gesture);
		return gesture;
	}
	
	public void SetGesture(Gesture gesture){

		gesture.fingerIndex = fingerIndex;
		gesture.touchCount = touchCount;
		gesture.startPosition = startPosition;
		gesture.position = position;
		gesture.deltaPosition = deltaPosition;
		gesture.actionTime = actionTime;
		gesture.deltaTime = deltaTime;
		gesture.isOverGui = isOverGui;
		gesture.pickedCamera = pickedCamera;
		gesture.pickedObject = pickedObject;
		gesture.isGuiCamera = isGuiCamera;
		gesture.pickedUIElement = pickedUIElement;
	}

	public void Clear()
	{
	 	fingerIndex = 0;	
	 	touchCount = 0;
	 	startPosition = Vector2.zero;
	 	position = Vector2.zero;
	 	deltaPosition = Vector2.zero;	
	 	actionTime = 0;
	 	deltaTime = 0;		
	 	pickedCamera = null;
	 	pickedObject = null;
	 	isGuiCamera = false;
	 	isOverGui = false;
	 	pickedUIElement = null;
	    DoClear();
	}

	protected virtual void DoClear()
	{
		
	}
}
