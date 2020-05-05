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
    class UI
    {
        public SpriteFont font;
        public QuantityDisplay healtBar;
        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");  //fuente
            healtBar = new QuantityDisplay(new Vector2(104,16),2,Color.Red);  //barra de vida
        }

      

        public void Update(World WORLD)
        {
            healtBar.Update(WORLD.nave.health,WORLD.nave.healthMax);
        }

        public void Draw(World WORLD)
        {
            string tempStr = "Score= "+WORLD.numKilled;  //imprimir numero de muertes
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font,tempStr,new Vector2(Globals.screenWidth/2-strDims.X/2, Globals.screenHeight-40), Color.WhiteSmoke);  //imprimir puntaje

            healtBar.Draw(new Vector2(20, Globals.screenHeight - 40));  //definir la barra

            if (WORLD.nave.dead)  //si la nave muere press enter  para reiniciar
            {
               tempStr = "Press enter to restart! ";
               strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight/2), Color.WhiteSmoke);
            }
        }
    }

   
}
