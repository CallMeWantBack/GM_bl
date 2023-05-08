using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransFormPoint : MonoBehaviour
{

    public GameObject[] gos; //获取每个目标点，，注意数组顺序不能乱
    public float speed = 3; //用于控制移动速度
    int i = 0; //用于记录是第几个目标点
    float des; //用于存储与目标点的距离


    // Update is called once per frame
    void Update()
    {
        //看向目标点
        //this.transform.LookAt(gos[i].transform);
     
        ////计算与目标点间的距离
        //des = Vector3.Distance(this.transform.position, gos[i].transform.position);
        //switch (i)
        //{
        //    case 0:
        //        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -180f, 0), speed);
        //        break;
        //    case 1:
        //        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90f, 0), speed);
        //        break;
        //    case 2:
        //        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0f, 0), speed);
        //        break;
        //    case 3:
        //        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -270f, 0), speed);
        //        break;
        //    default:
        //        break;
        //}
        ////Debug.Log(Input.text);
        //////移向目标
        //transform.position = Vector3.MoveTowards(this.transform.position, gos[i].transform.position, Time.deltaTime * speed);
        //int x = 1;
        ////如果移动到当前目标点，就移动向下个目标
        //if (des < 0.1f && i < gos.Length - 1)
        //{
        //    i++;    
        //}
    }


}


