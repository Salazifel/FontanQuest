using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle
{
    public string RiddleText;
    public string Solution;
    public string Hint;

    public Riddle(string riddle, string solution, string hint)
    {
        RiddleText = riddle;
        Solution = solution;
        Hint = hint;
    }
}
