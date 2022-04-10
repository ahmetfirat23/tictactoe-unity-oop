using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRenderer : MonoBehaviour
{
    private static GameObject winObject;
    private static Animator winAnimator;

    private static readonly int OWins = Animator.StringToHash("oWins");
    private static readonly int XWins = Animator.StringToHash("xWins");
    private static readonly int Draw = Animator.StringToHash("draw");

    // Start is called before the first frame update
    void Start()
    {
        winObject = GameObject.Find("Win");
        winObject.SetActive(false);
    }

    public static void EndGame(int sign)
    {
        winObject.SetActive(true);
        winAnimator = winObject.GetComponent<Animator>();
        if (sign == 0)
        {
            winAnimator.SetTrigger(OWins);
        }
        else if (sign == 1)
        {
            winAnimator.SetTrigger(XWins);
        }
        else
        {
            winAnimator.SetTrigger(Draw);
        }
    }
}
