﻿using System;
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
    class Imp : Mob
    {

        public Imp( Vector2 POS) 
            : base("bullet3", POS, new Vector2(40,40)) //Clase para tomar la inicializacion de basic2d
        {
            speed = 2.0f; //rapidez
        }

        public virtual void Update(Vector2 OFFSET, Nave NAVE)
        {

           
            base.Update(OFFSET, NAVE);
        } 

        
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);  //Pintar en pantalla los movimientos
        }
    }
}
