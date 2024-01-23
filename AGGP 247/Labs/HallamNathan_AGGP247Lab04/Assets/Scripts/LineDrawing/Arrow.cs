using System;
using System.Collections.Generic;
using UnityEngine;

namespace LineDraw
{
    class Arrow : DrawingObject
    {
        public Arrow()
            : base()
        { }

        public override void Initialize()
        {
            Lines.Add(new Line(new Vector2(0, 1), new Vector2(0, 2), Color.red));
            Lines.Add(new Line(new Vector2(0, 2), new Vector2(2, 0), Color.red));
            Lines.Add(new Line(new Vector2(2, 0), new Vector2(0, -2), Color.red));
            Lines.Add(new Line(new Vector2(0, -2), new Vector2(0, -1), Color.red));
            Lines.Add(new Line(new Vector2(0, -1), new Vector2(-2, -1), Color.red));
            Lines.Add(new Line(new Vector2(-2, -1), new Vector2(-2, 1), Color.red));
            Lines.Add(new Line(new Vector2(-2, 1), new Vector2(0, 1), Color.red)); 
        }
    }
}
