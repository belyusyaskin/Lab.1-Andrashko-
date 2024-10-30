using System;
using System.Collections.Generic;

namespace InternetConnectionDemo
{
    // Клас InternetConnection з усіма параметрами
    public class InternetConnection
    {
        public string Protocol { get; private set; }
        public string Encryption { get; private set; }
        public string IpVersion { get; private set; }
        public Dictionary<string, string> AdditionalProperties { get; private set; }

        private InternetConnection() { }

        // Метод для підключення, який виводить параметри підключення в консоль
        public void Connect()
        {
            Console.WriteLine("Параметри підключення:");
            Console.WriteLine($"Протокол: {Protocol}");
            Console.WriteLine($"Шифрування: {Encryption}");
            Console.WriteLine($"Версія IP: {IpVersion}");

            if (AdditionalProperties.Count > 0)
            {
                Console.WriteLine("Додаткові властивості:");
                foreach (var property in AdditionalProperties)
                {
                    Console.WriteLine($"{property.Key}: {property.Value}");
                }
            }
        }

        // Внутрішній Builder клас для налаштування параметрів підключення
        public class Builder
        {
            private string protocol = "HTTP";
            private string encryption = "None";
            private string ipVersion = "IPv4";
            private Dictionary<string, string> additionalProperties = new Dictionary<string, string>();

            public Builder SetProtocol(string protocol)
            {
                this.protocol = protocol;
                return this;
            }

            public Builder SetEncryption(string encryption)
            {
                this.encryption = encryption;
                return this;
            }

            public Builder SetIpVersion(string ipVersion)
            {
                this.ipVersion = ipVersion;
                return this;
            }

            public Builder AddAdditionalProperty(string key, string value)
            {
                additionalProperties[key] = value;
                return this;
            }

            public InternetConnection Build()
            {
                return new InternetConnection
                {
                    Protocol = protocol,
                    Encryption = encryption,
                    IpVersion = ipVersion,
                    AdditionalProperties = additionalProperties
                };
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення кількох з'єднань з різними конфігураціями

            // З'єднання за замовчуванням
            var connection1 = new InternetConnection.Builder().Build();
            connection1.Connect();

            Console.WriteLine();

            // З'єднання з протоколом HTTPS і шифруванням TLS
            var connection2 = new InternetConnection.Builder()
                .SetProtocol("HTTPS")
                .SetEncryption("TLS")
                .SetIpVersion("IPv6")
                .Build();
            connection2.Connect();

            Console.WriteLine();

            // З'єднання з додатковими властивостями
            var connection3 = new InternetConnection.Builder()
                .SetProtocol("FTP")
                .AddAdditionalProperty("Port", "21")
                .AddAdditionalProperty("PassiveMode", "true")
                .Build();
            connection3.Connect();

            Console.WriteLine();

            // З'єднання з SSH і додатковими властивостями
            var connection4 = new InternetConnection.Builder()
                .SetProtocol("SSH")
                .SetEncryption("SSL")
                .SetIpVersion("IPv4")
                .AddAdditionalProperty("Username", "admin")
                .AddAdditionalProperty("Password", "password123")
                .Build();
            connection4.Connect();
        }
    }
}

