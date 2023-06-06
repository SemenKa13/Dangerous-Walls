using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    public bool isMove;
    public int score;
    public int bestScore;
    [SerializeField] Text scoreDisplay;
    [SerializeField] Text bestScoreDisplay;
    [SerializeField] Text finalText;
    public GameObject TextNewRecord;
    public GameObject GameOverMenuPanel;
    public GameObject Canvas;
    public GameObject SoundDeath;
    public GameObject SoundTurn;
    public GameObject SoundBonus;
    public GameObject SondHit;
    public GameObject SondGameOver;

    public Animator animScore;
    public GameObject Score;
    void Start()
    {
        bestScoreDisplay.text = PlayerPrefs.GetInt("best", 0).ToString();

        animScore = Score.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isMove == true) {
            transform.Translate(Vector2.up * speed);
        }
        else if(isMove == false) {
            transform.Translate(Vector2.up * -speed);
        }

        scoreDisplay.text = score.ToString();
        finalText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("best", 0)) { //ƒÀﬂ —¡–Œ—¿ –≈ Œ–ƒ¿ œŒÃ≈Õﬂ“‹ ">" Õ¿ "<"!
            TextNewRecord.SetActive(true);
            PlayerPrefs.SetInt("best", score);
            bestScoreDisplay.text = score.ToString();
        }
    }

    public void OnClickPan() {
        isMove = !isMove;
        Instantiate(SoundTurn, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Walls")) {
            Instantiate(SondHit, transform.position, Quaternion.identity);
            speed *= -1;
        }

        if (other.CompareTag("Enemy")) {
            Instantiate(SoundDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Time.timeScale = 1;
            GameOverMenuPanel.SetActive(true);
            Instantiate(SondGameOver, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Bonus")) {
            Instantiate(SoundBonus, transform.position, Quaternion.identity);
            score++;
            animScore.SetTrigger("PlayScore");
        }
    }
}