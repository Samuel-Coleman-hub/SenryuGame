using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Poem
{
    public string poemContents;
    public string poemName;
    public string poemAuthor;
    public int poemEnviroment;

    public Poem(string poemCont, string poemNam, string poemAuth, int poemEnv)
    {
        poemContents = poemCont;
        poemName = poemNam;
        poemAuthor = poemAuth;
        poemEnviroment = poemEnv;
    }
}

