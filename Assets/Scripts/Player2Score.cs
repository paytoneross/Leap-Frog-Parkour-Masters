using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Score : MonoBehaviour
{
    [SerializeField] private Text player2ScoreText;
    [SerializeField] private Player1Score player1ScoreScript;

    //public int player2Score = 0;

    public bool player1IsIt = true;
    private int tagBackDelay = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (player1IsIt && other.gameObject.CompareTag("Player 1"))
        {
            player1IsIt = false;
            player1ScoreScript.player2IsIt = true;
            //player1Score += 1;
            StartCoroutine(AbleToScore());

            //player1ScoreText.text = "Player 1 Score: " + player1Score;
            player2ScoreText.text = "Player 2 is it!";
            Debug.Log("Tag!");
        }
    }

    private IEnumerator AbleToScore()
    {
        if (!player1IsIt)
        {
            yield return new WaitForSeconds(tagBackDelay);
            player1IsIt = true;
            Debug.Log("Player 2 Can Tag Back!");
        }
    }
}
