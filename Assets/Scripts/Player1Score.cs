using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Score : MonoBehaviour
{
    [SerializeField] private Text itText;
    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Player2Score player2ScoreScript;

    private int player1Score = 0;
    public bool player1IsIt = true;
    private int tagBackDelay = 2;
    private bool ableToTagBack = true;

    private void OnTriggerEnter(Collider other)
    {
        if (player1IsIt && ableToTagBack && other.gameObject.CompareTag("Player 1"))
        {
            player1IsIt = false;
            player2ScoreScript.player2IsIt = true;
            player1Score += 1;
            StartCoroutine(AbleToScore());

            player1ScoreText.text = "Player 1 Score: " + player1Score;
            itText.text = "Player 1 is it!";
            //Debug.Log("Tag!");
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
