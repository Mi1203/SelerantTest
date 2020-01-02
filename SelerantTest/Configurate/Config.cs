using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SelerantTest.Configurate
{
    internal class Config
    {
        #region ctor and fields
        private Dictionary<string, Config> PairKeyValues = new Dictionary<string, Config>();
        private string _value;

        /// <summary>
        /// 
        /// </summary>
        private Config() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        internal Config(string path)
        {
            using (var file = File.Open(path, FileMode.Open))
            {
                using (var stream = new StreamReader(file))
                {
                    while (stream.Peek() >= 0)
                    {
                        var line = stream.ReadLine();
                        var splitValue = line.Split('=');

                        if (splitValue.Length != 2) continue;

                        var key = splitValue[0];
                        var val = splitValue[1];
                        AddKeyValue(key, val);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal Config this[string key]
        {
            get
            {
                if (!PairKeyValues.ContainsKey(key))
                    return new Config();
                return PairKeyValues[key];
            }
            set { PairKeyValues[key] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void AddKeyValue(string key, string value)
        {
            var splitData = key.Split('.');
            Config currentConfig = this;

            for (var i = 0; i < splitData.Length; i++)
            {
                var val = splitData[i];
                if (currentConfig.PairKeyValues.ContainsKey(val))
                    currentConfig = currentConfig.PairKeyValues[val];
                else
                {

                    var temp = new Config();
                    currentConfig.PairKeyValues.Add(val, temp);
                    currentConfig = temp;
                }
            }
            currentConfig._value = value;
        }
    }
}
