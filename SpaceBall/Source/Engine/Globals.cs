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
    public delegate void PassObject(object i);   //delegades
    public delegate object PassObjectAndReturn(object i);

    class Globals
    {
        public static int screenHeight, screenWidth;
        public static ContentManager content;  // Poner como global el contenido
        public static SpriteBatch spriteBatch; // Iniciar el sprite batch como global
        public static McKeyboard keyboard;     //Iniciar el teclado como global
        public static McMouseControl mouse;
        public static GameTime gameTime;

        public static float GetDistance(Vector2 pos,Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(pos.X-target.X,2)+Math.Pow(pos.Y - target.Y,2));  //obtejer distancia de 2 objetos
        }

        public static Vector2 RadialMovement(Vector2 focus, Vector2 pos, float speed)
        {
            float dist = Globals.GetDistance(pos, focus); //obtener la distancia 

            if (dist <= speed)
            {
                return focus - pos;  //retornor la distnacio
            }
            else
            {
                return (focus - pos) * speed / dist;
            }
        }

        public static float RotateTowards(Vector2 Pos, Vector2 focus)  //funcion para rotar libreria
        {

            float h, sineTheta, angle;
            if (Pos.Y - focus.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(Pos.X - focus.X, 2) + Math.Pow(Pos.Y - focus.Y, 2));
                sineTheta = (float)(Math.Abs(Pos.Y - focus.Y) / h); 
            }
            else
            {
                h = Pos.X - focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            // Drawing diagonial lines here.
            //Quadrant 2
            if (Pos.X - focus.X > 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }
            //Quadrant 3
            else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }
            //Quadrant 1
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI * 3 / 2;
            }
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI / 2;
            }
            else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)0;
            }
            else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)Math.PI;
            }

            return angle;
        }

    }
}
