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

    [SerializeField] private Plant plant = new Hidroponik();

    [SerializeField] private TextMeshProUGUI detail;
    [SerializeField] private Image icon;

    [SerializeField] private Text umur;
    [SerializeField] private Text suhu;
    [SerializeField] private Text ph;
    [SerializeField] private Text air;
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

        RestClient.Get(new RequestHelper
        {
            Uri = "https://platform.antares.id:8443/~/antares-cse/antares-id/KebunKu/"+ subUri +"/la/",
            Headers = new Dictionary<string, string>
            {
                { "X-M2M-Origin", GameManager.instance.apiKey},
                { "Content-Type",  "application/json;ty=4"},
                { "Accept", "application/json"}
            }
        }).Then(res =>
        {

            string txt = res.Text.Substring(17, res.Text.Length - 20);
            var data = JsonUtility.FromJson<AntaresData>(txt);
            string[] values = data.con.Replace(" ", "").Split('|');
            foreach(string val in values)
            {
                string[] _val = val.Split(':');
                if (_val[0] == "PH")
                    plant.ph = float.Parse(_val[1]);

                if (_val[0] == "T" || _val[0] == "Temp")
                    plant.suhu = float.Parse(_val[1]);
            }

            plant.nama = vuMarkName;
            plant.deskripsi = vuMarkDesc;
            plant.icon = vuMarkIcon;

            nama.text = "<color=yellow><b>INFORMASI</b></color>\n" + plant.nama;
            umur.text = "<color=yellow><b>UMUR</b></color>\n" + 0 + " Hari";
            suhu.text = "<color=yellow><b>SUHU</b></color>\n" + plant.suhu + " Derajat";
            ph.text = "<color=yellow><b>PH TANAH</b></color>\n" + plant.ph;
            air.text = "<color=yellow><b>AIR</b></color>\n" + 0 + "%";
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
