﻿using Core.Model;
using Tesseract;

namespace Core.Interface
{
    public interface IReadPicture
    {
        Pix ReadImageFromFile(string image);

    }
}