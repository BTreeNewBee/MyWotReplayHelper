using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using WotReplayParser.Entity;

namespace WotReplayParser
{
    class Parse
    {
        public void parse(String fileName)
        {

            FileStream fs = new FileStream(fileName, FileMode.Open);

            // read block count 
            int blockCount = readDataBlockCount(fs);

            //skip 3 byte 
            _ = readBytesFromFileStream(fs, 3);

            //loop read block 
            for (int i = 0; i < blockCount; i++)
            {
                readDataBlock(fs);
            }


        }


        int readDataBlockCount(FileStream fs)
        {
            //skip 4 bytes in file head , is might be the magic number of the file
            //0x12 0x32 0x34 0x11 
            readBytesFromFileStream(fs, 4);
            return fs.ReadByte();
        }



        void readDataBlock(FileStream fs)
        {
            //readBlockLength
            byte[] intBytes = readBytesFromFileStream(fs, 4);
            uint blockLength = bytesToUIntLE(intBytes);
            //read block array
            byte[] blockArray = readBytesFromFileStream(fs, blockLength);

            string jsonStr = Encoding.UTF8.GetString(blockArray);
            Console.WriteLine(jsonStr);
            DataBlock dataBlock = JsonConvert.DeserializeObject<DataBlock>(jsonStr);
            Console.WriteLine();
            Console.WriteLine(JsonConvert.SerializeObject(dataBlock));
        }



        /* Read 
         * 
         * 
         */
        byte[] readBytesFromFileStream(FileStream fs, uint length)
        {
            //check if file does not have enough bytes to read
            if (fs.Length - fs.Position < length)
            {
                throw new Exception("Read error ! File length not enough to read ! current position " + fs.Position + ", read length " + length + ".");
            }
            byte[] bytes = new byte[length];
            fs.Read(bytes);
            return bytes;
        }

        /* 
         * cast byte array to int with big-endian
         */
        uint bytesToUIntLE(byte[] bytes)
        {
            if (bytes.Length < 4)
            {
                return 0;
            }
            return (uint)(bytes[0]  |
                bytes[1] << 1 * 8 |
                bytes[2] << 2 * 8 |
                bytes[3] << 3 * 8);
        }


    }
}
