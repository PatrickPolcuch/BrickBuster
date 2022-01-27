using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Paddle Paddle;
    public Ball Ball;
    public Readouts Readouts;
    public static Game Instance;

    private int score;
    private int ballsRemaining;
    private Levels Levels;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
        Levels = gameObject.GetComponent<Levels>();
    }

    private void Start()
    {
        Reset();
    }

    public void LoseBall()
    {
        Ball.CreateDeathEffect();
        DisableGameplay();
        UpdateNumberOfBalls(ballsRemaining-1);
        CheckForGameOver();
        Sounds.Instance.PlayLoseBall();
    }

    public void DisableGameplay()
    {
        Paddle.Disable();
        Ball.Disable();
    }

    public void BrickBreak()
    {
        UpdateScore(score + 10);
        CheckIfWon();
    }


    private void CheckIfWon()
    {
        if (CountBricks() == 0)
        {
            DisableGameplay();
            Levels.GoToNextLevel();
            if (Levels.IsGameOver())
                WinGame();
            else ResetAfterBallLoss();
        }
    }

    private void WinGame()
    {
        Readouts.ShowWinResult();
    }

    private void CheckForGameOver()
    {
        if (ballsRemaining == 0)
            LoseGame();
        else
            ResetAfterBallLoss();
    }

    private void Reset()
    {
        UpdateNumberOfBalls(3);
        UpdateScore(0);
        Readouts.Reset(ballsRemaining);
        Sounds.Instance.PlayStart();
    }

    private void LoseGame()
    {
        Readouts.ShowLoseResult();
        Sounds.Instance.PlayGameOver();
    }

    private void ResetAfterBallLoss()
    {
        Paddle.Reset();
        Ball.Reset();
    }
    private void UpdateNumberOfBalls(int numberOfBalls)
    {
        ballsRemaining = numberOfBalls;
        Readouts.ShowBallsRemaining(ballsRemaining);
    }
    private void UpdateScore(int newScore)
    {
        score = newScore;
        Readouts.ShowScore(score);
    }

    private int CountBricks()
    {
        return GameObject.FindGameObjectsWithTag("Brick").Length-1;
    }
}
