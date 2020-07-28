using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIWalking : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;   //每个幽灵对应的navMeshAgent组件
    public Transform[] waypoints;       //存储一系列目标点的数组（目标点从外部拖入）

    int m_CurrentWaypointIndex;         //当前目标点的下标

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); //设置第一个目标点（下标为0）
    }

    void Update()
    {
        //如果离目标点剩余的距离小于设定的停止距离
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //计算下一个目标点。（当前下标+1）与数组长度取余数
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);    //更换目标点
        }


    }
}