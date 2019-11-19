using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public GameObject Gokyuzu1;
    public GameObject Gokyuzu2;

    public float arkaPlayHiz;

    Rigidbody2D Gokyuzu1Fizik;
    Rigidbody2D Gokyuzu2Fizik;

    public float gokyuzuUzunluk;

    public GameObject engel;
    public int engelSayisi = 5;
    GameObject[] engeller;


    float degisimZaman = 0;

    int sayac = 0;
    bool gameOver = false;
    void Start()
    {
        Gokyuzu1Fizik = Gokyuzu1.GetComponent<Rigidbody2D>();
        Gokyuzu2Fizik = Gokyuzu2.GetComponent<Rigidbody2D>();

        Gokyuzu1Fizik.velocity = new Vector2(arkaPlayHiz * -1f, 0);
        Gokyuzu2Fizik.velocity = new Vector2(arkaPlayHiz * -1f, 0);

        gokyuzuUzunluk = Gokyuzu1.GetComponent<BoxCollider2D>().size.x;

        engeller = new GameObject[engelSayisi];

        for (int i = 0; i < engeller.Length; i++)
        {
            //engelleri çizdirdik
            engeller[i] = Instantiate(engel, new Vector2(-20, -20), Quaternion.identity);

            //engele rigidbody ekledik
            Rigidbody2D FizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            FizikEngel.gravityScale = 0;
            FizikEngel.velocity = new Vector2(arkaPlayHiz * -1f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {



            // gokyuzunun sonuna geldiğinde
            if (Gokyuzu1.transform.position.x <= -gokyuzuUzunluk)
            {
                //gokyuzu1'i sıranın sonuna iterek sonsuz bir map oluşturduk
                Gokyuzu1.transform.position += new Vector3(gokyuzuUzunluk * 2, 0);
            }

            // gokyuzunun sonuna geldiğinde
            if (Gokyuzu2.transform.position.x <= -gokyuzuUzunluk)
            {
                //gokyuzu2'i sıranın sonuna iterek sonsuz bir map oluşturduk
                Gokyuzu2.transform.position += new Vector3(gokyuzuUzunluk * 2, 0);
            }

            //------------------------------------
            degisimZaman += Time.deltaTime;
            if (degisimZaman > 2f) // 2 saniyede 1 yeni engel
            {
                degisimZaman = 0;
                //mapin y eksenindeki uc değerler aralıklarından bir değer belirledik
                float yEksenim = Random.Range(-0.78f, 2.10f);

                engeller[sayac].transform.position = new Vector3(11f, yEksenim);
                sayac++;
                if (sayac == engeller.Length)
                {
                    sayac = 0;
                }
            }
        }
        else
        {

        }
    }

    public void oyunBitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            //çubukların hareketlerini durdurduk
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero; //(0,0) ile aynı

            Gokyuzu1Fizik.velocity = Vector2.zero;
            Gokyuzu2Fizik.velocity = Vector2.zero;
        }
        gameOver = true;
    }
}
