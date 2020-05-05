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
    class World
    {
        public int numKilled;
        public Vector2 offset;
        public Nave nave;

        public UI ui;

        public List<Projectile2d> projectiles = new List<Projectile2d>();
        public List<Mob> mobs = new List<Mob>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        PassObject ResetWorld;

        public World(PassObject RESETWORLD)
        {
            ResetWorld = RESETWORLD;

            numKilled = 0;

            nave = new Nave("nave", new Vector2(400, 300), new Vector2(48, 48)); //Inicializacion de mundo y cordeenadas

            GameGlobals.PassProjectile = AddProjectile; //funcion para activar pasar proyectil como objeto por medio de global  (Delegade)
            GameGlobals.PassMob = AddMob; //funcion para activar pasar mob como objeto por medio de global  (Delegade)
            offset = new Vector2(0, 0);

            spawnPoints.Add(new SpawnPoint("NaveMala", new Vector2(50, 50), new Vector2(30, 35)));                         //spawn de naves enemigas
            spawnPoints.Add(new SpawnPoint("NaveMala", new Vector2(Globals.screenWidth / 2, 50), new Vector2(30, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);
            spawnPoints.Add(new SpawnPoint("NaveMala", new Vector2(Globals.screenWidth - 50, 50), new Vector2(30, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);
            spawnPoints.Add(new SpawnPoint("NaveMala", new Vector2(Globals.screenWidth - 50, 200), new Vector2(30, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1500);
            spawnPoints.Add(new SpawnPoint("NaveMala", new Vector2(55, 200), new Vector2(30, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(2000);
            spawnPoints.Add(new SpawnPoint("NaveMala", new Vector2(Globals.screenWidth - 50, 350), new Vector2(30, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(3500);
            spawnPoints.Add(new SpawnPoint("NaveMala", new Vector2(55, 350), new Vector2(30, 35)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(3000);
            spawnPoints.Add(new SpawnPoint("NaveMala", new Vector2(Globals.screenWidth / 2, 410), new Vector2(30, 35)));
           // spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);

            ui = new UI();

        }

        public virtual void Update()
        {
            if (!nave.dead) {
                nave.Update(offset);  //Actualizar

                for (int i = 0; i < spawnPoints.Count; i++) //actulizar todos los spawn
                {
                    spawnPoints[i].Update(offset);
                }

                for (int i = 0; i < projectiles.Count; i++) //actulizar todos los proyectiles
                {
                    projectiles[i].Update(offset, mobs.ToList<Unit>()); //cast para mobs y poder pasarloos como units

                    if (projectiles[i].done)  //si ya no existen los proyectiles eliminarlos
                    {
                        projectiles.RemoveAt(i);
                        i--;
                        numKilled++;
                    }
                }

                for (int i = 0; i < mobs.Count; i++) //actulizar todos los proyectiles
                {
                    mobs[i].Update(offset, nave); //cast para mobs y poder pasarloos como units

                    if (mobs[i].dead)  //si ya no existen los MOBS eliminarlos
                    {
                        mobs.RemoveAt(i);
                        i--;
                        
                    }
                }
            }
            else
            {
                if (Globals.keyboard.GetPress("Enter"))
                {
                    ResetWorld(null); //reseter mundo si se muere
                }
            }
            ui.Update(this);
        }

        public virtual void AddMob(object INFO)  //añadir balas
        {
            mobs.Add((Mob)INFO);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO); //se van añadiendo los proyectiles
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            nave.Draw(OFFSET);  //Escribir

            for (int i = 0; i < projectiles.Count; i++) //actulizar todos los proyectiles
            {
                projectiles[i].Draw(offset);  //pintar en pantalla los proyectiles
            }

            for (int i = 0; i < spawnPoints.Count; i++) //actulizar todos los spawn
            {
                spawnPoints[i].Draw(offset);
            }

            for (int i = 0; i < mobs.Count; i++) //actulizar todos los proyectiles
            {
                mobs[i].Draw(offset); //cast para mobs y poder pasarloos como units


            }

           
            ui.Draw(this);
        }
    }

   
}
