using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasBTN : MonoBehaviour {
    public int gasFactor = 30;
    public void onGasBTN()
    {
        if (this.GetComponent<Rigidbody2D>() != null)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,gasFactor*  1f ));

        }
    }
}
