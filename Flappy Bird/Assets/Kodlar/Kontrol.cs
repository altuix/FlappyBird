using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kontrol : MonoBehaviour
{

    public Sprite[] KusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;

    int kusSayac = 0;

    float kusAnimasyonZaman = 0;

    Rigidbody2D Fizik;
    int puan = 0;

    public Text Score;

    bool gameOver = false;

    OyunKontrol oyunKontrol;

    //AudioSource Ses;

    //public AudioClip CarpmaSesi;
    //public AudioClip PuanSesi;
    //public AudioClip KanatSesi;


    AudioSource []sesler;

    void Start()
    {
        Score.text = "Puan = 0";
        oyunKontrol = GameObject.FindGameObjectWithTag("GameController").GetComponent<OyunKontrol>();

        //Ses = GetComponent<AudioSource>();

        sesler = GetComponents<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Fizik = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        kusAnimasyon();
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            //Ses.clip = KanatSesi;
            //Ses.Play();
            sesler[0].Play();
            //Çekim kuvvetini sıfırladık
            Fizik.velocity = new Vector2(0, 0);

            //yukarı çıksın diye kuvvet uyguladık
            Fizik.AddForce(new Vector2(0, 200));
        }
        //y ekseninde(yukarı harekette) bir kuvvet varsa
        if (Fizik.velocity.y > 0)
        { //kuşun başını havaya kaldırdık
            transform.eulerAngles = new Vector3(0, 0, 45);

        }
        else
        {//kuşun başını aşağı indirdik
            transform.eulerAngles = new Vector3(0, 0, -45);

        }
    }

    void kusAnimasyon()
    {

       
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.2f)
        {
            kusAnimasyonZaman = 0;

            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = KusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;

                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;

                    ileriGeriKontrol = true;
                }
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "puan" && !gameOver)
        {
            //Ses.clip = PuanSesi;
            //Ses.Play();

            sesler[1].Play();

            puan++;
            Score.text = "Puan = " + puan.ToString();
            Debug.Log(puan);
        }

        if (collision.gameObject.tag == "engel" && !gameOver)
        {
            //Ses.clip = CarpmaSesi;
            //Ses.Play();
            sesler[2].Play();


            gameOver = true;
            oyunKontrol.oyunBitti();
        }
    }
}
