using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Score : MonoBehaviour
{
    [SerializeField] private Text player1ItText;
    [SerializeField] private Text player2ItText;
    [SerializeField] private Text player2ScoreText;
    [SerializeField] private Player2Score player2ScoreScript;

    public int player2Score = 0;
    public bool player2IsIt = false;
    private int tagBackDelay = 2;
    private bool ableToTagBack = true;

    private void Start()
    {
        player2ScoreText.text = "Player 2 Score: " + player2Score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player2IsIt && ableToTagBack && other.gameObject.CompareTag("Player 2 Bullet"))
        {
            player2ScoreScript.player1IsIt = true;
            player2IsIt = false;
            player2Score += 1;
            StartCoroutine(AbleToScore());

            player2ScoreText.text = "Player 2 Score: " + player2Score;
            player1ItText.enabled = true;
            player2ItText.enabled = false;
            Debug.Log("Tag!");
        }
    }

    private IEnumerator AbleToScore()
    {
        if (!ableToTagBack)
        {
            yield return new WaitForSeconds(tagBackDelay);
            ableToTagBack = true;
            Debug.Log("Player 1 Can Tag Back!");
        }
    }
}
