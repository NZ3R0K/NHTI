using System;
using System.Collections.Generic;
using UnityEngine;

namespace LineDraw
{
    class XMark : LineObject
    {
        public XMark()
            : base()
        { }

        public override void Initalize()
        {
            Lines.Add(new DrawLine(new Vector2(-5, 5), new Vector2(5, -5), 3.5f, Color.red));
            Lines.Add(new DrawLine(new Vector2(5, 5), new Vector2(-5, -5), 3.5f, Color.red));
        }
    }
}
