using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * -1 * _speed * Time.deltaTime);
        if(transform.position.y<-4.8f)
        {
            RespawnEnemy();
        }

    }

    void RespawnEnemy()
    {
        transform.position = new Vector3(Random.Range(-11.2f, 11.2f), 6, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            //Debug.Log("Player was hit");
            Player player = other.transform.GetComponent<Player>();
            
            if(player!=null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
            //RespawnEnemy();
        }

        else if(other.gameObject.tag.Equals("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            //RespawnEnemy();
        }
    }
}
