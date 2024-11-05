using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDection : MonoBehaviour
{

   
    private VRChange change;
   
    
    public GameObject player;  //玩家
    public GameObject[] Cubes;  //这个数组的cube代表玩家移动alongPointMove需要经过的点
  
    
    
    private AlongPointMove alongPointMove; //动画播放脚本
    //public string whichAction;  //不同的关卡可以设置不同的action，你可以直接先让他等于一个默认的动作


    public ExerciseType whichAction;
    public int gameType;


    //Redefine in seperate file
    //public enum ExerciseType
    //{
    //    ANKLE_PUMP = 1,
    //    ANKLE_ROTATION = 2,
    //    QUADRICEPS_SET = 3,
    //    STRAIGHT_LEG_RAISES = 4,
    //    BED_SUPPORTED_KNEE_BENDS = 5,
    //    SITTING_UNSUPPORTED_KNEE_BENDS = 6
    //};



    private void Start()
    {
 
        change = player.GetComponent<VRChange>();
        alongPointMove = player.GetComponent<AlongPointMove>(); //获取玩家身上的alongPointMove脚本

    }



    //玩家碰到关卡后把这次alongPointMove移动需要经过的点赋值给脚本
    private void OnTriggerEnter(Collider other)
    {

        
        // 检查触发进入区域的是否是玩家
        if (other.CompareTag("Player"))
        {
            Debug.Log("In the area");
            change.Moveable = true;
            change.currExerciseType = whichAction;
            change.gameType = gameType;

            alongPointMove.point0 = Cubes[0].transform;
            alongPointMove.point1 = Cubes[1].transform;
            alongPointMove.point2 = Cubes[2].transform;
            alongPointMove.point3 = Cubes[3].transform;
           
        }
    }


    //当玩家在这个区


}
