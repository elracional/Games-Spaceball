#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace SpaceBall                 //Clase que enlaza con Mckey e inicializa los caracteres que se pueden reconocer
{
    public class McKeyboard
    {

        public KeyboardState newKeyboard, oldKeyboard;  //Variables

        public List<McKey> pressedKeys = new List<McKey>(), previousPressedKeys = new List<McKey>();  //Lista 

        public McKeyboard()
        {

        }

        public virtual void Update()  
        {
            newKeyboard = Keyboard.GetState(); //obtiene el estado de el teclado

            GetPressedKeys();  //llamada de funcion 

        }

        public void UpdateOld()   //se guarda el estado anterior
        {
            oldKeyboard = newKeyboard;

            previousPressedKeys = new List<McKey>();
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                previousPressedKeys.Add(pressedKeys[i]);
            }
        }


        public bool GetPress(string KEY)   
        {

            for (int i = 0; i < pressedKeys.Count; i++)
            {

                if (pressedKeys[i].key == KEY)
                {
                    return true;
                }

            }


            return false;
        }


        public virtual void GetPressedKeys()   // funcion que obtiene las letras presionadas
        {
            bool found = false;

            pressedKeys.Clear();
            for (int i = 0; i < newKeyboard.GetPressedKeys().Length; i++)
            {

                pressedKeys.Add(new McKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));

            }
        }

    }
}