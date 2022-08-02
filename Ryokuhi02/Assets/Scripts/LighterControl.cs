using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterControl : MonoBehaviour
{


    public GameObject wheel;
    public GameObject lighterswitch;
    public GameObject fire;
    public GameObject fireLight;
    public GameObject spark;
    public GameObject leverGoal;

    private Vector3 ressetPos;
    private Vector3 previPos;
    private int firecount;

    private float ActiveTime;

    private bool hibanaFlag;
    public float burnOutTime;//消える秒数
    private float burnTime;
    //Sound
    public AudioSource SpSound;
        public AudioClip SparkSE;
    private void Start()
    {
        ressetPos = lighterswitch.transform.position;

        hibanaFlag = false;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1)&&fire.activeSelf == false)
        {
            PlaySpark(SparkSE);//火花音ならす

            spark.SetActive(true);//火花パーティクル
            hibanaFlag = true; // 火花散る
            wheel.transform.Rotate(-60, 0, 0);//火打石回る
            lighterswitch.transform.position -= new Vector3(0, 0.01f, 0);//レバー下がる
            firecount += Random.Range(1, 10);
        }
        if (firecount > 5)//5以上だったら着火
        {
            fire.SetActive(true);
            fireLight.SetActive(true);
            Debug.Log("Fire");
            burnTime += Time.deltaTime;
        }
        else//つかなかったらレバー戻す
        {
            BackPos();
        }
        if(burnTime >= burnOutTime)
        {
            fire.SetActive(false);
            fireLight.SetActive(false);
            firecount = 0;
            burnTime = 0;

        }
        //if (!Input.GetMouseButtonDown(1))
        //  {
        // Fire.SetActive(false);
        //  firecount = 0;

        //   BackPos();
        //  GasSound.Stop();


        //   }

        if (hibanaFlag)//hibanaAnimation
        {
            ActiveTime += Time.deltaTime;
            if (ActiveTime > 0.2)///火花
            {

                spark.SetActive(false);
                ActiveTime = 0;
                hibanaFlag = false;
            }
        }


    }
    public void PlaySpark(AudioClip clip)
    {
        SpSound.clip = clip;
        SpSound.Play();
    }
    public void BackPos()
    {
        lighterswitch.transform.position = Vector3.MoveTowards(lighterswitch.transform.position, leverGoal.transform.position, Time.deltaTime * 0.05f);

    }
    public void Burn()
    {
        
    }

}
