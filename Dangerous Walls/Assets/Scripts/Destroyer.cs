using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
    public float lifeTime; //Время жизни (для удаления)

    void Start() {
        Destroy(gameObject, lifeTime);
    }
}