using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {

    Animator BloodAnimator;
    public bool Bleed;
    private float Timer=0.20F;
	void Start () {

        BloodAnimator = GetComponent<Animator>();
	}
	

	void Update () {
        BloodAnimator.SetBool("Damage", Bleed);
        if (Bleed)
        {
            Timer -= Time.deltaTime;
            if (Timer<=0)
            {
                Bleed = false;
                Timer = 0.20F;
            }
        }
		
	}
}
