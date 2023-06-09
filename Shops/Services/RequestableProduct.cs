﻿using Shops.Tools;

namespace Shops.Services
{
    public class RequestableProduct
    {
        private int _id;
        private int _count;

        public RequestableProduct(int id, int count)
        {
            ID = id;
            Count = count;
        }

        public int ID
        {
            get => _id;
            private set
            {
                if (value < 0) throw new InvalidIdShopException("There is a invalid ID");
                _id = value;
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                if (value < 0) throw new InvalidCountShopException("There is a invalid count");
                _count = value;
            }
        }
    }
}
