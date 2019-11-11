using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[System.Serializable]
public class Plant
{
    public string nama;
    public string deskripsi;
    public float suhu;
    public float ph;
    public float air;
    public float kelembaban;
    public float ec;
    public Sprite icon;

    public Plant()
    {
        this.nama = "anon";
        this.deskripsi = "";
        this.suhu = 0;
        this.ph = 0;
        this.ec = 0;
        this.air = -1;
        this.kelembaban = 0;
    }
}
