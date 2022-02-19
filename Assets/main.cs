using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    Text isletmeIsim, sohret, servet, sohret1, servet1, isletmeBilgi, seviyeNum, kararSorusu;
    GameObject sonrakiLvlPanel;

    public int anlikSohret = 0;
    public int anlikServet = 0;
    public int calisanMenuniyet = 0;

    // Start is called before the first frame update
    void Start()
    {

        isletmeIsim = GameObject.FindGameObjectWithTag("isletmeIs�m").GetComponent<Text>();
        sohret = GameObject.FindGameObjectWithTag("sohret").GetComponent<Text>();
        servet = GameObject.FindGameObjectWithTag("servet").GetComponent<Text>();
        sohret1 = GameObject.FindGameObjectWithTag("sohret1").GetComponent<Text>();
        servet1 = GameObject.FindGameObjectWithTag("servet1").GetComponent<Text>();
        isletmeBilgi = GameObject.FindGameObjectWithTag("isletmeBilgi").GetComponent<Text>();
        seviyeNum = GameObject.FindGameObjectWithTag("seviyeNum").GetComponent<Text>();
        kararSorusu = GameObject.FindGameObjectWithTag("kararSorusu").GetComponent<Text>();

        sonrakiLvlPanel = GameObject.FindGameObjectWithTag("sonrakilvlPanel");

        soruhazirla();
    }

    // Update is called once per frame
    void Update()
    {

        isletmeIsim.text = "d";
        sohret.text = "d";
        servet.text = "d";
        sohret1.text = "d";
        servet1.text = "d";
        isletmeBilgi.text = "123456789123456789";
        seviyeNum.text = "d";
        kararSorusu.text = "d";

        sonrakiLvlPanel.SetActive(false);


    }

    void soruDegistir()
    {

    }

    void yeniIsletmeYukle()
    {

    }

    void sonrakiLvl()
    {

    }

    void kaybettin()
    {

    }

    void soruhazirla()
    {
        string[] adlar = { "KAFE", "BAKKAL", "DERSHANE", "KIYAFET MA�AZASI", "ELEKTRON�K MA�AZASI" };

        string[,] sorular = new string[5, 5] { {
        "kahve otomat�",
        "bah�e temal� konsept ",
        "ka�ak kat ��k�p parti",
        "koltuklar�n de�i�imi",
        "�al��anlardan memnun olmas�nlar"
         },
         {
        "�r�nler i artt�rma",
        "�irket geni�letme",
        "mallar�n fiyat�n� artt�rma",
        "mallara indirim yapt�rma",
        "tarihi ge�mi� bir �r�n satt���n�z s�yleniyor"
         },
         {
        "��renciler daha iyi yay�n istiyorlar",
        "reklam yap�p ��renci say�s�n� artt�rma",
        "dershane bah�esini d�zenleme",
        "dershane s�ralar�n� d�zenleme",
        "��retmenler ders saatlerinin k�salmas�n� istiyor"
         },{
        "�al��anlar fazla �al��t�klar�n� d���n�yorlar",
        "yeni kiyaftler gelsin mi ",
        "yan ma�azalar�da sat�n al�p geni�lesin mi",
        "m��teriler yerler kirli diye �ikayet ediyorlar",
        "kabinler k�t� kokuyor koku sistemi tak�ls�n" },
         {
        "firmaya yeni laptoplar isteniyor",
        "firmada ki �r�nlere tester olmas�n� isteniyor",
        "�r�nler i 1 hafta deneme �ans� isteniyor ",
        "�al��anlar fazla �al���yoruz diye isyan ediyorlar",
        "yeni ev aletleri istiyor m��teriler "
         }
         };
        int c = 0;
        isletme[] isletmeler = new isletme[5];

        foreach (string s in adlar)
        {
            isletmeler[c] = new isletme();
            isletmeler[c].isletmeEkle(c, adlar[c], adlar[c], Random.Range(1, 9), Random.Range(10000, 500000), Random.Range(1, 9), Random.Range(10000, 500000), Random.Range(1, 5));
            Debug.Log(isletmeler[c].kararlar.Length);
            for (int i = 0; i < isletmeler[c].kararlar.Length; i++)
            {
                try
                {
                    isletmeler[c].kararlar[i].kararEkle(c, sorular[c, i], Random.Range(1, 3));
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.ToString());
                }
            }

            c++;
        }

        foreach (isletme isl in isletmeler)
        {
            foreach (karar ks in isl.kararlar)
            {
                Debug.Log(isl.ad + " " + ks.soru);
            }
        }

    }

}

public class isletme
{
    public int id;
    public string ad;
    public string bilgi;
    public int sohret;
    public int servet;
    public int istenenSohret;
    public int istenenServet;
    public int calisanMemnuniyeti;
    public karar[] kararlar = new karar[5];

    public void isletmeEkle(int a, string b, string c, int d, int e, int f, int g, int h)
    {
        this.id = a;
        this.ad = b;
        this.bilgi = c;
        this.sohret = d;
        this.servet = e;
        this.istenenSohret = f;
        this.istenenServet = g;
        this.calisanMemnuniyeti = h;
    }
}

public class karar
{
    public int kid;
    public string soru;
    public int etki; // *10000=servete etki

    public void kararEkle(int a, string b, int c)
    {
        this.kid = a;
        this.soru = b;
        this.etki = c;
    }

}


