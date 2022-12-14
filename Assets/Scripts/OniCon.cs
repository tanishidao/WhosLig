using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OniCon : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject playerT;
    public GameObject SnoopPoint;
    public float closedPos;
    public GameObject Fire;
    private Vector3 ranPos;
    //AnimationSpeedを変更
    float aniSpeed = 0.5f;
    Animator animator;
    // voice
    public AudioSource wanderVoice;
    public AudioSource laughVoice;
    public AudioClip howl, chase;
    //switch導入
    enum STATE { IDLE, WANDER, CHASE };
    STATE state = STATE.IDLE;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {

        // animator.SetFloat("Speed",aniSpeed);
        if (Fire.activeSelf == true)
        {
            closedPos = 10f;
        }
        else
        {
            closedPos = 30f;
        }
        if (DistanceToPlayer() < closedPos)
        {
            ChaseVoice();
            agent.SetDestination(playerT.transform.position);//player追いかける
            agent.speed = 7;

        }
        else
        {
            Howl(howl);



            agent.SetDestination(SnoopPoint.transform.position);//ランダム徘徊
            agent.speed = 5;


        }
        //switch (state)
        //{
        //    case STATE.IDLE:
        //        state = STATE.WANDER;


        //        break;
        //    case STATE.WANDER:

        //        if (DistanceToPlayer() < closedPos)
        //        {

        //            state = STATE.CHASE;

        //        }
        //        break;
        //    case STATE.CHASE:


        //        if (DistanceToPlayer() > closedPos)
        //        {

        //            state = STATE.WANDER;

        //        }

        //        break;


        //}


    }
    float DistanceToPlayer()//zombiとplayerの距離を返す
    {

        return Vector3.Distance(playerT.transform.position, transform.position);

    }
    public void Howl(AudioClip oniVo)
    {
        if (laughVoice.isPlaying)
        {
            laughVoice.Stop();
        }
        if (!wanderVoice.isPlaying)
        {
            wanderVoice.clip = oniVo;
            wanderVoice.Play();
        }
    }
    public void ChaseVoice()
    {
        if (wanderVoice.isPlaying)
        {
            wanderVoice.Stop();
        }
        if (!laughVoice.isPlaying)
        {
            laughVoice.clip = chase;
            laughVoice.Play();
        }
    }

}
