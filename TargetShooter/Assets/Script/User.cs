using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public string name;
    public int score;

    public User(string name, int score)
    {
        name = this.name;
        score = this.score;
    }
}
