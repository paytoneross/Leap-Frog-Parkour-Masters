using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Score : MonoBehaviour
{
    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Player2Score player2ScoreScript;

    //public int player1Score = 0;

    public bool player2IsIt = false;
    private int tagBackDelay = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (player2IsIt && other.gameObject.CompareTag("Player 1"))
        {
            player2IsIt = false;
            player2ScoreScript.player1IsIt = true;
            //player1Score += 1;
            StartCoroutine(AbleToScore());

            //player1ScoreText.text = "Player 1 Score: " + player1Score;
            player1ScoreText.text = "Player 1 is it!";
            Debug.Log("Tag!");
        }
    }

    private IEnumerator AbleToScore()
    {
        if (!player2IsIt)
        {
            yield return new WaitForSeconds(tagBackDelay);
            player2IsIt = true;
            Debug.Log("Player 1 Can Tag Back!");
        }
    }
}
