using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using CESUT_NEWMODE.Toolkit.IDHandler;
using CESUT_NEWMODE.Toolkit.Packing;

namespace CESUT_NEWMODE.Base_Component.Account_Component
{
    internal class Cart : IPackable
    {
        public static List<Cart> AllCarts { get; set; }

        public static Cart GetCartByID(string id)
        {
            return AllCarts.AsParallel().Where(a => a.CartId.Equals(id))
                        .SingleOrDefault(null);
        }

        public string CartId { get; private set; }

        public PLog DataInCart { get; private set; }

        public static Cart GetWalletByID(string id)
        {
            return AllCarts.AsParallel().Where(a => a.CartId.Equals(id))
                        .SingleOrDefault(null);
        }

        public string GetId() => CartId;

        public string Init_ID() => IDHandler.Init_ID<Cart>(AllCarts);

        public ConcurrentDictionary<string, object> Pack()
        {
            return new ConcurrentDictionary<string, object>()
            {
                ["cartid"] = null,
                ["datain"] = null,
                //...
            };
        }

        public void Dpkg(ConcurrentDictionary<string, object> dic)
        {
           //...
        }
    }
}
