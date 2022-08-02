using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCon : MonoBehaviour
{
    //視点
    public GameObject FPScamera;
    private float minX = -90f, maxX = 90f;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;
    //ダッシュ
    public Slider dashBar;
    public float dashSpeed;
    private bool isDash;
    float x, z;
    float speed = 0.05f;
    float pspeed;
    public float dashPo;
    float dashMax;
    
    bool cursorLock = true;
    void Start()
    {
        cameraRot = FPScamera.transform.localRotation;
        characterRot = transform.localRotation;
        isDash = false;
        dashBar.value = dashPo;
        dashMax = dashPo;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);


        cameraRot = ClampRotation(cameraRot);

        FPScamera.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;
        UpdateCursorLock();

        if (Input.GetKey(KeyCode.E))
        {
            isDash = false;
        }
        if (isDash)
        {
            dashPo = Mathf.Clamp(dashPo - Time.deltaTime, 0, dashMax);//クランプ使ってゲージ減らす
            dashBar.value = dashPo;
        }
        else
        {
            dashPo = Mathf.Clamp(dashPo + Time.deltaTime, 0, dashMax);//クランプ使ってゲージ増やす
            dashBar.value = dashPo;
        }
       

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && dashBar.value >= 0.5)
        {
            pspeed = dashSpeed;
            isDash = true;

        }
        else
        {
            pspeed = speed;
            isDash = false;

        }



        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * pspeed;
        z = Input.GetAxisRaw("Vertical") * pspeed;
        Vector3 camForward = FPScamera.transform.forward;
        camForward.y = 0;

        transform.position += camForward * z + FPScamera.transform.right * x;


    }
    public Quaternion ClampRotation(Quaternion q)
    {


        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
    public void UpdateCursorLock()//カーソル隠す
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void PlayerDash()
    {

    }
}
