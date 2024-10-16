using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.client
{
    public static class APIMethods
    {
        public static async Task<byte[]> GetImageBinary(string filePath)
        {
            return await File.ReadAllBytesAsync(filePath);
        }
    }
}
