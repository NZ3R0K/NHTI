using System;
using System.Collections.Generic;
using UnityEngine;

namespace LineDraw
{
    public class LineObject
    {
        public float Roation = 0;
        public Vector2 Scale = Vector2.one;
        public Vector2 Location = Vector2.zero;
        public List<DrawLine> Lines = new List<DrawLine>();

        public LineObject()
        {
            Initalize();
        }

        public virtual void Initalize()
        { // Intended to be overriden in sub classes 
        }

        public void Add(DrawLine NewLine)
        {
            Lines.Add(NewLine);
        }

        public void UpdateTranslations(Vector2 location, float roation, Vector2 scale)
        {
            Location = location;
            Roation = roation;
            Scale = scale;
        }

        /*
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Lines.Count != 0)
            {
                for (int i = 0; i < Lines.Count; i++)
                {
                    Lines[i].Draw(spriteBatch, Location);
                }
            }
        }
        */
    }
}

       