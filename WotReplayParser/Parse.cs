using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Demo01
{
    class Parse
    {
        void parse(String fileName)
        {

            FileStream fs = new FileStream(@"C:\Users\Public\TestFolder\WriteText.txt", FileMode.Open);
            //skip 3 byte
            readBytesFromFileStream(fs, 3);

            // read block count 
            int blockCount = readDataBlockCount(fs);

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
            fs.Read(new byte[4], 0, 4);
            return fs.ReadByte();
        }



        void readDataBlock(FileStream fs)
        {
            //readBlockLength
            byte[] intBytes = readBytesFromFileStream(fs, 4);
            int blockLength = bytesToIntBE(intBytes);
            //read block array
            byte[] blockArray = readBytesFromFileStream(fs, blockLength);





        }



        /* Read 
         * 
         * 
         */
        byte[] readBytesFromFileStream(FileStream fs, int length)
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
        int bytesToIntBE(byte[] bytes)
        {
            if (bytes.Length < 4)
            {
                return 0;
            }
            return bytes[0] << 3 * 8 |
                bytes[1] << 2 * 8 |
                bytes[2] << 1 * 8 |
                bytes[0];
        }


    }
}
