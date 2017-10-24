using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCameraMove : MonoBehaviour {

    //public float sensitivityX = 8F;
    //public float sensitivityY = 8F;

    private Vector3 orginpos;
    float mHdg = 0F;
    float mPitch = 0F;

    public static bool Drag = false;

    void Update()
    {
        if(Drag == true)
        {
            //if (!(Input.GetMouseButton(0) || Input.GetMouseButton(1)))
            if (!(Input.GetMouseButton(0)))
                return;

            float deltaX = Input.GetAxis("Mouse X") * 3f;
            float deltaY = Input.GetAxis("Mouse Y") * 3f;

            //if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
            //if (Input.GetMouseButton(0))
            //{
            //    Strafe(deltaX);
            //    ChangeHeight(deltaY);
            //}
            //else
            //{
            if (Input.GetMouseButtonDown(0))
            {
                orginpos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                if (orginpos != Input.mousePosition)
                {
                    MoveForwards(deltaY);
                    ChangeHeading(deltaX);
                }
            }
            //else if (Input.GetMouseButton(1))
            //{
            //    ChangeHeading(deltaX);
            //    ChangePitch(-deltaY);
            //}
            //}
        }

    }

    void MoveForwards(float aVal)
    {
        Vector3 fwd = transform.forward;
        fwd.y = 0;
        fwd.Normalize();
        transform.position += aVal * fwd;
    }

    //void Strafe(float aVal)
    //{
    //    transform.position += aVal * transform.right;
    //}

    //void ChangeHeight(float aVal)
    //{
    //    transform.position += aVal * Vector3.up;
    //}

    void ChangeHeading(float aVal)
    {
        mHdg += aVal;
        WrapAngle(ref mHdg);
        transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
    }

    //void ChangePitch(float aVal)
    //{
    //    mPitch += aVal;
    //    WrapAngle(ref mPitch);
    //    transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
    //}

    public static void WrapAngle(ref float angle)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
    }
}
