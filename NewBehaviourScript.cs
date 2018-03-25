using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    public bool who = true; // true means tick false mean cross
    public string result = "";
    public int[,] arr = new int[3, 3];
    public Texture2D icon1;
    public Texture2D icon2;
    public Texture2D bg;
    public GUIStyle resultCustom;
    public GUIStyle bgCustom;
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), bg, bgCustom);
       
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 100, 100, 50), "Reset"))
        {
            reset();
        }
        if (result == "")
        {
            string turn;
            if (who) turn = "tick's run";
            else turn = "cross's run";
            GUI.Label(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 120, 80, 50), turn);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!canClick(i, j))
                    {
                        if (arr[i, j] == 1)
                            GUI.Label(new Rect(Screen.width / 2 - 75 + i * 50, Screen.height / 2 - 75 + j * 50, 50, 50), icon1);
                        else
                            GUI.Label(new Rect(Screen.width / 2 - 75 + i * 50, Screen.height / 2 - 75 + j * 50, 50, 50), icon2);
                    }
                    else if (GUI.Button(new Rect(Screen.width / 2 - 75 + i * 50, Screen.height / 2 - 75 + j * 50, 50, 50), ""))
                    {
                        if (who)
                            arr[i, j] = 1;
                        else
                            arr[i, j] = 2;
                        if (IsWin())
                        {
                            if (who)
                                result = "player1 tick win";
                            else
                                result = "player2 cross win";
                        }
                        else if (IsTie()) result = "tie";
                        who = !who;

                    }

                    
                    
                }
            }
        }
        else
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 75, 150, 150), result, resultCustom);
         
            
    }
    bool IsWin()
    {
        if (arr[0, 0] != 0 && arr[0, 0] == arr[1, 1] && arr[0, 0] == arr[2, 2])
            return true;
        if (arr[0, 2] != 0 && arr[0, 2] == arr[1, 1] && arr[0, 2] == arr[2, 0])
            return true;
        for (int i = 0; i < 3; i++)
            if (arr[0, i] != 0 && arr[0, i] == arr[1, i] && arr[0, i] == arr[2, i])
                return true;
        for (int i = 0; i < 3; i++)
            if (arr[i, 0] != 0 && arr[i, 0] == arr[i, 1] && arr[i, 0] == arr[i, 2])
                return true;
        return false;
    }

    void reset()
    {
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                arr[i, j] = 0;
        }
        result = "";
        
    }

    bool IsTie()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (arr[i, j] == 0) return false;
            }
        }
        return true;    
    }
    bool canClick(int x, int y)
    {
        if (arr[x, y] == 0) return true;
        else return false;
    }

}
