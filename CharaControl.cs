using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HedgehogTeam.EasyTouch;
using System;
using Bolt;

public class CharaControl : MonoBehaviour
{
    [SerializeField]
    private ETCJoystick joystick;
    [SerializeField]
    private Button m_btnStep;

    public ETCJoystick.OnMoveEndHandler On_MoveEnd { get; private set; }


    void OnEnable()
    {
        EasyTouch.On_SwipeStart += On_SwipeStart;
        EasyTouch.On_Swipe += On_Swipe;
        EasyTouch.On_SwipeEnd += On_SwipeEnd;

        EasyTouch.On_SwipeStart2Fingers += On_SwipeStart2Fingers;
        EasyTouch.On_Swipe2Fingers += On_Swipe2Fingers;
        EasyTouch.On_SwipeEnd2Fingers += On_SwipeEnd2Fingers;

        joystick.onMoveStart.AddListener(()=>
        {
            CustomEvent.Trigger(gameObject, "onMoveStart");
        });
        joystick.onMove.AddListener((arg)=>
        {
            //Debug.Log(arg);
            CustomEvent.Trigger(gameObject, "onMove", arg);
        });
        joystick.onMoveEnd.AddListener(() =>
        {
            CustomEvent.Trigger(gameObject, "onMoveEnd");
        });

        m_btnStep.onClick.AddListener(() =>
        {
            CustomEvent.Trigger(gameObject, "OnButtonStepStep");
        });
    }
    // Unsubscribe
    void OnDisable()
    {
        EasyTouch.On_SwipeStart -= On_SwipeStart;
        EasyTouch.On_Swipe -= On_Swipe;
        EasyTouch.On_SwipeEnd -= On_SwipeEnd;

        EasyTouch.On_SwipeStart2Fingers -= On_SwipeStart2Fingers;
        EasyTouch.On_Swipe2Fingers -= On_Swipe2Fingers;
        EasyTouch.On_SwipeEnd2Fingers -= On_SwipeEnd2Fingers;

        joystick.onMoveStart.RemoveAllListeners();
        joystick.onMove.RemoveAllListeners();
        joystick.onMoveEnd.RemoveAllListeners();

        m_btnStep.onClick.RemoveAllListeners();
    }

    private void On_SwipeStart(Gesture gesture)
    {
        //Debug.Log(gesture.type);
        CustomEvent.Trigger(gameObject, "On_SwipeStart");
    }
    private void On_Swipe(Gesture gesture)
    {
        //Debug.Log(gesture.type);
        CustomEvent.Trigger(gameObject, "On_Swipe" , gesture.deltaPosition);
    }
    private void On_SwipeEnd(Gesture gesture)
    {
        //Debug.Log(gesture.type);
        CustomEvent.Trigger(gameObject, "On_SwipeEnd");
    }

    private void On_SwipeStart2Fingers(Gesture gesture)
    {
        //Debug.Log(gesture.type);
        CustomEvent.Trigger(gameObject, "On_SwipeStart2Fingers");
    }
    private void On_Swipe2Fingers(Gesture gesture)
    {
        //Debug.Log(gesture.type);
        CustomEvent.Trigger(gameObject, "On_Swipe2Fingers");
    }
    private void On_SwipeEnd2Fingers(Gesture gesture)
    {
        //Debug.Log(gesture.type);
        CustomEvent.Trigger(gameObject, "On_SwipeEnd2Fingers");
    }

    public void OnStepEnd()
    {
        CustomEvent.Trigger(gameObject, "OnStepEnd");
    }

    public void OnAnimationEvent(AnimationEvent _event)
    {
        CustomEvent.Trigger(gameObject, _event.stringParameter);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
