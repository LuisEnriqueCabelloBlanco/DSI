using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab3Manipulator : Manipulator
{
    private bool isClicked = false;
    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseEnterEvent>(OnMouseEnter);
        target.RegisterCallback<MouseLeaveEvent>(OnMouseExit);
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        target.RegisterCallback<MouseUpEvent>(OnMouseUp);
        target.RegisterCallback<WheelEvent>(OnWheeel);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseEnterEvent>(OnMouseEnter);
        target.UnregisterCallback<MouseLeaveEvent>(OnMouseExit);
    }

    private void OnMouseEnter(MouseEnterEvent mev)
    {
        target.style.borderBottomColor = Color.white;
        target.style.borderLeftColor = Color.white;
        target.style.borderRightColor = Color.white;
        target.style.borderTopColor = Color.white;
        mev.StopPropagation();
    }
    private void OnMouseExit(MouseLeaveEvent mle)
    {
        target.style.borderBottomColor = Color.black;
        target.style.borderLeftColor = Color.black;
        target.style.borderRightColor = Color.black;
        target.style.borderTopColor = Color.black;
        mle.StopPropagation();
    }
    private void OnMouseDown(MouseDownEvent mde)
    {
        isClicked = (mde.button == 0);
        mde.StopPropagation();
    }
    private void OnMouseUp(MouseUpEvent mde)
    {
        if (mde.button == 0)
             isClicked = false;
        mde.StopPropagation();
    }
    private void OnWheeel(WheelEvent wev)
    {
        if (isClicked)
        {
            Vector2 size = target.layout.size;
            Vector2 d = wev.delta;
            Vector2 pos = target.layout.position;
            Debug.Log(d);
            target.style.width =  size.x + d.y;
            target.style.height = size.y + d.y;
            //target.style.position = d;
        }
    }
}
