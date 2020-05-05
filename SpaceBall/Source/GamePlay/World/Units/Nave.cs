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
    class Nave: Unit
    {
        
        public Nave(string PATH, Vector2 POS, Vector2 DIMS):base(PATH,POS,DIMS) //Clase para tomar la inicializacion de basic2d
        {
            speed = 2.0f; //rapidez


            health = 5;
            healthMax = health;
        }

        public override void Update(Vector2 OFFSET)
        {
            
            if (Globals.keyboard.GetPress("A"))   //Configuración de movimientos
            {
                if (pos.X >32)  //margen izquierdo
                {
                    pos = new Vector2(pos.X - speed, pos.Y);
                }
            }
            if (Globals.keyboard.GetPress("D"))
            {
                if (pos.X < 778)  //margen derecho
                {
                    pos = new Vector2(pos.X + speed, pos.Y);
                }
            }
            if (Globals.keyboard.GetPress("W"))
            {
                if (pos.Y >25)  //margen superior
                {
                    pos = new Vector2(pos.X, pos.Y - speed);
                }
            }
            if (Globals.keyboard.GetPress("S"))
            {
                if (pos.Y <420)  //margen inferior
                {
                    pos = new Vector2(pos.X, pos.Y + speed);
                }
            }
            Console.Write(pos+"\n"); //imprimir posicion de nave
            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y)); //rotacion de nave segun la posicion del mouse

            if (Globals.mouse.LeftClick())
            {
                GameGlobals.PassProjectile(new Fireball(new Vector2(pos.X,pos.Y), this,new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y)));  //activar proyectil, se pasa por delegade
            }
            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);  //Pintar en pantalla los movimientos
        }
    }
}
