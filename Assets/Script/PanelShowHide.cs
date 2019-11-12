using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelShowHide : MonoBehaviour
{

    //public Animator animator;
    public Image vuMarkImage;
    public Text vuMarkInfo;

    public GameObject CommonInfo;
    public GameObject DetailInfo;

    [SerializeField] private Plant plant = new Plant();

    [SerializeField] private TextMeshProUGUI detail;
    [SerializeField] private Image icon;

    [SerializeField] private Text data1;//ec
    [SerializeField] private Text suhu;
    [SerializeField] private Text ph;
    [SerializeField] private Text data4;//water level/humidity
    [SerializeField] private Text nama;

    public Plant Plant
    {
        get { return plant; }
    }


    public void Hide() {
        if(CommonInfo!=null)
        CommonInfo.SetActive(false);
        DetailInfo.SetActive(false);
    }


    public void Show(string vuMarkId, string vuMarkDataType, string vuMarkName, string vuMarkDesc, Sprite vuMarkImage, Sprite vuMarkIcon) {

        vuMarkInfo.text =
            "<color=yellow>VuMark Instance Id: </color>" +
            "\n" + vuMarkId + " - " + vuMarkName +
            "\n\n<color=yellow>VuMark Type: </color>" +
            "\n" + vuMarkDataType;

        this.vuMarkImage.sprite = vuMarkImage;
        Debug.Log(vuMarkName);

        string subUri = (vuMarkId == "0") ? "Hidroponik" : "PH-tanah";
        
        AntaresClient.Get(GameManager.instance.apiKey, "https://platform.antares.id:8443/~/antares-cse/antares-id/KebunKu/"+ subUri +"/la/")
            .Then(data =>
            {
                string[] values = data.con.Replace(" ", "").Split('|');
                foreach(string val in values)
                {
                    string[] _val = val.Split(':');
                    if (_val[0] == "PH")
                        plant.ph = float.Parse(_val[1]);

                    if (_val[0] == "T" || _val[0] == "Temp")
                        plant.suhu = float.Parse(_val[1]);

                    if (_val[0] == "WL")
                        plant.air = float.Parse(_val[1]);

                    if (_val[0] == "EC")
                        plant.ec = float.Parse(_val[1]);

                    if (_val[0][0] == 'H' && _val[0][1] - 48 == int.Parse(vuMarkId))//Jika Humidity & id = vumarkId
                        plant.kelembaban = float.Parse(_val[1]);


                }

                plant.nama = vuMarkName;
                plant.deskripsi = vuMarkDesc;
                plant.icon = vuMarkIcon;

                nama.text = "<color=yellow><b>INFORMASI</b></color>\n" + plant.nama;
                suhu.text = "<color=yellow><b>SUHU</b></color>\n" + plant.suhu + " Derajat";
                ph.text = "<color=yellow><b>PH TANAH</b></color>\n" + plant.ph;

                if (vuMarkId == "0")
                {
                    data1.text = "<color=yellow><b>ELECTROLIT CONDUCTIVITY</b></color>\n" + plant.ec + " mS";
                    data4.text = "<color=yellow><b>WATER LEVEL</b></color>\n" + plant.air + "%";
                }
                else
                {
                    data4.text = "<color=yellow><b>KELEMBABAN</b></color>\n" + plant.kelembaban + "%";
                    data1.text = "<color=yellow><b>ELECTROLIT CONDUCTIVITY</b></color>\n" + 0 + " mS";
                }

                detail.text = plant.deskripsi;
                icon.sprite = plant.icon;

            }).Catch(err =>
            {
                Debug.Log(err.Message);
            });

        if (CommonInfo != null)
            CommonInfo.SetActive(true);

    }

    public void ResetShowTrigger() {
        if (CommonInfo != null) 
            CommonInfo.SetActive(true);
        if (DetailInfo != null)
            CommonInfo.SetActive(false);
    }

    public void ShowDetail()
    {
        Debug.Log("Show Detail");
        if (DetailInfo != null)
            DetailInfo.SetActive(true);
        if(CommonInfo != null)
            CommonInfo.SetActive(false);
    }



}
