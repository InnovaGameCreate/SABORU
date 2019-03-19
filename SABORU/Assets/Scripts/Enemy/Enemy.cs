using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //巡回する地点
    public Transform[] patrolPoints;
    //巡回する地点の数
    private int destinationPointNum = 0;
    //NavMesh Agentを格納する変数
    private NavMeshAgent agent;
    //Playerオブジェクト格納用変数
    public GameObject Player;
    //Rayの作成
    Ray ray;
    //rayで当たったオブジェクトの情報を格納
    RaycastHit hit;
    //rayの飛ばせる距離
    int rayDistance = 25;


    void Start()
    {
        //agentにNavMeshコンポーネントを格納
        agent = GetComponent<NavMeshAgent>();
        //敵が巡回地点に近づいても減速をしない
        agent.autoBraking = false;
        //次の巡回地点を設定
        GoToNextPoint();
        
    }

    void GoToNextPoint() {
        //巡回地点がセットされていない時
        if (patrolPoints.Length == 0)
            return;
        //巡回地点を代入
        agent.destination = patrolPoints[destinationPointNum].position;
        //次の巡回地点を代入
        destinationPointNum = (destinationPointNum + 1) % patrolPoints.Length;
    }

    void Update()
    {
        ////巡回地点に到達したら
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        //次の巡回地点を設定
        GoToNextPoint();
        //進行方向にrayを飛ばす
        ray = new Ray(transform.position, this.transform.forward);
        //rayの描画
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        //rayがオブジェクトに当たると
        if(Physics.Raycast(ray,out hit,rayDistance)){
            //Playerにあたると
            if (hit.collider.tag == "Player")
                Debug.Log("Player Ray!!!");
            //Playerを消す
            Destroy(Player);
        }
    }
}
