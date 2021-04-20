using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [Header("追蹤範圍"),Range(0,500)]
    public float rangetrack = 2;
    [Header("攻擊範圍"), Range(0, 50)]
    public float rangeAttack = 0.5f;
    [Header("移動速度"), Range(0, 50)]
    public float speed = 2;
    [Header("攻擊特效")]
    public ParticleSystem psAttack;
    [Header("攻擊冷卻")]
    public float cdAttack = 3;
    [Header("攻擊力")]
    public float attack = 20;

    private Transform player;
    private float timer;

    private void Start()
    {
        player = GameObject.Find("主角").transform;
    }

    private void OnDrawGizmos()
    {
        //先指定顏色再畫圈
        Gizmos.color = new Color(0, 1, 0, 0.3F);
        //繪製球體(中心點.半徑)
        Gizmos.DrawSphere(transform.position, rangetrack);

       
        Gizmos.color = new Color(1, 0 , 0, 0.5F);
        Gizmos.DrawSphere(transform.position, rangeAttack);

    }

    private void Update()
    {
        Track();
    }

    /// <summary>
    /// 追蹤玩家
    /// </summary>

    private void Track()
    {
        //距離 等於 三維向量 的 距離(A點,B點)
        float dis = Vector3.Distance(transform.position, player.position);
        //如果 距離 小於等於 追蹤範圍 才開始追蹤
        if (dis <= rangeAttack)
        {

            Attack();

        }
        else if (dis<=rangetrack)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        //print("距離" + dis);
    }

    private void Attack()
    {
        timer += Time.deltaTime;


        if (timer >= cdAttack)
        {
            timer = 0;
            psAttack.Play();
        }


    }


}
