using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Models.User.Order;


namespace NetLine.Domain.Services.InterFaces.User.Cart
{
    public interface ICartRe
    {

        Task AddToCart(int itemId, string userId);
        Task DeleteItemInCart(int detailId);
    }
}
