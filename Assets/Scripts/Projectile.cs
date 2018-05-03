using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class Projectile : MonoBehaviour
    {
        public float damage = 10;

        public int scoreValue = 1;

        public string bulletColor = "Red";

        void Start()
        {
            Destroy(gameObject,5f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if ((collision.gameObject.tag.Equals("RedShield") && bulletColor.Equals("Red")) || (collision.gameObject.tag.Equals("BlueShield") && bulletColor.Equals("Blue")))
            {
                Debug.Log("Blocked");
                ScoreManager.score += scoreValue;
                // Remove this script from the game object to nullify damage should it bounce back to the player.
                Destroy(this);
            }

            if ((collision.gameObject.tag.Equals("BlueShield") && bulletColor.Equals("Red")) || (collision.gameObject.tag.Equals("RedShield") && bulletColor.Equals("Blue")))
            {
                Debug.Log("Wrong shield");
                // Take half damage if blocking with wrong shield color
                GameObject.FindGameObjectWithTag("Body").GetComponent<PlayerHealth>().TakeDamage(damage / 2);
                Destroy(this);
            }

            if (collision.gameObject.tag.Equals("Body"))
            {
                Debug.Log("Hit");
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
