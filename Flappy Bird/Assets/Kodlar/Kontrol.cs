using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{

    public Sprite[] KusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;

    int kusSayac = 0;

    float kusAnimasyonZaman = 0;

    Rigidbody2D Fizik;
    void Start()
    {
      
        spriteRenderer = GetComponent<SpriteRenderer>();
        Fizik = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        kusAnimasyon();
        if (Input.GetMouseButtonDown(0))
        {
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
}
