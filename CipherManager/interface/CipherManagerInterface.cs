using System;
using System.Collections.Generic;
using System.Text;

namespace CipherManager
{
    interface CipherManagerInterface
    {
        public string Encrypt(string text);
        public  string Decrypt(string cipher);
    }
}
