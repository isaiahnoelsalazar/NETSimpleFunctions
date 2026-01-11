namespace NETSimpleFunctions
{
    public class Memory<GenericType>
    {
        GenericType[] Storage = new GenericType[0];

        public void Add(GenericType GenericObject)
        {
            GenericType[] Temp = new GenericType[Storage.Length];
            for (int a = 0; a < Storage.Length; a++)
            {
                Temp[a] = Storage[a];
            }
            Storage = new GenericType[Storage.Length + 1];
            for (int a = 0; a < Temp.Length; a++)
            {
                Storage[a] = Temp[a];
            }
            Storage[Storage.Length - 1] = GenericObject;
        }

        public bool Contains(GenericType GenericObject)
        {
            for (int a = 0; a < Storage.Length; a++)
            {
                if (Storage[a].Equals(GenericObject))
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(GenericType GenericObject)
        {
            GenericType[] Temp = new GenericType[Storage.Length - 1];
            int b = 0;
            for (int a = 0; a < Storage.Length; a++)
            {
                if (!Storage[a].Equals(GenericObject))
                {
                    if (b < Temp.Length)
                    {
                        Temp[b] = Storage[a];
                        b++;
                    }
                }
            }
            Storage = new GenericType[Temp.Length];
            for (int a = 0; a < Temp.Length; a++)
            {
                Storage[a] = Temp[a];
            }
        }

        public void RemoveAt(int Index)
        {
            GenericType[] Temp = new GenericType[Storage.Length - 1];
            int b = 0;
            for (int a = 0; a < Storage.Length; a++)
            {
                if (a != Index)
                {
                    Temp[b] = Storage[a];
                    b++;
                }
            }
            Storage = new GenericType[Temp.Length];
            for (int a = 0; a < Temp.Length; a++)
            {
                Storage[a] = Temp[a];
            }
        }

        public GenericType Get(int Index)
        {
            return Storage[Index];
        }

        public int Count()
        {
            return Storage.Length;
        }

        public void Clear()
        {
            Storage = new GenericType[0];
        }
    }
}
