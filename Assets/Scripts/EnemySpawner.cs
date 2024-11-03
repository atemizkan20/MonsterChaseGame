using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] EnemiesReference; // Düşman prefablarının referansları
    [SerializeField] private Transform leftpos, rightpos; // Düşmanların sol ve sağ pozisyonları

    private GameObject spawnedenemies;
    private int randomindex;
    private int randomside;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }


    IEnumerator SpawnEnemies(){
        while(true){

            yield return new WaitForSeconds(Random.Range(1,5)); //coroutine olduğu için while çalışıyor

            randomindex=Random.Range(0,EnemiesReference.Length); //Enemiesreference dizisinden rasgele enemy seçiyoruz
            randomside=Random.Range(0,2); //rasgele side seçiyoruz
            spawnedenemies= Instantiate(EnemiesReference[randomindex]); //ve instantiate fonksiyonuyla copy oluşturuyoruz


            if (randomside==0) { //left side
                spawnedenemies.transform.position=leftpos.position;
                spawnedenemies.GetComponent<Enemies>().speed= Random.Range(4,10);
            }
            else { // right side
                spawnedenemies.transform.position=rightpos.position;
                spawnedenemies.GetComponent<Enemies>().speed= -Random.Range(4,10);
                
                spawnedenemies.transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f); // Sabit boyut


            }
        } //while loop
    }

} //class
