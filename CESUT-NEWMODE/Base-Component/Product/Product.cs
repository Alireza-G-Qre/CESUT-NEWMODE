using System.Collections.Concurrent;
using CESUT_NEWMODE.Toolkit.Packing;

namespace CESUT_NEWMODE.Base_Component.Product
{
    internal class ProductObj : IPackable
    {
        public ProductObj()
        {

        }

        public static ProductObj getProductObjById(string id)
        {
            return null;
        }

        public void Dpkg(ConcurrentDictionary<string, object> dic)
        {
            throw new System.NotImplementedException();
        }

        public string GetId()
        {
            throw new System.NotImplementedException();
        }

        public ConcurrentDictionary<string, object> Pack()
        {
            throw new System.NotImplementedException();
        }
    }
}
