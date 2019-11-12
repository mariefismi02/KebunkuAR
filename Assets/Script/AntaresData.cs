using System;
using UnityEngine;

[Serializable]
public class AntaresData 
{
    public string rn;
    public string con;

    public AntaresData()
    {
        this.rn = "null";
        this.con = "null";
    }

    public AntaresData(string rn, string con)
    {
        this.rn = rn;
        this.con = con;
    }
}
