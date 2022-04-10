using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] squares;
    private readonly List<int>[] _winConditions = {
        new List<int> {0, 1, 2},        
        new List<int> {3, 4, 5},
        new List<int> {6, 7, 8},
        new List<int> {0, 3, 6},
        new List<int> {1, 4, 7},
        new List<int> {2, 5, 8},
        new List<int> {0, 4, 8},
        new List<int> {2, 4, 6}
    };

    private Player _player1;
    private Player _player2;
    private Player _currentPlayer;
    private Player _winner;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _player1 = GameObject.Find("Player0").GetComponent<Player>();
        _player2 = GameObject.Find("Player1").GetComponent<Player>();
        _currentPlayer = _player1;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TakeMove()
    {
        Square square = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Square>();
        if (IsValidMove(square))
        {
            square.isOccupied = true;
            square.MarkTile(_currentPlayer.Sign);
            _currentPlayer.MakeMove(square);
            
            if (CheckForWin())
            {
                _winner = _currentPlayer;
                GameRenderer.EndGame(_winner.Sign);
                Debug.Log("Winner is " + _winner.Sign);
            }
            else if (CheckForDraw())
            {
                GameRenderer.EndGame(2);
            }
            else
            {
                SwitchPlayer();
            }
        }
    }

    private bool IsValidMove(Square square){
        if (square.isOccupied)
        {
            //GameRenderer.showTileOccupied();
            return false;
        }

        return true;
    }

    private void SwitchPlayer()
    {
        _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
    }

    private bool CheckForWin()
    {
        bool isWin = false;
        if (_currentPlayer.Table.Count < 3) return false;
        foreach (List<int> winCondition in _winConditions)
        {
            isWin = !winCondition.Except(_currentPlayer.Table).Any();
            if (isWin)
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckForDraw()
    {
        return _player1.Table.Count+_player2.Table.Count == 9;
    }
}
