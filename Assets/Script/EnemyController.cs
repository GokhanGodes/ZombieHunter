using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    public GameObject[] Prefabs;
    private Vector2 Vector1;
    private int count, OrcInstantiateCount=0,skor;
    public float Timer,SpeedTimer=2f,TimerMin=2.5F,TimerMax=3.5F;
    

	void Start () {
        TimerMin = 2.5F;
        TimerMax = 3.5F;
        Timer = Random.Range(TimerMin,TimerMax);
	}
	
	void Update () {
        Timer -= Time.deltaTime;
        SpeedTimer -= Time.deltaTime;

        if (Timer <= 0)
        {
            ObjectCreate();
            Timer = Random.Range(TimerMin, TimerMax);
        }
        if(SpeedTimer<=0)
        {
            Statik.ZombieSpeed += (Statik.ZombieSpeed / 100);
            SpeedTimer = 2f;
        }
        if(Statik.OrcIsDead==true)
        {
            OrcInstantiateCount = 0;
        }

    }
    public void ObjectCreate()
    {
        if(Statik.Skor>=0 && Statik.Skor<50)
        {
            count = Random.Range(0, 3);
            Vector1.x = 20;
            Vector1.y = Random.Range(-6.5f, 6.5f);
            Instantiate(Prefabs[count], Vector1, Quaternion.identity);
        }
        if(Statik.Skor>=50 && Statik.Skor <= 65 && !Statik.OrcIsDead)
        {
            count =6;
            Vector1.x = 20;
            Vector1.y = Random.Range(-6.5f, 6.5f);
            if(OrcInstantiateCount==0)
            {
                Instantiate(Prefabs[count], Vector1, Quaternion.identity);
                OrcInstantiateCount++;
            }
        }

        if(Statik.Skor>50 && Statik.Skor<120)
        {
            count = Random.Range(0, 5);
            Vector1.x = 20;
            Vector1.y = Random.Range(-6.5f, 6.5f);
            Instantiate(Prefabs[count], Vector1, Quaternion.identity);
            TimerMin = 1.25F;
            TimerMax = 2.25F;
        }
        if (Statik.Skor>=120 && Statik.Skor <= 135 && !Statik.OrcIsDead)
        {
            count = 7;
            Vector1.x = 20;
            Vector1.y = Random.Range(-6.5f, 6.5f);
            if (OrcInstantiateCount == 0)
            {
                Instantiate(Prefabs[count], Vector1, Quaternion.identity);
                OrcInstantiateCount++;
            }
        }

        if (Statik.Skor>120 && Statik.Skor<190)
        {
            count = Random.Range(0, 6);
            Vector1.x = 20;
            Vector1.y = Random.Range(-6.5f, 6.5f);
            Instantiate(Prefabs[count], Vector1, Quaternion.identity);
            TimerMin = 1F;
            TimerMax = 2F;
        }
        if(Statik.Skor>=190 && Statik.Skor <= 205 && !Statik.OrcIsDead)
        {
            count = 8;
            Vector1.x = 20;
            Vector1.y = Random.Range(-6.5f, 6.5f);
            if (OrcInstantiateCount == 0)
            {
                Instantiate(Prefabs[count], Vector1, Quaternion.identity);
                OrcInstantiateCount++;
            }

        }
        if(Statik.Skor>190)
        {
            count = Random.Range(0, 6);
            Vector1.x = 20;
            Vector1.y = Random.Range(-6.5f, 6.5f);
            Instantiate(Prefabs[count], Vector1, Quaternion.identity);
            TimerMin = 0.75F;
            TimerMax = 1.75F;
            //if(Statik.Skor %50==0 || Statik.Skor % 50 == 1 || Statik.Skor % 50 == 2 || Statik.Skor % 50 == 3 || Statik.Skor % 50 == 4 || Statik.Skor % 50 == 5 || Statik.Skor % 50 == 6)
            //{
            //    count = Random.Range(6,9);
            //    Vector1.x = 20;
            //    Vector1.y = Random.Range(-6.5f, 6.5f);
            //    if (OrcInstantiateCount == 0)
            //    {
            //        Instantiate(Prefabs[count], Vector1, Quaternion.identity);
            //        OrcInstantiateCount++;
            //    }
            //}
            for (int i = 0; i <= 10; i++)
            {
                if(Statik.Skor %50==i)
                {
                    count = Random.Range(6, 9);
                    Vector1.x = 20;
                    Vector1.y = Random.Range(-6.5f, 6.5f);
                    if (OrcInstantiateCount == 0)
                    {
                        Instantiate(Prefabs[count], Vector1, Quaternion.identity);
                        OrcInstantiateCount++;
                    }
                }
            }
        }

    }
}
