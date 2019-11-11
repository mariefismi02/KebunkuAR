using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Plant
{
    public string nama;
    public string deskripsi;
    public float suhu;
    public float ph;
    public Sprite icon;

    public Plant()
    {
        this.nama = "anon";
        this.deskripsi = "";
        this.suhu = 0;
        this.ph = 0;

    }
}
