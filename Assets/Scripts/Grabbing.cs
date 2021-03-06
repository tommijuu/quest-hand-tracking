using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using System;

public class Grabbing : OVRGrabber
{
    private OVRHand hand;
    private Vector3 lastPos;
    private Vector3 lastRot;
    public float pinchTreshold = 0.7f;

    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
    }

    public override void Update()
    {
        base.Update();
        CheckIndexPinch();
        lastPos = transform.position;
        lastRot = transform.eulerAngles;
    }

    private void CheckIndexPinch()
    {
        float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        bool isPinching = pinchStrength > pinchTreshold;

        if (!m_grabbedObj && isPinching && m_grabCandidates.Count > 0) //object not grabbed and pinching
            GrabBegin();
        else if (m_grabbedObj && !isPinching) //object grabbed but stopped pinching
            GrabEnd();
    }

    //OVRGrabber script's (Oculus Integration package script) GrabEnd works only with conrollers, 
    //let's make it work with hands by making it virtual and overriding here.
    //I want the objects to be throwable after all.
    protected override void GrabEnd()
    {
        if (m_grabbedObj)
        {
            Vector3 linearVelocity = (transform.parent.position - lastPos) / Time.fixedDeltaTime;
            Vector3 angularVelocity = (transform.parent.eulerAngles - lastRot) / Time.fixedDeltaTime;

            GrabbableRelease(linearVelocity, angularVelocity);
        }
        GrabVolumeEnable(true);
    }
}



