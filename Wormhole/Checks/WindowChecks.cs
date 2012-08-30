﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Wormhole
{
    public static class WindowChecks
    {
        public bool IsIntersecting(this GameObject obj)
        {
            Rectangle screenRectangle = GameInfo.RefDevice.Viewport.Bounds;
            if (screenRectangle.Intersects(obj.Sprite.GetRectangle())
                && !screenRectangle.Contains(obj.Sprite.GetRectangle()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsOutsideWindow(this GameObject obj)
        {
            Rectangle screenRectangle = GameInfo.RefDevice.Viewport.Bounds;
            if (!screenRectangle.Contains(obj.Sprite.GetRectangle()) && !IsIntersecting(obj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}