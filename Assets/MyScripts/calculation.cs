using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculation : MonoBehaviour
{

    [SerializeField] private int kisiSayisi;
    [SerializeField] private int elektrik;
    [SerializeField] private int su;
    [SerializeField] private int dogalgaz;
    [SerializeField] private int atikSu;

    public Text changingKisiSayisi;
    public Text changingElektrik;
    public Text changingSu;
    public Text changingDogalgaz;
    public Text changingAtikSu;

    public void CalculateValues1()
    {
        kisiSayisi += 15;
        elektrik += 750;
        su += 75;
        dogalgaz += 350;
        atikSu += 60;
        changingKisiSayisi.text = (kisiSayisi).ToString();
        changingElektrik.text = (elektrik).ToString();
        changingSu.text = (su).ToString();
        changingDogalgaz.text = (dogalgaz).ToString();
        changingAtikSu.text = (atikSu).ToString();
    }
    public void CalculateValues2()
    {
        kisiSayisi += 10;
        elektrik += 500;
        su += 50;
        dogalgaz += 250;
        atikSu += 40;
        changingKisiSayisi.text = (kisiSayisi).ToString();
        changingElektrik.text = (elektrik).ToString();
        changingSu.text = (su).ToString();
        changingDogalgaz.text = (dogalgaz).ToString();
        changingAtikSu.text = (atikSu).ToString();
    }
}
