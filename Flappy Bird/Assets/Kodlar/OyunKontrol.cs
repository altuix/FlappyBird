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

    float gokyuzuUzunluk;
    void Start()
    {
        Gokyuzu1Fizik = Gokyuzu1.GetComponent<Rigidbody2D>();
        Gokyuzu2Fizik = Gokyuzu2.GetComponent<Rigidbody2D>();

        Gokyuzu1Fizik.velocity = new Vector2(arkaPlayHiz * -1f, 0);
        Gokyuzu2Fizik.velocity = new Vector2(arkaPlayHiz * -1f, 0);

        gokyuzuUzunluk = Gokyuzu1.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
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
    }
}
