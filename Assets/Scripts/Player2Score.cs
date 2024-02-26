using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Score : MonoBehaviour
{
    [SerializeField] private Text itText;
    [SerializeField] private Text player2ScoreText;
    [SerializeField] private Player1Score player1ScoreScript;

    private int player2Score = 0;
    public bool player2IsIt = false;
    private int tagBackDelay = 2;
    private bool ableToTagBack = true;

    private void OnTriggerEnter(Collider other)
    {
        if (player2IsIt && ableToTagBack && other.gameObject.CompareTag("Player 2"))
        {
            player2IsIt = false;
            player1ScoreScript.player1IsIt = true;
            player2Score += 1;
            StartCoroutine(AbleToScore());

            player2ScoreText.text = "Player 2 Score: " + player2Score;
            itText.text = "Player 2 is it!";
            //Debug.Log("Tag!");
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
