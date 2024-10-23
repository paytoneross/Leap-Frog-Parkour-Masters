using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Score : MonoBehaviour
{
    [SerializeField] private Text player1ItText;
    [SerializeField] private Text player2ItText;
    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Player1Score player1ScoreScript;

    public int player1Score = 0;
    public bool player1IsIt = true;
    private int tagBackDelay = 2;
    private bool ableToTagBack = true;

    private void OnTriggerEnter(Collider other)
    {
        if (player1IsIt && ableToTagBack && other.gameObject.CompareTag("Player 1 Bullet"))
        {
            player1IsIt = false;
            player1ScoreScript.player2IsIt = true;
            player1Score += 1;
            StartCoroutine(AbleToScore());

            player1ScoreText.text = "Player 1 Score: " + player1Score;
            player2ItText.enabled = true;
            player1ItText.enabled = false;
            Debug.Log("Tag!");
        }
    }

    private IEnumerator AbleToScore()
    {
        if (!ableToTagBack)
        {
            yield return new WaitForSeconds(tagBackDelay);
            ableToTagBack = true;
            Debug.Log("Player 2 Can Tag Back!");
        }
    }
}
