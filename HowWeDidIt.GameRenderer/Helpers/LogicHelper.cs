﻿using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HowWeDidIt.GameRenderer.Helpers
{
    public static class LogicHelper
    {
        public static bool HasBeenCaught(MovingGameItem first, MovingGameItem second/*, IGameSettings gameSettings*/)
        {
            var firstGeometry = first.GetGeometry();
            var secondGeometry = second.GetGeometry();

            return Geometry.Combine(firstGeometry, secondGeometry, GeometryCombineMode.Intersect, null).GetArea() > 0;
        }
    }
}