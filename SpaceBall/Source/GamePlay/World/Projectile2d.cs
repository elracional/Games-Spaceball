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

namespace SpaceBall { 
    class Projectile2d:Basic2d
    {
        public bool done;
        public float speed;
        public Unit owner;
        public Vector2 direction;
        public McTimer timer;

        public Projectile2d(string PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Vector2 TARGET)
            : base(PATH, POS, DIMS) //Clase para tomar la inicializacion de basic2d
        {
            done = false;
            speed = 5.0f; //rapidez
            owner = OWNER;

            direction=TARGET - owner.pos;
            direction.Normalize();
            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));  //rotar los proyectiles hacia la nave
            timer = new McTimer(1200);


        }

        public virtual void Update(Vector2 OFFSET, List<Unit> UNITS)
        {
            pos += direction * speed;
            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true; //cuando los proyectiles terminan su tiempo con esta variable hace que desaparescan
            }

            if (HitSomething(UNITS))  //cuando los proyectiles colisionan con esta variable hace que desaparescan
            {

                done = true;
            }

        }

        public virtual bool HitSomething(List<Unit> UNITS)
        {
            for (int i=0; i<UNITS.Count; i++)
            {
                if (Globals.GetDistance(pos, UNITS[i].pos)< UNITS[i].hitDist)  //devuelve con que pego el proyectil
                {
                    UNITS[i].GetHit(1);
                    return true;
                }
            }
            return false;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
