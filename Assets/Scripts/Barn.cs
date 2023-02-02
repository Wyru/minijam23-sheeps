using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Barn : MonoBehaviour
{

    public static event Action<Sheep> OnStoreSheep;

    public void StoreSheep(Sheep s){
        if(OnStoreSheep != null){
            OnStoreSheep.Invoke(s);
        }
        Destroy(s.gameObject);
    }

}
