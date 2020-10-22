﻿using DAL.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Serialize
{
    class BINARYSerializer<T> : ISerializers<T>
    {
        private BinaryFormatter formatter;
        public BINARYSerializer()
        {
            formatter = new BinaryFormatter();
        }
        public void Serialize<T>(T serializeObject, string filePath, bool append, string fileName)
        {
            using(FileStream outFile = new FileStream(filePath + fileName + ".bin", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(outFile, serializeObject);
            }
        }

        public T Deserialize(string path)
        {
            T objectReturned;

            using (FileStream outFile = new FileStream("SortedData.bin", FileMode.Open, FileAccess.Read))
            {
                objectReturned = (T)formatter.Deserialize(outFile);
            }

            return objectReturned;
        }

        public T[] DeserializeList()
        {
            throw new NotImplementedException();
        }

        public void SerializeList(List<T> list, string filePath, string fileName, bool append)
        {
            using (FileStream outFile = new FileStream(filePath + fileName + ".bin", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(outFile, new Category("test"));
            }
        }
    }
}
