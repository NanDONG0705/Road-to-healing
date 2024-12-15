using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDection : MonoBehaviour
{

   
    private VRChange change;
   
    
    public GameObject player;  //���
    public GameObject[] Cubes;  //��������cube��������ƶ�alongPointMove��Ҫ�����ĵ�
  
    
    
    private AlongPointMove alongPointMove; //�������Žű�
                                           //public string whichAction;  //��ͬ�Ĺؿ��������ò�ͬ��action�������ֱ������������һ��Ĭ�ϵĶ���

    public ExerciseType whichAction;
    public int gameType;

    private void Start()
    {
 
        change = player.GetComponent<VRChange>();
        alongPointMove = player.GetComponent<AlongPointMove>(); //��ȡ������ϵ�alongPointMove�ű�

    }



    //��������ؿ�������alongPointMove�ƶ���Ҫ�����ĵ㸳ֵ���ű�
    private void OnTriggerEnter(Collider other)
    {

        
        // ��鴥������������Ƿ������
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


    //������������


}
