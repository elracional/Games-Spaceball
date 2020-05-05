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
    class QuantityDisplay
    {
        public int boarder;
        public Basic2d bar, barBKG;
        public Color color;

        public QuantityDisplay(Vector2 DIMS, int BOARDED, Color COLOR)
        {
            boarder = BOARDED;
            color = COLOR;
            bar = new Basic2d("2d\\solid", new Vector2(0, 0), new Vector2(DIMS.X - boarder * 2, DIMS.Y - boarder * 2));
            barBKG = new Basic2d("2d\\shade", new Vector2(0, 0), new Vector2(DIMS.X , DIMS.Y ));
        }

        public virtual void Update(float CURRENT, float MAX)
        {
            bar.dims = new Vector2(CURRENT/MAX*(barBKG.dims.X-boarder*2),bar.dims.Y);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            barBKG.Draw(OFFSET,new Vector2(0,0),Color.AliceBlue);
            bar.Draw(OFFSET + new Vector2(boarder, boarder),new Vector2(0, 0), color);
        }
    }
}
