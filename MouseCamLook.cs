using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour
{
    Vector2 MouseLook;
    Vector2 SmoothV;
    public float sensitivity = 5f;
    public float smoothing = 2f;
    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        SmoothV.x = Mathf.Lerp(SmoothV.x, md.x, 1f / smoothing);
        SmoothV.y = Mathf.Lerp(SmoothV.y, md.y, 1f / smoothing);
        MouseLook += SmoothV;
        transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, character.transform.up);
    }
}
