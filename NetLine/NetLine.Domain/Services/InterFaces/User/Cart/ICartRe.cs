﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLine.Domain.Services.InterFaces.User.Cart
{
    public interface ICartRe
    {
        Task AddToCart(int itemId, string userId);
    }
}
