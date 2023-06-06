using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject[] enemy;
    public float minSec;
    public float maxSec;
    private int flag;
    public float MaxTime;
    public float DelTime;
    public float XTime;

    void Start() {
        flag = 1;
        StartCoroutine(SpawnEnemy());
    }

    private void FixedUpdate() {
        if (Time.timeScale < MaxTime) {
            Time.timeScale += DelTime;
            XTime = Time.timeScale;
        }
    }

    private void Repeat() {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        if (flag == 1) { //Низ
            flag = 2;
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
            Instantiate(enemy[1], new Vector2(3.5f, Random.Range(-0.4f, -0.15f)), Quaternion.identity);
            Repeat();
        }
        else if(flag == 2) { //Верх
            flag = 1;
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
            Instantiate(enemy[0], new Vector2(3.5f, Random.Range(2.05f, 2.45f)), Quaternion.identity);
            Repeat();
        }
    }
}