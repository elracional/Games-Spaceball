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
    class Mob : Unit
    {

        public Mob(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS) //Clase para tomar la inicializacion de basic2d
        {
            speed = 2.0f; //rapidez
        }

        public virtual void Update(Vector2 OFFSET, Nave NAVE)
        {

            AI(NAVE);
            base.Update(OFFSET);
        } 

        public virtual void AI(Nave NAVE)
        {
            pos += Globals.RadialMovement(NAVE.pos, pos,speed); //funcion para que las naves vayan hacia a l nave
            rot = Globals.RotateTowards(pos, NAVE.pos);

            if (Globals.GetDistance(pos,NAVE.pos)<15)
            {
                NAVE.GetHit(1);
                dead = true;
            }
        }

      

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);  //Pintar en pantalla los movimientos
        }
    }
}
