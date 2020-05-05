using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace SpaceBall
{
    class Unit: Basic2d
    {

        public bool dead;

        public float speed,hitDist,health, healthMax;
        public Unit(string PATH, Vector2 POS, Vector2 DIMS):base(PATH,POS,DIMS) //Clase para tomar la inicializacion de basic2d
        {
            dead = false;
            speed = 2.0f; //rapidez
            hitDist = 35.0f;

            health = 1;     //vida
            healthMax = health;

        }

        public override void Update(Vector2 OFFSET)
        {

            base.Update(OFFSET);
        }

        public virtual void GetHit(float DAMAGE)
        {
            health -= DAMAGE;  //quitar vida si golpea
            if (health <= 0)
            {
                dead = true;
            }
           
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);  //Pintar en pantalla los movimientos
        }
    }
}
